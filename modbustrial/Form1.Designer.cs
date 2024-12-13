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
			this.port_comport = new System.Windows.Forms.ComboBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.port_status = new System.Windows.Forms.TextBox();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.port_connect = new System.Windows.Forms.Button();
			this.port_disconnect = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.modbus_address = new System.Windows.Forms.TextBox();
			this.panel2 = new System.Windows.Forms.Panel();
			this.label4 = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// port_comport
			// 
			this.port_comport.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.port_comport.FormattingEnabled = true;
			this.port_comport.Location = new System.Drawing.Point(25, 76);
			this.port_comport.Name = "port_comport";
			this.port_comport.Size = new System.Drawing.Size(233, 28);
			this.port_comport.TabIndex = 0;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.textBox1);
			this.panel1.Controls.Add(this.port_status);
			this.panel1.Controls.Add(this.port_disconnect);
			this.panel1.Controls.Add(this.port_connect);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.port_comport);
			this.panel1.Location = new System.Drawing.Point(48, 40);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(527, 347);
			this.panel1.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Book Antiqua", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(19, 10);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(206, 35);
			this.label1.TabIndex = 1;
			this.label1.Text = "Port connection";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(22, 54);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(31, 15);
			this.label2.TabIndex = 2;
			this.label2.Text = "Port";
			// 
			// port_status
			// 
			this.port_status.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.port_status.Location = new System.Drawing.Point(25, 291);
			this.port_status.Name = "port_status";
			this.port_status.ReadOnly = true;
			this.port_status.Size = new System.Drawing.Size(479, 31);
			this.port_status.TabIndex = 5;
			// 
			// textBox1
			// 
			this.textBox1.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.textBox1.Location = new System.Drawing.Point(25, 173);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(291, 31);
			this.textBox1.TabIndex = 6;
			this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
			// 
			// port_connect
			// 
			this.port_connect.Location = new System.Drawing.Point(25, 236);
			this.port_connect.Name = "port_connect";
			this.port_connect.Size = new System.Drawing.Size(76, 39);
			this.port_connect.TabIndex = 3;
			this.port_connect.Text = "Connect";
			this.port_connect.UseVisualStyleBackColor = true;
			this.port_connect.Click += new System.EventHandler(this.port_connect_Click);
			// 
			// port_disconnect
			// 
			this.port_disconnect.Enabled = false;
			this.port_disconnect.Location = new System.Drawing.Point(119, 236);
			this.port_disconnect.Name = "port_disconnect";
			this.port_disconnect.Size = new System.Drawing.Size(86, 39);
			this.port_disconnect.TabIndex = 4;
			this.port_disconnect.Text = "Disconnect";
			this.port_disconnect.UseVisualStyleBackColor = true;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(22, 151);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(57, 15);
			this.label3.TabIndex = 2;
			this.label3.Text = "Baudrate";
			// 
			// modbus_address
			// 
			this.modbus_address.Font = new System.Drawing.Font("新細明體", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.modbus_address.Location = new System.Drawing.Point(35, 102);
			this.modbus_address.Name = "modbus_address";
			this.modbus_address.Size = new System.Drawing.Size(66, 40);
			this.modbus_address.TabIndex = 2;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.label4);
			this.panel2.Controls.Add(this.modbus_address);
			this.panel2.Location = new System.Drawing.Point(597, 40);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(1081, 346);
			this.panel2.TabIndex = 3;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Book Antiqua", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new System.Drawing.Point(19, 10);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(320, 44);
			this.label4.TabIndex = 1;
			this.label4.Text = "Modbus Command";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1831, 901);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Name = "Form1";
			this.Text = "Form1";
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ComboBox port_comport;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox port_status;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Button port_disconnect;
		private System.Windows.Forms.Button port_connect;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox modbus_address;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label label4;
	}
}

