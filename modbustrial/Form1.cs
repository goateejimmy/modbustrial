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
using System.IO;
using System.Runtime.InteropServices;


namespace modbustrial
{
	public partial class Form1 : Form
	{
		private static Form1 form = null;

		
		SerialPort port;
		//port settingstring[
		string[] ports = SerialPort.GetPortNames();
		int baudrate = 125000;

		//Stream Motor value
		int position;
		int force;
		int power;
		int temperature;
		int voltage;
		int errors;
		
		

		//bool sendstream;
		Task Streamdatatask;
		CancellationTokenSource cts;

		//BLGF curves
		List<int> BLGFForce; // use int to directly compare with the register value
		List<int> BLGFdisplacement;
		int BLGFcursor;

		//Timers for recording datas
		System.Threading.Timer timer;
		List<int> IrisPosition;
		List<int> IrisForce;
		string recordpath = "C:\\Users\\jim.kuo\\OneDrive - shl-group.com\\Desktop\\training\\plunger force\\Motor\\modbustrial\\record.csv";


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
				port_baudrate.Text = baudrate.ToString();
				//OrcaModbus =new Modbus();
				//motorport.Write()
				port_status.Text = $"Conneted! Initial baudrate is :{port.BaudRate}";

			}
			else if (port_baudrate.Text != "")
			{
				port.Close();
				port = null;
				port = new SerialPort(port_comport.Text, Int32.Parse(port_baudrate.Text), Parity.Even, 8, StopBits.One);
				port.Open();
				port.DiscardInBuffer();
				port.DiscardOutBuffer();
				//int timeout = (int)Math.Ceiling(int.Parse(port_baudrate.Text) * 220 * 1.5);
				//setbaudrate(int.Parse(port_baudrate.Text));
				settimeout(2);
				port_status.Text = $"Conneted! baudrate is now :{port.BaudRate}";

			}
			await Task.Delay(100);
			Setmode(Mode.Sleep_Mode);
			await Task.Delay(100);
			await ReadRecieved(8);
			//settimeout(2000);



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
		private void AppendBLGF(string newText)
		{
			if (ttry.InvokeRequired)
			{
				ttry.Invoke(new Action(() => AppendBLGF(newText)));
			}
			else
			{
				ttry.AppendText(newText + Environment.NewLine);
			}
		}






		private async void stream_motorcommandstream_Click(object sender, EventArgs e)
		{
			 try
			{
				// 確保舊的執行緒被正確取消
				cts?.Cancel();
				cts?.Dispose();
				cts = new CancellationTokenSource();
				

				// 在背景執行緒執行迴圈，避免 UI 卡住
				await Task.Run(async () => await startread_send_streaming(cts.Token), cts.Token);
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Error: {ex.Message}");
			}


		}
		// ✅ 非同步迴圈，在背景執行緒執行，不會影響 UI
		private async Task startread_send_streaming(CancellationToken ct)
		{
			try
			{
				while (!ct.IsCancellationRequested) // 使用 CancellationToken 來控制結束
				{
					await MotorCommandStream(0X22, 1);
					await transferp_l(19);
					await Task.Delay(1, ct); // 允許取消
					int forceValue = GetForceAdjustValue();
					await HatpicConstant(forceValue);
					await transferp_l(8);
					await Task.Delay(1, ct); // 允許取消
				}
			}
			catch (TaskCanceledException)
			{
				Console.WriteLine("Streaming task was canceled.");
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Unexpected error: {ex.Message}");
			}
		}


		


	
		private async Task transferp_l(int len)
		{
			byte[] buffer = new byte[len];
			await port.BaseStream.ReadAsync(buffer, 0, buffer.Length);
			string hex = BitConverter.ToString(buffer);
			AppendText(hex);
			if (len>8)
			{
				if (buffer[0] != (byte)0X01 || buffer[1] != (byte)0X64)
				{
					return;
				}

				byte[] b_position = new byte[] { buffer[5], buffer[4], buffer[3], buffer[2] };
				this.position = BitConverter.ToInt32(b_position, 0);
				byte[] b_force = new byte[] { buffer[9], buffer[8], buffer[7], buffer[6] };
				this.force = BitConverter.ToInt32(b_force, 0);



				Stream_forcetextbox.Invoke(new Action(() =>
				Stream_forcetextbox.Text = this.force.ToString()
				));
				Stream_positiontextbox.Invoke(new Action(() =>
				Stream_positiontextbox.Text = this.position.ToString()
				));
			}


		}
		private async Task ReadRecieved(int recievedatalength)
		{
		

				byte[] buffer = new byte[recievedatalength];
				await port.BaseStream.ReadAsync(buffer, 0, buffer.Length);
				string hex = BitConverter.ToString(buffer);
				AppendText(hex);

		}
		private int GetForceAdjustValue()
		{
			if (force_adjust.InvokeRequired)
			{
				return (int)force_adjust.Invoke(new Func<int>(() => force_adjust.Value));
			}
			else
			{
				return force_adjust.Value;
			}
		}


