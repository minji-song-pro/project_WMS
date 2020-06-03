namespace WMS
{
	partial class Sensor
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
			System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
			System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
			System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
			System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
			System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.lb_VR_error_cnt = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.lb_vr = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label22 = new System.Windows.Forms.Label();
			this.lb_humid = new System.Windows.Forms.Label();
			this.lb_humid_error_cnt = new System.Windows.Forms.Label();
			this.label21 = new System.Windows.Forms.Label();
			this.label20 = new System.Windows.Forms.Label();
			this.panel13 = new System.Windows.Forms.Panel();
			this.label5 = new System.Windows.Forms.Label();
			this.label16 = new System.Windows.Forms.Label();
			this.listView_sensor_log = new System.Windows.Forms.ListView();
			this.listView_error_standard = new System.Windows.Forms.ListView();
			this.panel8 = new System.Windows.Forms.Panel();
			this.chart_VR = new System.Windows.Forms.DataVisualization.Charting.Chart();
			this.panel4 = new System.Windows.Forms.Panel();
			this.chart_DHT11 = new System.Windows.Forms.DataVisualization.Charting.Chart();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.panel14 = new System.Windows.Forms.Panel();
			this.groupBox6 = new System.Windows.Forms.GroupBox();
			this.button11 = new System.Windows.Forms.Button();
			this.tb_s_true = new System.Windows.Forms.TextBox();
			this.tb_s_location = new System.Windows.Forms.TextBox();
			this.label18 = new System.Windows.Forms.Label();
			this.tb_s_name = new System.Windows.Forms.TextBox();
			this.label38 = new System.Windows.Forms.Label();
			this.label39 = new System.Windows.Forms.Label();
			this.listView_sensor_info = new System.Windows.Forms.ListView();
			this.cb_Port = new System.Windows.Forms.ComboBox();
			this.btn_ClosePort = new System.Windows.Forms.Button();
			this.btn_OpenPort = new System.Windows.Forms.Button();
			this.cb_Bps = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.progressBar_PortStatus = new System.Windows.Forms.ProgressBar();
			this.label3 = new System.Windows.Forms.Label();
			this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
			this.tb_ReceiveData = new System.Windows.Forms.TextBox();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.panel13.SuspendLayout();
			this.panel8.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.chart_VR)).BeginInit();
			this.panel4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.chart_DHT11)).BeginInit();
			this.tabPage2.SuspendLayout();
			this.panel14.SuspendLayout();
			this.groupBox6.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Location = new System.Drawing.Point(12, 44);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(1300, 512);
			this.tabControl1.TabIndex = 14;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.groupBox2);
			this.tabPage1.Controls.Add(this.groupBox1);
			this.tabPage1.Controls.Add(this.panel13);
			this.tabPage1.Controls.Add(this.panel8);
			this.tabPage1.Controls.Add(this.panel4);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(1292, 486);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "모니터링";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.lb_VR_error_cnt);
			this.groupBox2.Controls.Add(this.label11);
			this.groupBox2.Controls.Add(this.label10);
			this.groupBox2.Controls.Add(this.label4);
			this.groupBox2.Controls.Add(this.lb_vr);
			this.groupBox2.Location = new System.Drawing.Point(14, 237);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(272, 143);
			this.groupBox2.TabIndex = 23;
			this.groupBox2.TabStop = false;
			// 
			// lb_VR_error_cnt
			// 
			this.lb_VR_error_cnt.AutoSize = true;
			this.lb_VR_error_cnt.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.lb_VR_error_cnt.Location = new System.Drawing.Point(155, 85);
			this.lb_VR_error_cnt.Name = "lb_VR_error_cnt";
			this.lb_VR_error_cnt.Size = new System.Drawing.Size(20, 19);
			this.lb_VR_error_cnt.TabIndex = 20;
			this.lb_VR_error_cnt.Text = "0";
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.label11.Location = new System.Drawing.Point(180, 85);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(29, 19);
			this.label11.TabIndex = 21;
			this.label11.Text = "건";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.label10.Location = new System.Drawing.Point(141, 54);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(89, 19);
			this.label10.TabIndex = 19;
			this.label10.Text = "이상감지";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.label4.Location = new System.Drawing.Point(37, 54);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(69, 19);
			this.label4.TabIndex = 17;
			this.label4.Text = "현재값";
			// 
			// lb_vr
			// 
			this.lb_vr.AutoSize = true;
			this.lb_vr.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.lb_vr.Location = new System.Drawing.Point(45, 85);
			this.lb_vr.Name = "lb_vr";
			this.lb_vr.Size = new System.Drawing.Size(20, 19);
			this.lb_vr.TabIndex = 18;
			this.lb_vr.Text = "0";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label22);
			this.groupBox1.Controls.Add(this.lb_humid);
			this.groupBox1.Controls.Add(this.lb_humid_error_cnt);
			this.groupBox1.Controls.Add(this.label21);
			this.groupBox1.Controls.Add(this.label20);
			this.groupBox1.Location = new System.Drawing.Point(14, 23);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(272, 143);
			this.groupBox1.TabIndex = 24;
			this.groupBox1.TabStop = false;
			// 
			// label22
			// 
			this.label22.AutoSize = true;
			this.label22.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.label22.Location = new System.Drawing.Point(37, 51);
			this.label22.Name = "label22";
			this.label22.Size = new System.Drawing.Size(69, 19);
			this.label22.TabIndex = 1;
			this.label22.Text = "현재값";
			// 
			// lb_humid
			// 
			this.lb_humid.AutoSize = true;
			this.lb_humid.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.lb_humid.Location = new System.Drawing.Point(45, 83);
			this.lb_humid.Name = "lb_humid";
			this.lb_humid.Size = new System.Drawing.Size(38, 19);
			this.lb_humid.TabIndex = 2;
			this.lb_humid.Text = "0.0";
			// 
			// lb_humid_error_cnt
			// 
			this.lb_humid_error_cnt.AutoSize = true;
			this.lb_humid_error_cnt.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.lb_humid_error_cnt.Location = new System.Drawing.Point(155, 83);
			this.lb_humid_error_cnt.Name = "lb_humid_error_cnt";
			this.lb_humid_error_cnt.Size = new System.Drawing.Size(20, 19);
			this.lb_humid_error_cnt.TabIndex = 0;
			this.lb_humid_error_cnt.Text = "0";
			// 
			// label21
			// 
			this.label21.AutoSize = true;
			this.label21.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.label21.Location = new System.Drawing.Point(141, 51);
			this.label21.Name = "label21";
			this.label21.Size = new System.Drawing.Size(89, 19);
			this.label21.TabIndex = 0;
			this.label21.Text = "이상감지";
			// 
			// label20
			// 
			this.label20.AutoSize = true;
			this.label20.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.label20.Location = new System.Drawing.Point(180, 83);
			this.label20.Name = "label20";
			this.label20.Size = new System.Drawing.Size(29, 19);
			this.label20.TabIndex = 0;
			this.label20.Text = "건";
			// 
			// panel13
			// 
			this.panel13.Controls.Add(this.label5);
			this.panel13.Controls.Add(this.label16);
			this.panel13.Controls.Add(this.listView_sensor_log);
			this.panel13.Controls.Add(this.listView_error_standard);
			this.panel13.Location = new System.Drawing.Point(893, 23);
			this.panel13.Name = "panel13";
			this.panel13.Size = new System.Drawing.Size(385, 440);
			this.panel13.TabIndex = 22;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.label5.Location = new System.Drawing.Point(10, 146);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(189, 15);
			this.label5.TabIndex = 4;
			this.label5.Text = "센서데이터로그 리스트뷰";
			// 
			// label16
			// 
			this.label16.AutoSize = true;
			this.label16.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.label16.Location = new System.Drawing.Point(10, 9);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(157, 15);
			this.label16.TabIndex = 3;
			this.label16.Text = "고장기준값 리스트뷰";
			// 
			// listView_sensor_log
			// 
			this.listView_sensor_log.HideSelection = false;
			this.listView_sensor_log.Location = new System.Drawing.Point(12, 164);
			this.listView_sensor_log.Name = "listView_sensor_log";
			this.listView_sensor_log.Size = new System.Drawing.Size(361, 269);
			this.listView_sensor_log.TabIndex = 2;
			this.listView_sensor_log.UseCompatibleStateImageBehavior = false;
			// 
			// listView_error_standard
			// 
			this.listView_error_standard.HideSelection = false;
			this.listView_error_standard.Location = new System.Drawing.Point(12, 26);
			this.listView_error_standard.Name = "listView_error_standard";
			this.listView_error_standard.Size = new System.Drawing.Size(361, 107);
			this.listView_error_standard.TabIndex = 0;
			this.listView_error_standard.UseCompatibleStateImageBehavior = false;
			// 
			// panel8
			// 
			this.panel8.Controls.Add(this.chart_VR);
			this.panel8.Location = new System.Drawing.Point(301, 237);
			this.panel8.Name = "panel8";
			this.panel8.Size = new System.Drawing.Size(586, 226);
			this.panel8.TabIndex = 20;
			// 
			// chart_VR
			// 
			chartArea1.Name = "ChartArea1";
			this.chart_VR.ChartAreas.Add(chartArea1);
			legend1.Name = "Legend1";
			this.chart_VR.Legends.Add(legend1);
			this.chart_VR.Location = new System.Drawing.Point(8, 9);
			this.chart_VR.Name = "chart_VR";
			this.chart_VR.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Fire;
			series1.ChartArea = "ChartArea1";
			series1.Legend = "Legend1";
			series1.Name = "VR";
			this.chart_VR.Series.Add(series1);
			this.chart_VR.Size = new System.Drawing.Size(563, 210);
			this.chart_VR.TabIndex = 13;
			this.chart_VR.Text = "chart1";
			// 
			// panel4
			// 
			this.panel4.Controls.Add(this.chart_DHT11);
			this.panel4.Location = new System.Drawing.Point(301, 23);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(586, 208);
			this.panel4.TabIndex = 21;
			// 
			// chart_DHT11
			// 
			chartArea2.Name = "ChartArea1";
			this.chart_DHT11.ChartAreas.Add(chartArea2);
			legend2.Name = "Legend1";
			this.chart_DHT11.Legends.Add(legend2);
			this.chart_DHT11.Location = new System.Drawing.Point(8, 9);
			this.chart_DHT11.Name = "chart_DHT11";
			series2.ChartArea = "ChartArea1";
			series2.Legend = "Legend1";
			series2.Name = "DHT11";
			this.chart_DHT11.Series.Add(series2);
			this.chart_DHT11.Size = new System.Drawing.Size(563, 196);
			this.chart_DHT11.TabIndex = 13;
			this.chart_DHT11.Text = "chart1";
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.panel14);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(1292, 486);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "센서등록";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// panel14
			// 
			this.panel14.Controls.Add(this.groupBox6);
			this.panel14.Controls.Add(this.listView_sensor_info);
			this.panel14.Location = new System.Drawing.Point(6, 6);
			this.panel14.Name = "panel14";
			this.panel14.Size = new System.Drawing.Size(881, 185);
			this.panel14.TabIndex = 2;
			// 
			// groupBox6
			// 
			this.groupBox6.Controls.Add(this.button11);
			this.groupBox6.Controls.Add(this.tb_s_true);
			this.groupBox6.Controls.Add(this.tb_s_location);
			this.groupBox6.Controls.Add(this.label18);
			this.groupBox6.Controls.Add(this.tb_s_name);
			this.groupBox6.Controls.Add(this.label38);
			this.groupBox6.Controls.Add(this.label39);
			this.groupBox6.Location = new System.Drawing.Point(592, 8);
			this.groupBox6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.groupBox6.Name = "groupBox6";
			this.groupBox6.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.groupBox6.Size = new System.Drawing.Size(274, 170);
			this.groupBox6.TabIndex = 39;
			this.groupBox6.TabStop = false;
			this.groupBox6.Text = "센서등록";
			// 
			// button11
			// 
			this.button11.Location = new System.Drawing.Point(205, 18);
			this.button11.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.button11.Name = "button11";
			this.button11.Size = new System.Drawing.Size(61, 29);
			this.button11.TabIndex = 38;
			this.button11.Text = "등록";
			this.button11.UseVisualStyleBackColor = true;
			this.button11.Click += new System.EventHandler(this.button11_Click);
			// 
			// tb_s_true
			// 
			this.tb_s_true.Location = new System.Drawing.Point(99, 80);
			this.tb_s_true.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.tb_s_true.Multiline = true;
			this.tb_s_true.Name = "tb_s_true";
			this.tb_s_true.Size = new System.Drawing.Size(100, 21);
			this.tb_s_true.TabIndex = 25;
			// 
			// tb_s_location
			// 
			this.tb_s_location.Location = new System.Drawing.Point(99, 55);
			this.tb_s_location.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.tb_s_location.Multiline = true;
			this.tb_s_location.Name = "tb_s_location";
			this.tb_s_location.Size = new System.Drawing.Size(100, 21);
			this.tb_s_location.TabIndex = 25;
			// 
			// label18
			// 
			this.label18.AutoSize = true;
			this.label18.Location = new System.Drawing.Point(14, 83);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(41, 12);
			this.label18.TabIndex = 32;
			this.label18.Text = "정상값";
			// 
			// tb_s_name
			// 
			this.tb_s_name.Location = new System.Drawing.Point(99, 23);
			this.tb_s_name.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.tb_s_name.Multiline = true;
			this.tb_s_name.Name = "tb_s_name";
			this.tb_s_name.Size = new System.Drawing.Size(100, 21);
			this.tb_s_name.TabIndex = 25;
			// 
			// label38
			// 
			this.label38.AutoSize = true;
			this.label38.Location = new System.Drawing.Point(14, 58);
			this.label38.Name = "label38";
			this.label38.Size = new System.Drawing.Size(53, 12);
			this.label38.TabIndex = 32;
			this.label38.Text = "센서위치";
			// 
			// label39
			// 
			this.label39.AutoSize = true;
			this.label39.Location = new System.Drawing.Point(14, 26);
			this.label39.Name = "label39";
			this.label39.Size = new System.Drawing.Size(41, 12);
			this.label39.TabIndex = 32;
			this.label39.Text = "센서명";
			// 
			// listView_sensor_info
			// 
			this.listView_sensor_info.HideSelection = false;
			this.listView_sensor_info.Location = new System.Drawing.Point(3, 3);
			this.listView_sensor_info.Name = "listView_sensor_info";
			this.listView_sensor_info.Size = new System.Drawing.Size(575, 179);
			this.listView_sensor_info.TabIndex = 0;
			this.listView_sensor_info.UseCompatibleStateImageBehavior = false;
			// 
			// cb_Port
			// 
			this.cb_Port.FormattingEnabled = true;
			this.cb_Port.Location = new System.Drawing.Point(686, 17);
			this.cb_Port.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.cb_Port.Name = "cb_Port";
			this.cb_Port.Size = new System.Drawing.Size(106, 20);
			this.cb_Port.TabIndex = 24;
			// 
			// btn_ClosePort
			// 
			this.btn_ClosePort.Location = new System.Drawing.Point(1228, 14);
			this.btn_ClosePort.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btn_ClosePort.Name = "btn_ClosePort";
			this.btn_ClosePort.Size = new System.Drawing.Size(78, 25);
			this.btn_ClosePort.TabIndex = 29;
			this.btn_ClosePort.Text = "Close Port";
			this.btn_ClosePort.UseVisualStyleBackColor = true;
			this.btn_ClosePort.Click += new System.EventHandler(this.btn_ClosePort_Click);
			// 
			// btn_OpenPort
			// 
			this.btn_OpenPort.Location = new System.Drawing.Point(1144, 14);
			this.btn_OpenPort.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btn_OpenPort.Name = "btn_OpenPort";
			this.btn_OpenPort.Size = new System.Drawing.Size(78, 25);
			this.btn_OpenPort.TabIndex = 30;
			this.btn_OpenPort.Text = "Open Port";
			this.btn_OpenPort.UseVisualStyleBackColor = true;
			this.btn_OpenPort.Click += new System.EventHandler(this.btn_OpenPort_Click);
			// 
			// cb_Bps
			// 
			this.cb_Bps.FormattingEnabled = true;
			this.cb_Bps.Items.AddRange(new object[] {
            "9600",
            "115200"});
			this.cb_Bps.Location = new System.Drawing.Point(844, 15);
			this.cb_Bps.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.cb_Bps.Name = "cb_Bps";
			this.cb_Bps.Size = new System.Drawing.Size(106, 20);
			this.cb_Bps.TabIndex = 23;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(653, 20);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(27, 12);
			this.label1.TabIndex = 27;
			this.label1.Text = "Port";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(811, 19);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(27, 12);
			this.label2.TabIndex = 26;
			this.label2.Text = "Bps";
			// 
			// progressBar_PortStatus
			// 
			this.progressBar_PortStatus.Location = new System.Drawing.Point(1043, 17);
			this.progressBar_PortStatus.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.progressBar_PortStatus.Name = "progressBar_PortStatus";
			this.progressBar_PortStatus.Size = new System.Drawing.Size(70, 18);
			this.progressBar_PortStatus.TabIndex = 28;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(971, 19);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(66, 12);
			this.label3.TabIndex = 25;
			this.label3.Text = "Port Status";
			// 
			// serialPort1
			// 
			this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
			// 
			// tb_ReceiveData
			// 
			this.tb_ReceiveData.Location = new System.Drawing.Point(537, 14);
			this.tb_ReceiveData.Name = "tb_ReceiveData";
			this.tb_ReceiveData.Size = new System.Drawing.Size(100, 21);
			this.tb_ReceiveData.TabIndex = 31;
			// 
			// Sensor
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1324, 575);
			this.Controls.Add(this.tb_ReceiveData);
			this.Controls.Add(this.cb_Port);
			this.Controls.Add(this.btn_ClosePort);
			this.Controls.Add(this.btn_OpenPort);
			this.Controls.Add(this.cb_Bps);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.progressBar_PortStatus);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.tabControl1);
			this.Name = "Sensor";
			this.Text = "Sensor";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Sensor_FormClosed);
			this.Load += new System.EventHandler(this.Sensor_Load);
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.panel13.ResumeLayout(false);
			this.panel13.PerformLayout();
			this.panel8.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.chart_VR)).EndInit();
			this.panel4.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.chart_DHT11)).EndInit();
			this.tabPage2.ResumeLayout(false);
			this.panel14.ResumeLayout(false);
			this.groupBox6.ResumeLayout(false);
			this.groupBox6.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.ComboBox cb_Port;
		private System.Windows.Forms.Button btn_ClosePort;
		private System.Windows.Forms.Button btn_OpenPort;
		private System.Windows.Forms.ComboBox cb_Bps;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ProgressBar progressBar_PortStatus;
		private System.Windows.Forms.Label label3;
		private System.IO.Ports.SerialPort serialPort1;
		private System.Windows.Forms.Panel panel14;
		private System.Windows.Forms.GroupBox groupBox6;
		private System.Windows.Forms.Button button11;
		private System.Windows.Forms.TextBox tb_s_true;
		private System.Windows.Forms.TextBox tb_s_location;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.TextBox tb_s_name;
		private System.Windows.Forms.Label label38;
		private System.Windows.Forms.Label label39;
		private System.Windows.Forms.ListView listView_sensor_info;
		private System.Windows.Forms.TextBox tb_ReceiveData;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label lb_VR_error_cnt;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label lb_vr;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.Label lb_humid;
		private System.Windows.Forms.Label lb_humid_error_cnt;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.Panel panel13;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.ListView listView_sensor_log;
		private System.Windows.Forms.ListView listView_error_standard;
		private System.Windows.Forms.Panel panel8;
		private System.Windows.Forms.DataVisualization.Charting.Chart chart_VR;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.DataVisualization.Charting.Chart chart_DHT11;
	}
}