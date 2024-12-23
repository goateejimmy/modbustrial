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
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.port_status = new System.Windows.Forms.TextBox();
			this.port_disconnect = new System.Windows.Forms.Button();
			this.port_connect = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.label4 = new System.Windows.Forms.Label();
			this.panel3 = new System.Windows.Forms.Panel();
			this.command_modeselect = new System.Windows.Forms.ComboBox();
			this.command_recivedCommand = new System.Windows.Forms.TextBox();
			this.command_currentCommand = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.panel4 = new System.Windows.Forms.Panel();
			this.try_forcetesthaptic = new System.Windows.Forms.Button();
			this.label7 = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.panel3.SuspendLayout();
			this.panel4.SuspendLayout();
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
			// textBox1
			// 
			this.textBox1.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.textBox1.Location = new System.Drawing.Point(25, 173);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(291, 31);
			this.textBox1.TabIndex = 6;
			this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
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
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(22, 151);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(57, 15);
			this.label3.TabIndex = 2;
			this.label3.Text = "Baudrate";
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
			// panel2
			// 
			this.panel2.Controls.Add(this.try_forcetesthaptic);
			this.panel2.Location = new System.Drawing.Point(597, 40);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(1081, 346);
			this.panel2.TabIndex = 3;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Book Antiqua", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new System.Drawing.Point(19, 21);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(98, 35);
			this.label4.TabIndex = 1;
			this.label4.Text = "Modes";
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.command_modeselect);
			this.panel3.Controls.Add(this.label4);
			this.panel3.Controls.Add(this.command_recivedCommand);
			this.panel3.Controls.Add(this.command_currentCommand);
			this.panel3.Controls.Add(this.label6);
			this.panel3.Controls.Add(this.label8);
			this.panel3.Controls.Add(this.label5);
			this.panel3.Location = new System.Drawing.Point(48, 415);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(802, 455);
			this.panel3.TabIndex = 4;
			// 
			// command_modeselect
			// 
			this.command_modeselect.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.command_modeselect.FormattingEnabled = true;
			this.command_modeselect.Location = new System.Drawing.Point(25, 72);
			this.command_modeselect.Name = "command_modeselect";
			this.command_modeselect.Size = new System.Drawing.Size(261, 28);
			this.command_modeselect.TabIndex = 2;
			this.command_modeselect.SelectedIndexChanged += new System.EventHandler(this.command_modeselect_SelectedIndexChanged);
			// 
			// command_recivedCommand
			// 
			this.command_recivedCommand.Font = new System.Drawing.Font("新細明體", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.command_recivedCommand.Location = new System.Drawing.Point(445, 182);
			this.command_recivedCommand.Multiline = true;
			this.command_recivedCommand.Name = "command_recivedCommand";
			this.command_recivedCommand.ReadOnly = true;
			this.command_recivedCommand.Size = new System.Drawing.Size(344, 257);
			this.command_recivedCommand.TabIndex = 0;
			// 
			// command_currentCommand
			// 
			this.command_currentCommand.Font = new System.Drawing.Font("新細明體", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.command_currentCommand.Location = new System.Drawing.Point(445, 70);
			this.command_currentCommand.Name = "command_currentCommand";
			this.command_currentCommand.ReadOnly = true;
			this.command_currentCommand.Size = new System.Drawing.Size(344, 35);
			this.command_currentCommand.TabIndex = 0;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("Book Antiqua", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label6.Location = new System.Drawing.Point(439, 144);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(265, 35);
			this.label6.TabIndex = 1;
			this.label6.Text = "Recieved Command";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Font = new System.Drawing.Font("Book Antiqua", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label8.Location = new System.Drawing.Point(19, 158);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(148, 35);
			this.label8.TabIndex = 1;
			this.label8.Text = "Set to Zero";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Book Antiqua", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.Location = new System.Drawing.Point(439, 21);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(215, 35);
			this.label5.TabIndex = 1;
			this.label5.Text = "Send Command";
			// 
			// panel4
			// 
			this.panel4.Controls.Add(this.label7);
			this.panel4.Location = new System.Drawing.Point(877, 415);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(940, 454);
			this.panel4.TabIndex = 5;
			// 
			// try_forcetesthaptic
			// 
			this.try_forcetesthaptic.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.try_forcetesthaptic.Location = new System.Drawing.Point(17, 54);
			this.try_forcetesthaptic.Name = "try_forcetesthaptic";
			this.try_forcetesthaptic.Size = new System.Drawing.Size(125, 54);
			this.try_forcetesthaptic.TabIndex = 2;
			this.try_forcetesthaptic.Text = "Constant Force Test ";
			this.try_forcetesthaptic.UseVisualStyleBackColor = true;
			this.try_forcetesthaptic.Click += new System.EventHandler(this.try_forcetesthaptic_Click);
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Font = new System.Drawing.Font("Book Antiqua", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label7.Location = new System.Drawing.Point(17, 21);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(249, 35);
			this.label7.TabIndex = 1;
			this.label7.Text = "Manual Command";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1831, 901);
			this.Controls.Add(this.panel4);
			this.Controls.Add(this.panel3);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Name = "Form1";
			this.Text = "Form1";
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			this.panel4.ResumeLayout(false);
			this.panel4.PerformLayout();
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
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.TextBox command_currentCommand;
		private System.Windows.Forms.TextBox command_recivedCommand;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.ComboBox command_modeselect;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Button try_forcetesthaptic;
		private System.Windows.Forms.Label label8;
	}
}

