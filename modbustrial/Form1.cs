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




namespace modbustrial
{
	public partial class Form1 : Form
	{
		private static Form1 form = null;

		
		SerialPort port;
		//port settingstring[
		string[] ports = SerialPort.GetPortNames();
		int baudrate = 19200;
		int recievedDatalength;
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
			CTRL_REG_0 = 0,
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

		}





		public Form1()
		{
			InitializeComponent();
			command_modeselect.Items.AddRange( Enum.GetNames(typeof(Mode)));
			
		}

		private void port_connect_Click(object sender, EventArgs e)
		{
			port = new SerialPort(port_comport.Text, baudrate, Parity.Even, 8, StopBits.One);
			port.DataReceived += Port_DataReceived;
			//OrcaModbus =new Modbus();
			//motorport.Write()
			port_status.Text = "Conneted! Initial baudrate is 19200.";
			command_modeselect.SelectedIndex = command_modeselect.FindStringExact("Sleep_Mode");


		}

		private void Port_DataReceived(object sender, SerialDataReceivedEventArgs e)
		{
			if(port.BytesToRead >= recievedDatalength)
			{
				byte[] buffer = new byte[recievedDatalength];
				port.Read(buffer, 0, buffer.Length);
				string hex = BitConverter.ToString(buffer);
				command_recivedCommand.AppendText(hex);
				

			}
		}



		private void textBox1_TextChanged(object sender, EventArgs e)
		{
			
		}

		private void command_modeselect_SelectedIndexChanged(object sender, EventArgs e)
		{
			if(this.port != null)
			{
				Enum.TryParse((string)(command_modeselect.SelectedItem), out Mode curmode);
				Setmode(curmode);
			}
		}

		private void try_forcetesthaptic_Click(object sender, EventArgs e)
		{
			if (this.port != null)
			{

				HatpicConstant(2000); // set force to 2 N

			}
		}


		public void HatpicConstant(int forcemn)

		{
			this.Setmode(Mode.Haptic_Mode); // need to switch to haptic mode. need to find better way to look up whether the mode is in haptic mode right now
			this.WriteSingleRegister((ushort)Register.HAPTIC_STATUS, (ushort)1); //only open the constant function, see page 42
			this.WriteTwoRegister((ushort)Register.CONSTANT_FORCE_MN, forcemn);

		}
		public void Setmode(Mode mode)
		{
			this.WriteSingleRegister((ushort)Register.CTRL_REG_3, (ushort)mode);
		}

		public void ReadHoldingRegister(ushort startAddress, ushort quantity)
		{
			recievedDatalength = 5 + 2 * quantity;

			// Modbus Command Structure (Example for Read)
			// | Device ID | Function Code | Start Address | Quantity | CRC |
			byte[] command = packet8byte(3, startAddress, quantity);
			command_currentCommand.Text = BitConverter.ToString(command);
			this.port.Write(command, 0, command.Length);

		}

		public void WriteSingleRegister(ushort writeAddress, ushort writevalue)
		{
			recievedDatalength = 8;
			byte[] command = packet8byte(6, writeAddress, writevalue);
			command_currentCommand.Text = BitConverter.ToString(command);
			this.port.Write(command, 0, command.Length);


		}

		//I think there will be a function pointer that can adjust the command with different number of register
		public void WriteTwoRegister(ushort startingAddress, int continuousvalue)
		{
			recievedDatalength = 8;
			byte[] command = new byte[14];
			command[0] = (byte)0X01;
			command[1] = (byte)0X10;

			//Start register
			command[2] = (byte)(startingAddress >> 8); // High byte
			command[3] = (byte)(startingAddress & 0xFF); // Low byte

			//Two register to write
			command[4] = (byte)0X00;
			command[5] = (byte)0X02;


			//byte count
			command[6] = (byte)0X00;
			command[7] = (byte)0X04;// 2*2 


			//write. low byte first and then high byte
			command[8] = (byte)((continuousvalue >> 8) & 0xFF);   // 低位 16 位元的高字節 (D4)
			command[9] = (byte)((continuousvalue >> 0) & 0xFF);   // 低位 16 位元的低字節 (C0)
			command[10] = (byte)((continuousvalue >> 24) & 0xFF);  // 高位 16 位元的高字節 (00)
			command[11] = (byte)((continuousvalue >> 16) & 0xFF);  // 高位 16 位元的低字節 (01)


			ushort crc = ComputeCRC(command, 12);
			command[12] = (byte)(crc >> 8); // CRC High byte
			command[13] = (byte)(crc & 0xFF); // CRC Low byte

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
			command[6] = (byte)(crc >> 8);   // CRC High byte
			command[7] = (byte)(crc & 0xFF); // CRC Low byte


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
	}
}

