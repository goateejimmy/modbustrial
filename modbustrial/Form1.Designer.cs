namespace modbustrial
{
	partial class Form1
	{
		/// <summary>
		/// 設計工具所需的變數。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 清除任何使用中的資源。
		/// </summary>
		/// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form 設計工具產生的程式碼

		/// <summary>
		/// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
		/// 這個方法的內容。
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
			this.panel1 = new System.Windows.Forms.Panel();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.port_connect = new System.Windows.Forms.Button();
			this.port_disconnect = new System.Windows.Forms.Button();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// comboBox1
			// 
			this.comboBox1.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Location = new System.Drawing.Point(25, 82);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(233, 28);
			this.comboBox1.TabIndex = 0;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.textBox1);
			this.panel1.Controls.Add(this.port_disconnect);
			this.panel1.Controls.Add(this.port_connect);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.comboBox1);
			this.panel1.Location = new System.Drawing.Point(48, 40);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(527, 255);
			this.panel1.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Book Antiqua", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(19, 10);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(258, 44);
			this.label1.TabIndex = 1;
			this.label1.Text = "Port connection";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(22, 54);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(39, 19);
			this.label2.TabIndex = 2;
			this.label2.Text = "Port";
			// 
			// port_connect
			// 
			this.port_connect.Location = new System.Drawing.Point(25, 116);
			this.port_connect.Name = "port_connect";
			this.port_connect.Size = new System.Drawing.Size(76, 39);
			this.port_connect.TabIndex = 3;
			this.port_connect.Text = "Connect";
			this.port_connect.UseVisualStyleBackColor = true;
			// 
			// port_disconnect
			// 
			this.port_disconnect.Location = new System.Drawing.Point(107, 116);
			this.port_disconnect.Name = "port_disconnect";
			this.port_disconnect.Size = new System.Drawing.Size(86, 39);
			this.port_disconnect.TabIndex = 4;
			this.port_disconnect.Text = "Disconnect";
			this.port_disconnect.UseVisualStyleBackColor = true;
			// 
			// textBox1
			// 
			this.textBox1.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.textBox1.Location = new System.Drawing.Point(25, 181);
			this.textBox1.Name = "textBox1";
			this.textBox1.ReadOnly = true;
			this.textBox1.Size = new System.Drawing.Size(479, 39);
			this.textBox1.TabIndex = 5;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1831, 901);
			this.Controls.Add(this.panel1);
			this.Name = "Form1";
			this.Text = "Form1";
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ComboBox comboBox1;
		private System.IO.Ports.SerialPort serialPort1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Button port_disconnect;
		private System.Windows.Forms.Button port_connect;
		private System.Windows.Forms.Label label2;
	}
}