		private void port_comport_SelectedIndexChanged(object sender, EventArgs e)
		{

		}

		private async void button1_Click(object sender, EventArgs e)
		{
			setbaudrate(int.Parse(port_baudrate.Text), 0);


			await MotorCommandStream(0X22, 1);
		}
		//this is a stream command
		void setbaudrate(int baudrate, ushort interdelay)
		{
			byte[] command = new byte[12]; //This command require 9 bytes
			command[0] = (byte)0x01; // Address
			command[1] = (byte)0X41;// Motor Command Stream

			// 0XFF00:enable, 0X00:disable
			command[2] = (byte)0xFF;   // High byte
			command[3] = (byte)0X00; // Low byte

			//baudrate
			command[4] = (byte)(baudrate >> 24 & 0XFF);   // High byte
			command[5] = (byte)(baudrate >> 16 & 0XFF); // Low byte
			command[6] = (byte)(baudrate >> 8 & 0XFF);
			command[7] = (byte)(baudrate & 0XFF);   // CRC High byte

			//command[4] = 0;   // High byte
			//command[5] = 9; // Low byte
			//command[6] = (byte)0X89;
			//command[7] = (byte)0X68;   // CRC High byte

			//delay
			command[8] = (byte)(interdelay >> 8 & 0XFF); // CRC Low byte
			command[9] = (byte)(interdelay & 0XFF);


			ushort crc = ComputeCRC(command, 10);
			command[10] = (byte)(crc & 0xFF);   // CRC High byte
			command[11] = (byte)(crc >> 8); // CRC Low byte
											//command[10] = (byte)0XA4;   // CRC High byte
											//command[11] = (byte)0XC1; // CRC Low byte
			string text = BitConverter.ToString(command);

			if (command_currentCommand.InvokeRequired)
			{
				command_currentCommand.Invoke(new Action(() => command_currentCommand.Text = text));
			}
			else
			{
				command_currentCommand.Text = text;
			}
			this.port.Write(command, 0, command.Length);

		}
		private void button2_Click(object sender, EventArgs e)
		{
			HatpicConstant(100000); // set force to 2 N
		}
		private void settimeout(ushort timeout)
		{
			byte[] command = packet8byte((byte)0x06, (ushort)Register.USER_COMMS_TIMEOUT, timeout);
			string text = BitConverter.ToString(command);

			if (command_currentCommand.InvokeRequired)
			{
				command_currentCommand.Invoke(new Action(() => command_currentCommand.Text = text));
			}
			else
			{
				command_currentCommand.Text = text;
			}

			this.port.Write(command, 0, command.Length);
		}
		private void button3_Click(object sender, EventArgs e)
		{
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
			string text = BitConverter.ToString(command);

			if (command_currentCommand.InvokeRequired)
			{
				command_currentCommand.Invoke(new Action(() => command_currentCommand.Text = text));
			}
			else
			{
				command_currentCommand.Text = text;
			}
			this.port.Write(command, 0, command.Length);
		}

		//example in page 17
		private void kinematic_displace_Click(object sender, EventArgs e)
		{
			this.WriteTwoRegister((ushort)Register.KIN_MOTION_0, 10000);
		}

