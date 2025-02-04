using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace modbustrial
{
	public partial class Form1 : Form
	{
		private static Form1 form = null;

		
		SerialPort port;
		//port settingstring[
		string[] ports = SerialPort.GetPortNames();
		int baudrate =125000;
		int recievedDatalength;

		//Stream Motor value
		int position;
		int force;
		int power;
		int temperature;
		int voltage;
		int errors;
		bool monitor = false;
		private readonly object lockObj = new object();

		bool sendstream;
		public enum Mode
		{
			Sleep_Mode = 1,
			Force_Mode = 2,
			Position_Mode = 3,
			Haptic_Mode = 4,
			Kinematic_Mode = 5,
		}

		public enum Register
		{
			CTRL_REG_0 = 0, //third bit is for zero position
			CTRL_REG_1 = 1,
			CTRL_REG_2 = 2,
			CTRL_REG_3 = 3,

			//Force control
			FORCE_CMD = 28,
			FORCE_CMD_H = 29, //upper two bytes 

			//Position control
			POS_CMD = 30,
			POS_CMD_H = 31,

			//Haptic control
			HAPTIC_STATUS = 641,
			CONSTANT_FORCE_MN = 642,
			CONSTANT_FORCE_MN_H = 643,

			//Kinematic control
			KIN_MOTION_0 = 780,

			//Motor Performance Limits
			USER_COMMS_TIMEOUT = 163,

		}

		



		public Form1()
		{
			
			InitializeComponent();
			//Control.CheckForIllegalCrossThreadCalls = false;
			port_comport.Items.AddRange(ports);
			
		}

		private async void port_connect_Click(object sender, EventArgs e)
		{
			if (port == null)
			{
				port = new SerialPort(port_comport.Text, baudrate, Parity.Even, 8, StopBits.One);
				port_baudrate.ReadOnly = false;
				port.Open();
				port.DiscardInBuffer();
				port.DiscardOutBuffer();
				port.DataReceived += Port_DataReceived;
				port_baudrate.Text = baudrate.ToString();
				//OrcaModbus =new Modbus();
				//motorport.Write()
				port_status.Text = $"Conneted! Initial baudrate is :{port.BaudRate}";
				
			}
			else if(port_baudrate.Text != "")
			{
				port.Close();
				port = null;
				port = new SerialPort(port_comport.Text, Int32.Parse(port_baudrate.Text), Parity.Even, 8, StopBits.One);
				port.Open();
				port.DiscardInBuffer();
				port.DiscardOutBuffer();
				port.DataReceived += Port_DataReceived;
				//int timeout = (int)Math.Ceiling(int.Parse(port_baudrate.Text) * 220 * 1.5);
				//setbaudrate(int.Parse(port_baudrate.Text));
				settimeout(2);
				port_status.Text = $"Conneted! baudrate is now :{port.BaudRate}";

			}
			await Task.Delay(100);
			Setmode(Mode.Sleep_Mode);
			await Task.Delay(100);
			//settimeout(2000);



		}

		private async void Port_DataReceived(object sender, SerialDataReceivedEventArgs e)
		{
			
				if (port.BytesToRead >= recievedDatalength)
				{
					if (monitor)
					{

						byte[] buffer = new byte[recievedDatalength];
						//https://sparxeng.com/blog/software/must-use-net-system-io-ports-serialport
						await port.BaseStream.ReadAsync(buffer, 0, buffer.Length); 





						//port.Read(buffer, 0, buffer.Length);

						if (buffer[0] != (byte)0X01 || buffer[1] != (byte)0X64)
						{
							return;
						}
						if (recievedDatalength > 17)
						{
							byte[] b_position = new byte[] { buffer[5], buffer[4], buffer[3], buffer[2] };
							this.position = BitConverter.ToInt32(b_position, 0);
							byte[] b_force = new byte[] { buffer[9], buffer[8], buffer[7], buffer[6] };
							this.force = BitConverter.ToInt32(b_force, 0);


							string hex = BitConverter.ToString(buffer);

							AppendText(hex);
							Stream_forcetextbox.Invoke(new Action(() =>
							Stream_forcetextbox.Text = this.force.ToString()
							));
							Stream_positiontextbox.Invoke(new Action(() =>
							Stream_positiontextbox.Text = this.position.ToString()
							));
						}

					}
					else
					{
						byte[] buffer = new byte[recievedDatalength];
						port.Read(buffer, 0, buffer.Length);
						string hex = BitConverter.ToString(buffer);
						//command_recivedCommand.Invoke(new Action(() =>
						//command_recivedCommand.Text = hex
						//));
						AppendText(hex);

					}
				}
			
			
		}


		private void AppendText(string newText)
		{
			if (command_recivedCommand.InvokeRequired)
			{
				command_recivedCommand.Invoke(new Action(() => AppendText(newText)));
			}
			else
			{
				command_recivedCommand.AppendText(newText + Environment.NewLine);
			}
		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{
			
		}

		
		private async void try_forcetesthaptic_Click(object sender, EventArgs e)
		{

			//await Task.Delay(20);
			//this.port.DataReceived += Port_DataReceived;
			while (true)
			{

				this.WriteSingleRegister((ushort)Register.HAPTIC_STATUS, (ushort)1); //only open the constant function, see page 42
				Thread.Sleep(1);

			}
		}

		private async Task sending(CancellationToken ct)
		{
			try
			{

			}
			 catch (Exception ex)
			{

			}
		}


		private async void stream_motorcommandstream_Click(object sender, EventArgs e)
		{
		
			sendstream = true;
			setbaudrate(int.Parse(port_baudrate.Text), 0);
			
			await Task.Delay(10);
			this.port.DiscardInBuffer();
			monitor = true;
			while (sendstream)
			{

				
				MotorCommandStream(0X22, 1);
				await Task.Delay(1); //3.5*10/125000 = 0.28 ms


				HatpicConstant(force_adjust.Value); 
				await Task.Delay(1);

			}


		}



		private void label10_Click(object sender, EventArgs e)
		{

		}

		private void port_comport_SelectedIndexChanged(object sender, EventArgs e)
		{

		}

		private async void button1_Click(object sender, EventArgs e)
		{
			setbaudrate(int.Parse(port_baudrate.Text),0);

			
			MotorCommandStream(0X22, 1);
		}
		//this is a stream command
		void setbaudrate(int baudrate,ushort interdelay)
		{
			recievedDatalength = 11;
			byte[] command = new byte[12]; //This command require 9 bytes
			command[0] = (byte)0x01; // Address
			command[1] = (byte)0X41;// Motor Command Stream

			// 0XFF00:enable, 0X00:disable
			command[2] = (byte)0xFF;   // High byte
			command[3] = (byte)0X00; // Low byte

			//baudrate
			command[4] = (byte)(baudrate>>24 & 0XFF);   // High byte
			command[5] = (byte)(baudrate>> 16 & 0XFF); // Low byte
			command[6] = (byte)(baudrate >> 8 & 0XFF);
			command[7] = (byte)(baudrate  & 0XFF);   // CRC High byte

			//command[4] = 0;   // High byte
			//command[5] = 9; // Low byte
			//command[6] = (byte)0X89;
			//command[7] = (byte)0X68;   // CRC High byte

			//delay
			command[8] = (byte)(interdelay>>8 &0XFF); // CRC Low byte
			command[9] = (byte)(interdelay & 0XFF);


			ushort crc = ComputeCRC(command, 10);
			command[10] = (byte)(crc & 0xFF);   // CRC High byte
			command[11] = (byte)(crc >> 8); // CRC Low byte
			//command[10] = (byte)0XA4;   // CRC High byte
			//command[11] = (byte)0XC1; // CRC Low byte
			command_currentCommand.Text = BitConverter.ToString(command);
			this.port.Write(command, 0, command.Length);

		}
		private void button2_Click(object sender, EventArgs e)
		{
			HatpicConstant(100000); // set force to 2 N
		}
		private void settimeout(ushort timeout)
		{
			byte[] command = packet8byte((byte)0x06, (ushort)Register.USER_COMMS_TIMEOUT, timeout);
			command_currentCommand.Text = BitConverter.ToString(command);

			this.port.Write(command,0,command.Length);
		}
		private void button3_Click(object sender, EventArgs e)
		{
			recievedDatalength = 8;
			byte[] command = new byte[15];
			command[0] = (byte)0X01;
			command[1] = (byte)0X10;

			//Start register
			command[2] = (byte)0X03;
			command[3] = (byte)0X0C;

			//Two register to write
			command[4] = (byte)0X00;
			command[5] = (byte)0X03;


			//byte count
			command[6] = (byte)0X06;
			command[7] = (byte)0X27;


			//write. low byte first and then high byte
			command[8] = (byte)0X10;
			command[9] = (byte)0X00;
			command[10] = (byte)0X00;
			command[11] = (byte)0X03;



			command[12] = (byte)0XE8;
			command[13] = (byte)0XEE;
			command[14] = (byte)0X51;
			command_currentCommand.Text = BitConverter.ToString(command);
			this.port.Write(command, 0, command.Length);
		}

		//example in page 17
		private void kinematic_displace_Click(object sender, EventArgs e)
		{
			this.WriteTwoRegister((ushort)Register.KIN_MOTION_0, 10000);
		}

		private async void stream_disable_Click(object sender, EventArgs e)
		{
			sendstream = false;
			await Task.Delay(2000);
			this.port.DiscardInBuffer();
			recievedDatalength = 11;
			byte[] command = new byte[6]; //This command require 9 bytes
			command[0] = (byte)0x01; // Address
			command[1] = (byte)0X41;// Motor Command Stream

			// 0XFF00:enable, 0X00:disable
			command[2] = (byte)0x00;   // High byte
			command[3] = (byte)0X00; // Low byte


			ushort crc = ComputeCRC(command, 4);
			command[4] = (byte)(crc & 0xFF);   // CRC High byte
			command[5] = (byte)(crc >> 8); // CRC Low byte
			command_currentCommand.Text = BitConverter.ToString(command);
			this.port.Write(command, 0, command.Length);
			await Task.Delay(100);
			Setmode(Mode.Sleep_Mode);
		}

		private void enable_haptic_Click(object sender, EventArgs e)
		{
			Setmode(Mode.Haptic_Mode);
		}

		private void button1_Click_1(object sender, EventArgs e)
		{
			Setmode(Mode.Kinematic_Mode);
		}

		private void enable_sleep_Click(object sender, EventArgs e)
		{
			sendstream = false;
			Setmode(Mode.Sleep_Mode);
		}

		private void enable_force_Click(object sender, EventArgs e)
		{
			Setmode(Mode.Force_Mode);
		}

		private void force_constant_Click(object sender, EventArgs e)
		{
			recievedDatalength = 8;
			this.WriteTwoRegister((ushort)Register.FORCE_CMD, 50000);
		}



		//Function for packing command
		public void HatpicConstant(int forcemn)
		{
			this.WriteTwoRegister((ushort)Register.CONSTANT_FORCE_MN, forcemn);	
		}
		public void Setmode(Mode mode)
		{
			//monitor = false;
			this.WriteSingleRegister((ushort)Register.CTRL_REG_3, (ushort)mode);
		}

		public void ReadHoldingRegister(ushort startAddress, ushort quantity)
		{
			//monitor = false;
			recievedDatalength = 5 + 2 * quantity;

			// Modbus Command Structure (Example for Read)
			// | Device ID | Function Code | Start Address | Quantity | CRC |
			byte[] command = packet8byte(3, startAddress, quantity);
			command_currentCommand.Text = BitConverter.ToString(command);
			this.port.Write(command, 0, command.Length);

		}

		public void WriteSingleRegister(ushort writeAddress, ushort writevalue)
		{
			//monitor = false;
			recievedDatalength = 8;
			byte[] command = packet8byte(6, writeAddress, writevalue);
			command_currentCommand.Text = BitConverter.ToString(command);
			this.port.Write(command, 0, command.Length);


		}
		public void MotorCommandStream(byte subcode, int data)
		{
			//monitor = true;
			//this.port.DataReceived += Port_StreanDataReceived;
			recievedDatalength = 19;
			byte[] command = new byte[9]; //This command require 9 bytes
			command[0] = (byte)0x01; // Address
			command[1] = (byte)0X64;// Motor Command Stream

			// Start Address (Low Byte, High Byte)
			command[2] = subcode;   // High byte


			//data
			command[3] = (byte)(data >> 24 & 0xFF); // Low byte
			command[4] = (byte)(data >> 16 & 0xFF);   // High byte
			command[5] = (byte)(data >> 8 & 0xFF); // Low byte
			command[6] = (byte)(data  & 0xFF);


			// Compute and add CRC (Cyclic Redundancy Check)
			ushort crc = ComputeCRC(command, 7);
			command[7] = (byte)(crc & 0xFF);   // CRC High byte
			command[8] = (byte)(crc >> 8); // CRC Low byte

			command_currentCommand.Text = BitConverter.ToString(command);
			this.port.Write(command, 0, command.Length);



		}
		//I think there will be a function pointer that can adjust the command with different number of register
		public void WriteTwoRegister(ushort startingAddress, int continuousvalue)
		{
			//monitor = false;
			recievedDatalength = 8;
			byte[] command = new byte[13];
			command[0] = (byte)0X01;
			command[1] = (byte)0X10;

			//Start register
			command[2] = (byte)(startingAddress >> 8); // High byte
			command[3] = (byte)(startingAddress & 0xFF); // Low byte

			//Two register to write
			command[4] = (byte)0X00;
			command[5] = (byte)0X02;


			//byte count
			command[6] = (byte)0X04;// 2*2 



			//write. low byte first and then high byte

			command[7] = (byte)((continuousvalue >> 8) & 0xFF);  // 高位 16 位元的高字節 (00)
			command[8] = (byte)((continuousvalue) & 0xFF);  // 高位 16 位元的低字節 (01)
			command[9] = (byte)((continuousvalue >> 24) & 0xFF);  // 低位 16 位元的高字節 (D4)
			command[10] = (byte)((continuousvalue >> 16) & 0xFF);   // 低位 16 位元的低字節 (C0)


			ushort crc = ComputeCRC(command, 11);
			command[11] = (byte)(crc & 0xFF); // CRC High byte
			command[12] = (byte)(crc >> 8); // CRC Low byte

			command_currentCommand.Text = BitConverter.ToString(command);
			
			this.port.Write(command, 0, command.Length);
		}
		public byte[] packet8byte(byte func, ushort address, ushort cmd)
		{
			byte[] command = new byte[8];
			command[0] = (byte)0x01; // Address
			command[1] = func; // Function Code

			// Start Address (Low Byte, High Byte)
			command[2] = (byte)(address >> 8);   // High byte
			command[3] = (byte)(address & 0xFF); // Low byte


			// Quantity (Low Byte, High Byte)
			command[4] = (byte)(cmd >> 8);   // High byte
			command[5] = (byte)(cmd & 0xFF); // Low byte


			// Compute and add CRC (Cyclic Redundancy Check)
			ushort crc = ComputeCRC(command, 6);
			command[6] = (byte)(crc & 0xFF);   // CRC High byte
			command[7] = (byte)(crc >> 8); // CRC Low byte


			return command;
		}

		private static ushort ComputeCRC(byte[] data, int length)
		{
			ushort crc = 0xFFFF;
			for (int i = 0; i < length; i++)
			{
				crc ^= data[i];
				for (int j = 0; j < 8; j++)
				{
					if ((crc & 0x0001) != 0)
					{
						crc >>= 1;
						crc ^= 0xA001;
					}
					else
					{
						crc >>= 1;
					}
				}
			}
			return crc;
		}

		private void force_adjust_Scroll(object sender, EventArgs e)
		{
			command_force.Text = force_adjust.Value.ToString();
			
		}

		private void zeroposition_Click(object sender, EventArgs e)
		{
			byte[] command = packet8byte((byte)0x06, (ushort)Register.CTRL_REG_0, 4);
			command_currentCommand.Text = BitConverter.ToString(command);

			this.port.Write(command, 0, command.Length);
		}

		private void label6_Click(object sender, EventArgs e)
		{

		}
	}
}

