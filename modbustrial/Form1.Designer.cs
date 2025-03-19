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
			this.port_baudrate = new System.Windows.Forms.TextBox();
			this.port_status = new System.Windows.Forms.TextBox();
			this.port_disconnect = new System.Windows.Forms.Button();
			this.port_connect = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.panel3 = new System.Windows.Forms.Panel();
			this.zeroposition = new System.Windows.Forms.Button();
			this.enable_sleep = new System.Windows.Forms.Button();
			this.Stream_forcetextbox = new System.Windows.Forms.TextBox();
			this.Stream_positiontextbox = new System.Windows.Forms.TextBox();
			this.command_recivedCommand = new System.Windows.Forms.TextBox();
			this.command_currentCommand = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.panel4 = new System.Windows.Forms.Panel();
			this.BLGF_EndTest = new System.Windows.Forms.Button();
			this.BLGF_StartTest = new System.Windows.Forms.Button();
			this.ttry = new System.Windows.Forms.TextBox();
			this.BLGF_selectpathButton = new System.Windows.Forms.Button();
			this.label15 = new System.Windows.Forms.Label();
			this.command_force = new System.Windows.Forms.TextBox();
			this.force_adjust = new System.Windows.Forms.TrackBar();
			this.stream_disable = new System.Windows.Forms.Button();
			this.haptic_ctrlregister = new System.Windows.Forms.Button();
			this.haptic_setforce = new System.Windows.Forms.Button();
			this.stream_motorcommandstream = new System.Windows.Forms.Button();
			this.label7 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label14 = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			this.panel3.SuspendLayout();
			this.panel4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.force_adjust)).BeginInit();
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
			this.port_comport.SelectedIndexChanged += new System.EventHandler(this.port_comport_SelectedIndexChanged);
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.port_baudrate);
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
			// port_baudrate
			// 
			this.port_baudrate.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.port_baudrate.Location = new System.Drawing.Point(25, 189);
			this.port_baudrate.Name = "port_baudrate";
			this.port_baudrate.ReadOnly = true;
			this.port_baudrate.Size = new System.Drawing.Size(233, 31);
			this.port_baudrate.TabIndex = 6;
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
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Book Antiqua", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new System.Drawing.Point(19, 21);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(203, 35);
			this.label4.TabIndex = 1;
			this.label4.Text = "Basic operation";
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.zeroposition);
			this.panel3.Controls.Add(this.enable_sleep);
			this.panel3.Controls.Add(this.label4);
			this.panel3.Controls.Add(this.Stream_forcetextbox);
			this.panel3.Controls.Add(this.Stream_positiontextbox);
			this.panel3.Controls.Add(this.command_recivedCommand);
			this.panel3.Controls.Add(this.command_currentCommand);
			this.panel3.Controls.Add(this.label6);
			this.panel3.Controls.Add(this.label11);
			this.panel3.Controls.Add(this.label8);
			this.panel3.Controls.Add(this.label13);
			this.panel3.Controls.Add(this.label5);
			this.panel3.Controls.Add(this.label12);
			this.panel3.Controls.Add(this.label10);
			this.panel3.Location = new System.Drawing.Point(48, 415);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(802, 455);
			this.panel3.TabIndex = 4;
			// 
			// zeroposition
			// 
			this.zeroposition.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.zeroposition.Location = new System.Drawing.Point(101, 65);
			this.zeroposition.Name = "zeroposition";
			this.zeroposition.Size = new System.Drawing.Size(130, 40);
			this.zeroposition.TabIndex = 8;
			this.zeroposition.Text = "Zeero position";
			this.zeroposition.UseVisualStyleBackColor = true;
			this.zeroposition.Click += new System.EventHandler(this.zeroposition_Click);
			// 
			// enable_sleep
			// 
			this.enable_sleep.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.enable_sleep.Location = new System.Drawing.Point(25, 65);
			this.enable_sleep.Name = "enable_sleep";
			this.enable_sleep.Size = new System.Drawing.Size(70, 40);
			this.enable_sleep.TabIndex = 7;
			this.enable_sleep.Text = "Sleep";
			this.enable_sleep.UseVisualStyleBackColor = true;
			this.enable_sleep.Click += new System.EventHandler(this.enable_sleep_Click);
			// 
			// Stream_forcetextbox
			// 
			this.Stream_forcetextbox.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Stream_forcetextbox.Location = new System.Drawing.Point(17, 388);
			this.Stream_forcetextbox.Name = "Stream_forcetextbox";
			this.Stream_forcetextbox.ReadOnly = true;
			this.Stream_forcetextbox.Size = new System.Drawing.Size(111, 31);
			this.Stream_forcetextbox.TabIndex = 4;
			// 
			// Stream_positiontextbox
			// 
			this.Stream_positiontextbox.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Stream_positiontextbox.Location = new System.Drawing.Point(17, 305);
			this.Stream_positiontextbox.Name = "Stream_positiontextbox";
			this.Stream_positiontextbox.ReadOnly = true;
			this.Stream_positiontextbox.Size = new System.Drawing.Size(111, 31);
			this.Stream_positiontextbox.TabIndex = 4;
			// 
			// command_recivedCommand
			// 
			this.command_recivedCommand.Font = new System.Drawing.Font("新細明體", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.command_recivedCommand.Location = new System.Drawing.Point(260, 182);
			this.command_recivedCommand.Multiline = true;
			this.command_recivedCommand.Name = "command_recivedCommand";
			this.command_recivedCommand.ReadOnly = true;
			this.command_recivedCommand.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.command_recivedCommand.Size = new System.Drawing.Size(529, 257);
			this.command_recivedCommand.TabIndex = 0;
			// 
			// command_currentCommand
			// 
			this.command_currentCommand.Font = new System.Drawing.Font("新細明體", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.command_currentCommand.Location = new System.Drawing.Point(260, 70);
			this.command_currentCommand.Name = "command_currentCommand";
			this.command_currentCommand.ReadOnly = true;
			this.command_currentCommand.Size = new System.Drawing.Size(529, 35);
			this.command_currentCommand.TabIndex = 0;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("Book Antiqua", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label6.Location = new System.Drawing.Point(254, 144);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(265, 35);
			this.label6.TabIndex = 1;
			this.label6.Text = "Recieved Command";
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Font = new System.Drawing.Font("Book Antiqua", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label11.Location = new System.Drawing.Point(11, 357);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(51, 22);
			this.label11.TabIndex = 1;
			this.label11.Text = "Force";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Font = new System.Drawing.Font("Book Antiqua", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label8.Location = new System.Drawing.Point(19, 158);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(0, 35);
			this.label8.TabIndex = 1;
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Font = new System.Drawing.Font("Book Antiqua", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label13.Location = new System.Drawing.Point(134, 397);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(39, 22);
			this.label13.TabIndex = 1;
			this.label13.Text = "mN";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Book Antiqua", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.Location = new System.Drawing.Point(254, 21);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(215, 35);
			this.label5.TabIndex = 1;
			this.label5.Text = "Send Command";
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Font = new System.Drawing.Font("Book Antiqua", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label12.Location = new System.Drawing.Point(134, 314);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(35, 22);
			this.label12.TabIndex = 1;
			this.label12.Text = "um";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Font = new System.Drawing.Font("Book Antiqua", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label10.Location = new System.Drawing.Point(13, 274);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(71, 22);
			this.label10.TabIndex = 1;
			this.label10.Text = "Position";
			// 
			// panel4
			// 
			this.panel4.Controls.Add(this.BLGF_EndTest);
			this.panel4.Controls.Add(this.BLGF_StartTest);
			this.panel4.Controls.Add(this.ttry);
			this.panel4.Controls.Add(this.BLGF_selectpathButton);
			this.panel4.Controls.Add(this.label15);
			this.panel4.Controls.Add(this.command_force);
			this.panel4.Controls.Add(this.force_adjust);
			this.panel4.Controls.Add(this.stream_disable);
			this.panel4.Controls.Add(this.haptic_ctrlregister);
			this.panel4.Controls.Add(this.haptic_setforce);
			this.panel4.Controls.Add(this.stream_motorcommandstream);
			this.panel4.Controls.Add(this.label7);
			this.panel4.Controls.Add(this.label9);
			this.panel4.Controls.Add(this.label14);
			this.panel4.Location = new System.Drawing.Point(877, 12);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(940, 857);
			this.panel4.TabIndex = 5;
			// 
			// BLGF_EndTest
			// 
			this.BLGF_EndTest.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.BLGF_EndTest.ForeColor = System.Drawing.SystemColors.ControlText;
			this.BLGF_EndTest.Location = new System.Drawing.Point(270, 487);
			this.BLGF_EndTest.Name = "BLGF_EndTest";
			this.BLGF_EndTest.Size = new System.Drawing.Size(235, 56);
			this.BLGF_EndTest.TabIndex = 15;
			this.BLGF_EndTest.Text = "End Test";
			this.BLGF_EndTest.UseVisualStyleBackColor = true;
			this.BLGF_EndTest.Click += new System.EventHandler(this.BLGF_EndTest_Click);
			// 
			// BLGF_StartTest
			// 
			this.BLGF_StartTest.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.BLGF_StartTest.ForeColor = System.Drawing.SystemColors.ControlText;
			this.BLGF_StartTest.Location = new System.Drawing.Point(25, 487);
			this.BLGF_StartTest.Name = "BLGF_StartTest";
			this.BLGF_StartTest.Size = new System.Drawing.Size(235, 56);
			this.BLGF_StartTest.TabIndex = 14;
			this.BLGF_StartTest.Text = "Start Test";
			this.BLGF_StartTest.UseVisualStyleBackColor = true;
			this.BLGF_StartTest.Click += new System.EventHandler(this.BLGF_StartTest_Click);
			// 
			// ttry
			// 
			this.ttry.Font = new System.Drawing.Font("新細明體", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.ttry.Location = new System.Drawing.Point(25, 565);
			this.ttry.Multiline = true;
			this.ttry.Name = "ttry";
			this.ttry.ReadOnly = true;
			this.ttry.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.ttry.Size = new System.Drawing.Size(529, 240);
			this.ttry.TabIndex = 13;
			this.ttry.TextChanged += new System.EventHandler(this.ttry_TextChanged);
			// 
			// BLGF_selectpathButton
			// 
			this.BLGF_selectpathButton.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.BLGF_selectpathButton.Location = new System.Drawing.Point(25, 415);
			this.BLGF_selectpathButton.Name = "BLGF_selectpathButton";
			this.BLGF_selectpathButton.Size = new System.Drawing.Size(235, 56);
			this.BLGF_selectpathButton.TabIndex = 12;
			this.BLGF_selectpathButton.Text = "Select profile";
			this.BLGF_selectpathButton.UseVisualStyleBackColor = true;
			this.BLGF_selectpathButton.Click += new System.EventHandler(this.button1_Click_2);
			// 
			// label15
			// 
			this.label15.AutoSize = true;
			this.label15.Font = new System.Drawing.Font("Book Antiqua", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label15.Location = new System.Drawing.Point(19, 364);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(241, 35);
			this.label15.TabIndex = 11;
			this.label15.Text = "BLGF force profile";
			// 
			// command_force
			// 
			this.command_force.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.command_force.Location = new System.Drawing.Point(511, 274);
			this.command_force.Name = "command_force";
			this.command_force.ReadOnly = true;
			this.command_force.Size = new System.Drawing.Size(139, 31);
			this.command_force.TabIndex = 10;
			// 
			// force_adjust
			// 
			this.force_adjust.Location = new System.Drawing.Point(10, 270);
			this.force_adjust.Maximum = 50000;
			this.force_adjust.Name = "force_adjust";
			this.force_adjust.Size = new System.Drawing.Size(495, 56);
			this.force_adjust.TabIndex = 9;
			this.force_adjust.Scroll += new System.EventHandler(this.force_adjust_Scroll);
			// 
			// stream_disable
			// 
			this.stream_disable.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.stream_disable.Location = new System.Drawing.Point(23, 167);
			this.stream_disable.Name = "stream_disable";
			this.stream_disable.Size = new System.Drawing.Size(235, 56);
			this.stream_disable.TabIndex = 8;
			this.stream_disable.Text = "Disable High-Speed";
			this.stream_disable.UseVisualStyleBackColor = true;
			this.stream_disable.Click += new System.EventHandler(this.stream_disable_Click);
			// 
			// haptic_ctrlregister
			// 
			this.haptic_ctrlregister.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.haptic_ctrlregister.Location = new System.Drawing.Point(283, 98);
			this.haptic_ctrlregister.Name = "haptic_ctrlregister";
			this.haptic_ctrlregister.Size = new System.Drawing.Size(235, 58);
			this.haptic_ctrlregister.TabIndex = 2;
			this.haptic_ctrlregister.Text = "Enable constant force";
			this.haptic_ctrlregister.UseVisualStyleBackColor = true;
			// 
			// haptic_setforce
			// 
			this.haptic_setforce.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.haptic_setforce.Location = new System.Drawing.Point(283, 165);
			this.haptic_setforce.Name = "haptic_setforce";
			this.haptic_setforce.Size = new System.Drawing.Size(235, 58);
			this.haptic_setforce.TabIndex = 5;
			this.haptic_setforce.Text = "Set Force";
			this.haptic_setforce.UseVisualStyleBackColor = true;
			this.haptic_setforce.Click += new System.EventHandler(this.button2_Click);
			// 
			// stream_motorcommandstream
			// 
			this.stream_motorcommandstream.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.stream_motorcommandstream.Location = new System.Drawing.Point(23, 98);
			this.stream_motorcommandstream.Name = "stream_motorcommandstream";
			this.stream_motorcommandstream.Size = new System.Drawing.Size(235, 58);
			this.stream_motorcommandstream.TabIndex = 2;
			this.stream_motorcommandstream.Text = "Motor Command Stream (Haptic)";
			this.stream_motorcommandstream.UseVisualStyleBackColor = true;
			this.stream_motorcommandstream.Click += new System.EventHandler(this.stream_motorcommandstream_Click);
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Font = new System.Drawing.Font("Book Antiqua", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label7.Location = new System.Drawing.Point(17, 21);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(241, 35);
			this.label7.TabIndex = 1;
			this.label7.Text = "Stream Command";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Font = new System.Drawing.Font("Book Antiqua", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label9.Location = new System.Drawing.Point(19, 226);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(135, 22);
			this.label9.TabIndex = 1;
			this.label9.Text = "Command Force";
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.Font = new System.Drawing.Font("Book Antiqua", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label14.Location = new System.Drawing.Point(656, 283);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(39, 22);
			this.label14.TabIndex = 1;
			this.label14.Text = "mN";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1924, 1047);
			this.Controls.Add(this.panel4);
			this.Controls.Add(this.panel3);
			this.Controls.Add(this.panel1);
			this.Name = "Form1";
			this.Text = "Form1";
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			this.panel4.ResumeLayout(false);
			this.panel4.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.force_adjust)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ComboBox port_comport;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox port_status;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox port_baudrate;
		private System.Windows.Forms.Button port_disconnect;
		private System.Windows.Forms.Button port_connect;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.TextBox command_currentCommand;
		private System.Windows.Forms.TextBox command_recivedCommand;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Button stream_motorcommandstream;
		private System.Windows.Forms.TextBox Stream_forcetextbox;
		private System.Windows.Forms.TextBox Stream_positiontextbox;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Button haptic_setforce;
		private System.Windows.Forms.Button stream_disable;
		private System.Windows.Forms.TrackBar force_adjust;
		private System.Windows.Forms.Button enable_sleep;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox command_force;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Button zeroposition;
		private System.Windows.Forms.Button haptic_ctrlregister;
		private System.Windows.Forms.Button BLGF_selectpathButton;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.TextBox ttry;
		private System.Windows.Forms.Button BLGF_StartTest;
		private System.Windows.Forms.Button BLGF_EndTest;
	}
}