		private async void stream_disable_Click(object sender, EventArgs e)
		{
			if (!cts.IsCancellationRequested )
			{
				cts.Cancel();
			}
			await Task.Delay(2000);
			this.port.DiscardInBuffer();

			byte[] command = new byte[6]; //This command require 9 bytes
			command[0] = (byte)0x01; // Address
			command[1] = (byte)0X41;// Motor Command Stream

			// 0XFF00:enable, 0X00:disable
			command[2] = (byte)0x00;   // High byte
			command[3] = (byte)0X00; // Low byte


			ushort crc = ComputeCRC(command, 4);
			command[4] = (byte)(crc & 0xFF);   // CRC High byte
			command[5] = (byte)(crc >> 8); // CRC Low byte
			string text = BitConverter.ToString(command);

			if (command_currentCommand.InvokeRequired)
			{
				command_currentCommand.Invoke(new Action(() => command_currentCommand.Text = text));
			}
			else
			{
				command_currentCommand.Text = text;
			}
			await this.port.BaseStream.WriteAsync(command, 0, command.Length);
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

		private async void enable_sleep_Click(object sender, EventArgs e)
		{
			if (cts != null)
			{
				if (!cts.IsCancellationRequested)
				{
					cts.Cancel();
					await Task.Delay(2000);
					this.port.DiscardInBuffer();
				}

			}

			Setmode(Mode.Sleep_Mode);

		}

		private void enable_force_Click(object sender, EventArgs e)
		{
			Setmode(Mode.Force_Mode);
		}

		private void force_constant_Click(object sender, EventArgs e)
		{
			this.WriteTwoRegister((ushort)Register.FORCE_CMD, 50000);
		}



		//Function for packing command
		public async Task HatpicConstant(int forcemn)
		{
			this.WriteTwoRegister((ushort)Register.CONSTANT_FORCE_MN, forcemn);
		}
		public async void Setmode(Mode mode)
		{
			

			await this.WriteSingleRegister((ushort)Register.CTRL_REG_3, (ushort)mode);
			await ReadRecieved(8);
		}

		public void ReadHoldingRegister(ushort startAddress, ushort quantity)
		{
			

			//recievedDatalength = 5 + 2 * quantity;

			// Modbus Command Structure (Example for Read)
			// | Device ID | Function Code | Start Address | Quantity | CRC |
			byte[] command = packet8byte(3, startAddress, quantity);
			string text = BitConverter.ToString(command);

			if (command_currentCommand.InvokeRequired)
			{
				command_currentCommand.Invoke(new Action(() => command_currentCommand.Text = text));
			}
			else
			{
				command_currentCommand.Text = text;
			}
			this.port.Write(command, 0, command.Length);

		}

		public async Task WriteSingleRegister(ushort writeAddress, ushort writevalue)
		{

			byte[] command = packet8byte(6, writeAddress, writevalue);
			string text = BitConverter.ToString(command);

			if (command_currentCommand.InvokeRequired)
			{
				command_currentCommand.Invoke(new Action(() => command_currentCommand.Text = text));
			}
			else
			{
				command_currentCommand.Text = text;
			}
			await this.port.BaseStream.WriteAsync(command, 0, command.Length);


		}
		public async Task MotorCommandStream(byte subcode, int data)
		{
			byte[] command = new byte[9]; //This command require 9 bytes
			command[0] = (byte)0x01; // Address
			command[1] = (byte)0X64;// Motor Command Stream

			// Start Address (Low Byte, High Byte)
			command[2] = subcode;   // High byte


			//data
			command[3] = (byte)(data >> 24 & 0xFF); // Low byte
			command[4] = (byte)(data >> 16 & 0xFF);   // High byte
			command[5] = (byte)(data >> 8 & 0xFF); // Low byte
			command[6] = (byte)(data & 0xFF);


			// Compute and add CRC (Cyclic Redundancy Check)
			ushort crc = ComputeCRC(command, 7);
			command[7] = (byte)(crc & 0xFF);   // CRC High byte
			command[8] = (byte)(crc >> 8); // CRC Low byte

			string text = BitConverter.ToString(command);

			if (command_currentCommand.InvokeRequired)
			{
				command_currentCommand.Invoke(new Action(() => command_currentCommand.Text = text));
			}
			else
			{
				command_currentCommand.Text = text;
			}
			//this.port.Write(command, 0, command.Length);
			await this.port.BaseStream.WriteAsync(command, 0, command.Length);



		}
		//I think there will be a function pointer that can adjust the command with different number of register
		public async void WriteTwoRegister(ushort startingAddress, int continuousvalue)
		{

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

			string text = BitConverter.ToString(command);

			if (command_currentCommand.InvokeRequired)
			{
				command_currentCommand.Invoke(new Action(() => command_currentCommand.Text = text));
			}
			else
			{
				command_currentCommand.Text = text;
			}

			//this.port.Write(command, 0, command.Length);
			await this.port.BaseStream.WriteAsync(command, 0, command.Length);
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

		private async void zeroposition_Click(object sender, EventArgs e)
		{
			if(cts != null)
			{
				if (!cts.IsCancellationRequested)
				{
					cts.Cancel();
					await Task.Delay(2000);
					this.port.DiscardInBuffer();
				}

			}
			byte[] command = packet8byte((byte)0x06, (ushort)Register.CTRL_REG_0, 4);
			string text = BitConverter.ToString(command);

			if (command_currentCommand.InvokeRequired)
			{
				command_currentCommand.Invoke(new Action(() => command_currentCommand.Text = text));
			}
			else
			{
				command_currentCommand.Text = text;
			}

			await this.port.BaseStream.WriteAsync(command, 0, command.Length);
			await ReadRecieved(8);
		}

		private void button1_Click_2(object sender, EventArgs e)
		{
			BLGFdisplacement = new List<int>();
			BLGFForce = new List<int>();
			this.BLGFcursor = 0;
			string folderPath = @"K:\DEVT\ZZZ- Test Server\B-000108 EMAI\2.Test Related Documents\11. Feasibilty Study and Test Order\2025\TW-25-T0006\TW25T0006-C2G1V2S3\TW25T0006-C2G1V2S3.is_ccyclic_Exports\TW25T0006-C2G1V2S3_7.csv";
			using(var reader = new StreamReader(folderPath))
			{
				string line;
				reader.ReadLine();
				reader.ReadLine();
				while((line = reader.ReadLine()) != null)
				{
					AppendBLGF(line);
					string[] buf = line.Split(',');
					if (buf.Length >= 3)
					{
						string forceValue = buf[2].Replace("\"", "").Trim();
						string displacementValue = buf[1].Replace("\"", "").Trim();

						// 檢查是否為空
						if (string.IsNullOrWhiteSpace(forceValue) || string.IsNullOrWhiteSpace(displacementValue))
						{
							Console.WriteLine($"Skipping empty value: [{line}]");
							continue;
						}

						try
						{
							float force = float.Parse(forceValue);
							float displacement = float.Parse(displacementValue);

							BLGFForce.Add(-(int)(force*100000)); // KN --> mN
							BLGFdisplacement.Add((int)(displacement*1000)); // mm --> um
							
						}
						catch (FormatException ex)
						{
							Console.WriteLine($"Parse error on line: {line}");
							Console.WriteLine($"Error message: {ex.Message}");
						}
					}
					
					
				}
				AppendBLGF("Done");

			}
		}

		private void ttry_TextChanged(object sender, EventArgs e)
		{

		}

		private async void BLGF_StartTest_Click(object sender, EventArgs e)
		{
			try
			{
				cts?.Cancel();
				cts?.Dispose();
				cts = new CancellationTokenSource();


				await Task.Run(async () => await BLGF_test(cts.Token), cts.Token);
				//await Task.Run(async () => await Linear(cts.Token), cts.Token);

			}
			catch (Exception ex)
			{
				MessageBox.Show($"Error: {ex.Message}");
			}



		}
		private async Task Linear(CancellationToken ct)
		{


			while (!ct.IsCancellationRequested) // 使用 CancellationToken 來控制結束
			{
				await BLGF_getinfo();
				await Task.Delay(1, ct);
				await HatpicConstant(this.position/10);
				await Task.Delay(1, ct);
				await transferp_l(8);
				await Task.Delay(1, ct); // 允許取消
			}

		}
		private async Task<int> Findforce( int target)
		{
			if (target > this.BLGFdisplacement.Max()) { return 0; }

			int index = this.BLGFdisplacement.BinarySearch(target);

			if (index >= 0) return index; // Exact match found

			int insertionPoint = ~index;

			// Check boundaries
			if (insertionPoint == 0) return 0;
			if (insertionPoint == this.BLGFdisplacement.Count) return this.BLGFdisplacement.Count - 1;

			// Compare the closest two neighbors
			int prev = insertionPoint - 1;
			int next = insertionPoint;

			return await Interpolation(target,prev,next,this.BLGFdisplacement,this.BLGFForce);
		}
		private async Task<int> Interpolation(int curdis,int prev, int next, List<int> dis, List<int>frc)
		{
			return frc[prev] + ((frc[next] - frc[prev])*(curdis-dis[prev])/(dis[next] - dis[prev]));
		}
		private async Task BLGF_test(CancellationToken ct)
		{
			try
			{
				while (!ct.IsCancellationRequested) // 使用 CancellationToken 來控制結束
				{
					await MotorCommandStream(0X22, 3);
					await transferp_l(19);
					await Task.Delay(1, ct);					
					int frc = await Findforce(this.position);
					AppendBLGF(frc.ToString());
					await Task.Delay(1, ct);
					await HatpicConstant(frc);
					await transferp_l(8);
					await Task.Delay(1, ct); // 允許取消
				}
			}
			catch (TaskCanceledException)
			{
				Console.WriteLine("Streaming task was canceled.");
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Unexpected error: {ex.Message}");
			}
		}
		private async Task BLGF_getinfo()
		{
			await MotorCommandStream(0X22, 1);
			byte[] buffer = new byte[19];
			await port.BaseStream.ReadAsync(buffer, 0, buffer.Length);
			string hex = BitConverter.ToString(buffer);
			AppendText(hex);


			while (buffer[0] != (byte)0X01 || buffer[1] != (byte)0X64)
			{
				await MotorCommandStream(0X22, 1);
				await port.BaseStream.ReadAsync(buffer, 0, buffer.Length);
				AppendText(BitConverter.ToString(buffer));
				await Task.Delay(1);

			}

			byte[] b_position = new byte[] { buffer[5], buffer[4], buffer[3], buffer[2] };
			this.position = BitConverter.ToInt32(b_position, 0);
			byte[] b_force = new byte[] { buffer[9], buffer[8], buffer[7], buffer[6] };
			this.force = BitConverter.ToInt32(b_force, 0);



			Stream_forcetextbox.Invoke(new Action(() =>
			Stream_forcetextbox.Text = this.force.ToString()
			));
			Stream_positiontextbox.Invoke(new Action(() =>
			Stream_positiontextbox.Text = this.position.ToString()
			));


		}

		private async Task<int> BLGF_searchforce(int cursor, int curdis)
		{
			if (curdis >= BLGFdisplacement[cursor])
			{
				while (curdis >= BLGFdisplacement[cursor])
				{
					cursor++;

				}
				this.BLGFcursor = cursor;
				return BLGFForce[cursor];
			}
			else
			{
				while (curdis < BLGFdisplacement[cursor])
				{
					cursor--;

				}
				this.BLGFcursor = cursor;
				return BLGFForce[cursor];
			}
			
		
		}

		private void BLGF_EndTest_Click(object sender, EventArgs e)
		{
			if (!cts.IsCancellationRequested)
			{
				cts.Cancel();
			}
		}

		private void BLGF_Startrecord_Click(object sender, EventArgs e)
		{
			IrisForce = new List<int>();
			IrisPosition = new List<int>();

			TimerCallback callback = new TimerCallback(record);
			this.timer = new System.Threading.Timer(callback, null, 0, 100);


		}
		private void record(object state)
		{
			if (this.IrisPosition == null || this.IrisForce == null)
			{
				MessageBox.Show("not recording");
				return;
			}

			this.IrisPosition.Add(this.position);
			this.IrisForce.Add(this.force);
		}

		private void BLGF_EndRecord_Click(object sender, EventArgs e)
		{
			if(this.timer != null)
			{
				timer.Dispose();
				int count = Math.Min(this.IrisForce.Count, this.IrisPosition.Count);

				using (StreamWriter writer = new StreamWriter(this.recordpath))
				{
					writer.WriteLine("Displacement (um),Force(mN)");
					for(int i = 0; i < count; i++)
					{
						writer.WriteLine($"{this.IrisPosition[i]},{this.IrisForce[i]}");

					}
				}
			}
		}
	}
}
