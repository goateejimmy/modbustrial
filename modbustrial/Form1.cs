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

		//port settingstring[
		SerialPort motorport;
		string[] ports = SerialPort.GetPortNames();
		int baudrate = 19200;
		


		public Form1()
		{
			InitializeComponent();
		}

		private void port_connect_Click(object sender, EventArgs e)
		{
			motorport = new SerialPort(port_comport.Text, baudrate, Parity.Even, 8,StopBits.One);
			port_status.Text = "Conneted! Initial baudrate is 19200.";

		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{

		}
	}
}
