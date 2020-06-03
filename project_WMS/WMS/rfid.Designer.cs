namespace WMS
{
	partial class rfid
	{
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 사용 중인 모든 리소스를 정리합니다.
		/// </summary>
		/// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form 디자이너에서 생성한 코드

		/// <summary>
		/// 디자이너 지원에 필요한 메서드입니다. 
		/// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(rfid));
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.lb_ComPort = new System.Windows.Forms.Label();
			this.btn_OpenPort = new System.Windows.Forms.Button();
			this.progressBar_PortStatus = new System.Windows.Forms.ProgressBar();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.cb_Bps = new System.Windows.Forms.ComboBox();
			this.cb_Port = new System.Windows.Forms.ComboBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.tb_ReceiveData = new System.Windows.Forms.TextBox();
			this.btn_ClosePort = new System.Windows.Forms.Button();
			this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
			this.panel_main = new System.Windows.Forms.Panel();
			this.listView_sawon = new System.Windows.Forms.ListView();
			this.panel2 = new System.Windows.Forms.Panel();
			this.lb_CarNum = new System.Windows.Forms.Label();
			this.lb_Name = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.tb_barcode4 = new System.Windows.Forms.TextBox();
			this.cb_location = new System.Windows.Forms.ComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.panel_tag = new System.Windows.Forms.Panel();
			this.textBox5 = new System.Windows.Forms.TextBox();
			this.tb_barcode3 = new System.Windows.Forms.TextBox();
			this.tb_barcode1 = new System.Windows.Forms.TextBox();
			this.tb_barcode2 = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.label33 = new System.Windows.Forms.Label();
			this.label34 = new System.Windows.Forms.Label();
			this.label29 = new System.Windows.Forms.Label();
			this.label30 = new System.Windows.Forms.Label();
			this.label31 = new System.Windows.Forms.Label();
			this.label32 = new System.Windows.Forms.Label();
			this.label28 = new System.Windows.Forms.Label();
			this.label27 = new System.Windows.Forms.Label();
			this.label26 = new System.Windows.Forms.Label();
			this.label25 = new System.Windows.Forms.Label();
			this.label24 = new System.Windows.Forms.Label();
			this.label23 = new System.Windows.Forms.Label();
			this.label22 = new System.Windows.Forms.Label();
			this.label21 = new System.Windows.Forms.Label();
			this.lb_prduct_other = new System.Windows.Forms.Label();
			this.lb_box_other = new System.Windows.Forms.Label();
			this.lb_box_fragile = new System.Windows.Forms.Label();
			this.lb_Product_cnt_fragile = new System.Windows.Forms.Label();
			this.lb_box_ice = new System.Windows.Forms.Label();
			this.lb_Product_cnt_ice = new System.Windows.Forms.Label();
			this.label16 = new System.Windows.Forms.Label();
			this.label15 = new System.Windows.Forms.Label();
			this.label14 = new System.Windows.Forms.Label();
			this.lb_Product_cnt = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.lb_show = new System.Windows.Forms.Label();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.label38 = new System.Windows.Forms.Label();
			this.label40 = new System.Windows.Forms.Label();
			this.label41 = new System.Windows.Forms.Label();
			this.groupBox6 = new System.Windows.Forms.GroupBox();
			this.groupBox7 = new System.Windows.Forms.GroupBox();
			this.groupBox8 = new System.Windows.Forms.GroupBox();
			this.groupBox9 = new System.Windows.Forms.GroupBox();
			this.groupBox10 = new System.Windows.Forms.GroupBox();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.panel_main.SuspendLayout();
			this.panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.panel_tag.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.groupBox5.SuspendLayout();
			this.groupBox6.SuspendLayout();
			this.groupBox7.SuspendLayout();
			this.groupBox8.SuspendLayout();
			this.groupBox9.SuspendLayout();
			this.groupBox10.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.lb_ComPort);
			this.groupBox1.Location = new System.Drawing.Point(102, 123);
			this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.groupBox1.Size = new System.Drawing.Size(94, 101);
			this.groupBox1.TabIndex = 24;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Com Port";
			// 
			// lb_ComPort
			// 
			this.lb_ComPort.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lb_ComPort.AutoSize = true;
			this.lb_ComPort.Font = new System.Drawing.Font("굴림", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.lb_ComPort.Location = new System.Drawing.Point(15, 44);
			this.lb_ComPort.Name = "lb_ComPort";
			this.lb_ComPort.Size = new System.Drawing.Size(56, 22);
			this.lb_ComPort.TabIndex = 0;
			this.lb_ComPort.Text = "OFF";
			this.lb_ComPort.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// btn_OpenPort
			// 
			this.btn_OpenPort.Location = new System.Drawing.Point(18, 131);
			this.btn_OpenPort.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btn_OpenPort.Name = "btn_OpenPort";
			this.btn_OpenPort.Size = new System.Drawing.Size(78, 28);
			this.btn_OpenPort.TabIndex = 22;
			this.btn_OpenPort.Text = "Open Port";
			this.btn_OpenPort.UseVisualStyleBackColor = true;
			this.btn_OpenPort.Click += new System.EventHandler(this.btn_OpenPort_Click);
			// 
			// progressBar_PortStatus
			// 
			this.progressBar_PortStatus.Location = new System.Drawing.Point(90, 84);
			this.progressBar_PortStatus.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.progressBar_PortStatus.Name = "progressBar_PortStatus";
			this.progressBar_PortStatus.Size = new System.Drawing.Size(106, 18);
			this.progressBar_PortStatus.TabIndex = 21;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(16, 86);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(66, 12);
			this.label3.TabIndex = 18;
			this.label3.Text = "Port Status";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(32, 55);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(27, 12);
			this.label2.TabIndex = 19;
			this.label2.Text = "Bps";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(32, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(27, 12);
			this.label1.TabIndex = 20;
			this.label1.Text = "Port";
			// 
			// cb_Bps
			// 
			this.cb_Bps.FormattingEnabled = true;
			this.cb_Bps.Items.AddRange(new object[] {
            "9600",
            "115200"});
			this.cb_Bps.Location = new System.Drawing.Point(90, 52);
			this.cb_Bps.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.cb_Bps.Name = "cb_Bps";
			this.cb_Bps.Size = new System.Drawing.Size(106, 20);
			this.cb_Bps.TabIndex = 16;
			// 
			// cb_Port
			// 
			this.cb_Port.FormattingEnabled = true;
			this.cb_Port.Location = new System.Drawing.Point(90, 21);
			this.cb_Port.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.cb_Port.Name = "cb_Port";
			this.cb_Port.Size = new System.Drawing.Size(106, 20);
			this.cb_Port.TabIndex = 17;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.tb_ReceiveData);
			this.groupBox2.Location = new System.Drawing.Point(18, 244);
			this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.groupBox2.Size = new System.Drawing.Size(178, 138);
			this.groupBox2.TabIndex = 25;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Receive Data";
			// 
			// tb_ReceiveData
			// 
			this.tb_ReceiveData.Location = new System.Drawing.Point(6, 18);
			this.tb_ReceiveData.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.tb_ReceiveData.Multiline = true;
			this.tb_ReceiveData.Name = "tb_ReceiveData";
			this.tb_ReceiveData.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.tb_ReceiveData.Size = new System.Drawing.Size(166, 111);
			this.tb_ReceiveData.TabIndex = 0;
			// 
			// btn_ClosePort
			// 
			this.btn_ClosePort.Location = new System.Drawing.Point(18, 195);
			this.btn_ClosePort.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btn_ClosePort.Name = "btn_ClosePort";
			this.btn_ClosePort.Size = new System.Drawing.Size(78, 28);
			this.btn_ClosePort.TabIndex = 23;
			this.btn_ClosePort.Text = "Close Port";
			this.btn_ClosePort.UseVisualStyleBackColor = true;
			this.btn_ClosePort.Click += new System.EventHandler(this.btn_ClosePort_Click);
			// 
			// serialPort1
			// 
			this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
			// 
			// panel_main
			// 
			this.panel_main.Controls.Add(this.listView_sawon);
			this.panel_main.Controls.Add(this.checkBox1);
			this.panel_main.Controls.Add(this.panel2);
			this.panel_main.Controls.Add(this.lb_show);
			this.panel_main.Location = new System.Drawing.Point(216, 52);
			this.panel_main.Name = "panel_main";
			this.panel_main.Size = new System.Drawing.Size(548, 330);
			this.panel_main.TabIndex = 27;
			// 
			// listView_sawon
			// 
			this.listView_sawon.FullRowSelect = true;
			this.listView_sawon.HideSelection = false;
			this.listView_sawon.Location = new System.Drawing.Point(222, 31);
			this.listView_sawon.Name = "listView_sawon";
			this.listView_sawon.Size = new System.Drawing.Size(309, 290);
			this.listView_sawon.TabIndex = 1;
			this.listView_sawon.UseCompatibleStateImageBehavior = false;
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.SystemColors.InactiveCaption;
			this.panel2.Controls.Add(this.lb_CarNum);
			this.panel2.Controls.Add(this.lb_Name);
			this.panel2.Controls.Add(this.label6);
			this.panel2.Controls.Add(this.label5);
			this.panel2.Location = new System.Drawing.Point(12, 31);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(204, 289);
			this.panel2.TabIndex = 0;
			// 
			// lb_CarNum
			// 
			this.lb_CarNum.AutoSize = true;
			this.lb_CarNum.Font = new System.Drawing.Font("굴림", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.lb_CarNum.Location = new System.Drawing.Point(34, 241);
			this.lb_CarNum.Name = "lb_CarNum";
			this.lb_CarNum.Size = new System.Drawing.Size(112, 27);
			this.lb_CarNum.TabIndex = 3;
			this.lb_CarNum.Text = "CarNum";
			// 
			// lb_Name
			// 
			this.lb_Name.AutoSize = true;
			this.lb_Name.Font = new System.Drawing.Font("굴림", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.lb_Name.Location = new System.Drawing.Point(53, 177);
			this.lb_Name.Name = "lb_Name";
			this.lb_Name.Size = new System.Drawing.Size(84, 27);
			this.lb_Name.TabIndex = 2;
			this.lb_Name.Text = "Name";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.label6.Location = new System.Drawing.Point(34, 223);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(82, 15);
			this.label6.TabIndex = 1;
			this.label6.Text = "Car Number";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.label5.Location = new System.Drawing.Point(34, 159);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(43, 15);
			this.label5.TabIndex = 1;
			this.label5.Text = "Name";
			// 
			// tb_barcode4
			// 
			this.tb_barcode4.Location = new System.Drawing.Point(69, 496);
			this.tb_barcode4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.tb_barcode4.Name = "tb_barcode4";
			this.tb_barcode4.Size = new System.Drawing.Size(278, 21);
			this.tb_barcode4.TabIndex = 33;
			this.tb_barcode4.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tb_barcode4_KeyUp);
			// 
			// cb_location
			// 
			this.cb_location.FormattingEnabled = true;
			this.cb_location.Items.AddRange(new object[] {
            "입고장",
            "출고장1",
            "출고장2"});
			this.cb_location.Location = new System.Drawing.Point(252, 17);
			this.cb_location.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.cb_location.Name = "cb_location";
			this.cb_location.Size = new System.Drawing.Size(106, 20);
			this.cb_location.TabIndex = 31;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(214, 21);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(29, 12);
			this.label4.TabIndex = 32;
			this.label4.Text = "위치";
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(10, 23);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(542, 299);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox1.TabIndex = 26;
			this.pictureBox1.TabStop = false;
			// 
			// panel_tag
			// 
			this.panel_tag.Controls.Add(this.pictureBox1);
			this.panel_tag.Location = new System.Drawing.Point(203, 52);
			this.panel_tag.Name = "panel_tag";
			this.panel_tag.Size = new System.Drawing.Size(561, 342);
			this.panel_tag.TabIndex = 29;
			// 
			// textBox5
			// 
			this.textBox5.Location = new System.Drawing.Point(69, 527);
			this.textBox5.Name = "textBox5";
			this.textBox5.Size = new System.Drawing.Size(278, 21);
			this.textBox5.TabIndex = 46;
			// 
			// tb_barcode3
			// 
			this.tb_barcode3.Location = new System.Drawing.Point(69, 465);
			this.tb_barcode3.Name = "tb_barcode3";
			this.tb_barcode3.Size = new System.Drawing.Size(278, 21);
			this.tb_barcode3.TabIndex = 47;
			this.tb_barcode3.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tb_barcode3_KeyUp);
			// 
			// tb_barcode1
			// 
			this.tb_barcode1.Location = new System.Drawing.Point(69, 411);
			this.tb_barcode1.Name = "tb_barcode1";
			this.tb_barcode1.Size = new System.Drawing.Size(278, 21);
			this.tb_barcode1.TabIndex = 44;
			this.tb_barcode1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tb_barcode1_KeyUp);
			// 
			// tb_barcode2
			// 
			this.tb_barcode2.Location = new System.Drawing.Point(69, 438);
			this.tb_barcode2.Name = "tb_barcode2";
			this.tb_barcode2.Size = new System.Drawing.Size(278, 21);
			this.tb_barcode2.TabIndex = 45;
			this.tb_barcode2.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tb_barcode2_KeyUp);
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(16, 414);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(47, 12);
			this.label7.TabIndex = 48;
			this.label7.Text = "바코드1";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(16, 441);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(47, 12);
			this.label8.TabIndex = 48;
			this.label8.Text = "바코드2";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(16, 530);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(29, 12);
			this.label9.TabIndex = 48;
			this.label9.Text = "기타";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(16, 499);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(47, 12);
			this.label10.TabIndex = 49;
			this.label10.Text = "바코드4";
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(16, 474);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(47, 12);
			this.label11.TabIndex = 49;
			this.label11.Text = "바코드3";
			// 
			// label33
			// 
			this.label33.AutoSize = true;
			this.label33.Location = new System.Drawing.Point(48, 26);
			this.label33.Name = "label33";
			this.label33.Size = new System.Drawing.Size(9, 12);
			this.label33.TabIndex = 19;
			this.label33.Text = ".";
			// 
			// label34
			// 
			this.label34.AutoSize = true;
			this.label34.Location = new System.Drawing.Point(24, 26);
			this.label34.Name = "label34";
			this.label34.Size = new System.Drawing.Size(9, 12);
			this.label34.TabIndex = 18;
			this.label34.Text = ".";
			// 
			// label29
			// 
			this.label29.AutoSize = true;
			this.label29.Location = new System.Drawing.Point(48, 38);
			this.label29.Name = "label29";
			this.label29.Size = new System.Drawing.Size(9, 12);
			this.label29.TabIndex = 17;
			this.label29.Text = ".";
			// 
			// label30
			// 
			this.label30.AutoSize = true;
			this.label30.Location = new System.Drawing.Point(24, 38);
			this.label30.Name = "label30";
			this.label30.Size = new System.Drawing.Size(9, 12);
			this.label30.TabIndex = 16;
			this.label30.Text = ".";
			// 
			// label31
			// 
			this.label31.AutoSize = true;
			this.label31.Location = new System.Drawing.Point(48, 20);
			this.label31.Name = "label31";
			this.label31.Size = new System.Drawing.Size(9, 12);
			this.label31.TabIndex = 15;
			this.label31.Text = ".";
			// 
			// label32
			// 
			this.label32.AutoSize = true;
			this.label32.Location = new System.Drawing.Point(24, 19);
			this.label32.Name = "label32";
			this.label32.Size = new System.Drawing.Size(9, 12);
			this.label32.TabIndex = 14;
			this.label32.Text = ".";
			// 
			// label28
			// 
			this.label28.AutoSize = true;
			this.label28.Location = new System.Drawing.Point(110, 40);
			this.label28.Name = "label28";
			this.label28.Size = new System.Drawing.Size(9, 12);
			this.label28.TabIndex = 13;
			this.label28.Text = ".";
			// 
			// label27
			// 
			this.label27.AutoSize = true;
			this.label27.Location = new System.Drawing.Point(88, 40);
			this.label27.Name = "label27";
			this.label27.Size = new System.Drawing.Size(9, 12);
			this.label27.TabIndex = 12;
			this.label27.Text = ".";
			// 
			// label26
			// 
			this.label26.AutoSize = true;
			this.label26.Location = new System.Drawing.Point(110, 20);
			this.label26.Name = "label26";
			this.label26.Size = new System.Drawing.Size(9, 12);
			this.label26.TabIndex = 11;
			this.label26.Text = ".";
			// 
			// label25
			// 
			this.label25.AutoSize = true;
			this.label25.Location = new System.Drawing.Point(88, 20);
			this.label25.Name = "label25";
			this.label25.Size = new System.Drawing.Size(9, 12);
			this.label25.TabIndex = 10;
			this.label25.Text = ".";
			// 
			// label24
			// 
			this.label24.AutoSize = true;
			this.label24.Location = new System.Drawing.Point(48, 40);
			this.label24.Name = "label24";
			this.label24.Size = new System.Drawing.Size(9, 12);
			this.label24.TabIndex = 9;
			this.label24.Text = ".";
			// 
			// label23
			// 
			this.label23.AutoSize = true;
			this.label23.Location = new System.Drawing.Point(24, 40);
			this.label23.Name = "label23";
			this.label23.Size = new System.Drawing.Size(9, 12);
			this.label23.TabIndex = 8;
			this.label23.Text = ".";
			// 
			// label22
			// 
			this.label22.AutoSize = true;
			this.label22.Location = new System.Drawing.Point(48, 20);
			this.label22.Name = "label22";
			this.label22.Size = new System.Drawing.Size(9, 12);
			this.label22.TabIndex = 7;
			this.label22.Text = ".";
			// 
			// label21
			// 
			this.label21.AutoSize = true;
			this.label21.Location = new System.Drawing.Point(24, 20);
			this.label21.Name = "label21";
			this.label21.Size = new System.Drawing.Size(9, 12);
			this.label21.TabIndex = 6;
			this.label21.Text = ".";
			// 
			// lb_prduct_other
			// 
			this.lb_prduct_other.AutoSize = true;
			this.lb_prduct_other.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.lb_prduct_other.Location = new System.Drawing.Point(181, 47);
			this.lb_prduct_other.Name = "lb_prduct_other";
			this.lb_prduct_other.Size = new System.Drawing.Size(15, 13);
			this.lb_prduct_other.TabIndex = 4;
			this.lb_prduct_other.Text = "0";
			// 
			// lb_box_other
			// 
			this.lb_box_other.AutoSize = true;
			this.lb_box_other.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.lb_box_other.Location = new System.Drawing.Point(181, 50);
			this.lb_box_other.Name = "lb_box_other";
			this.lb_box_other.Size = new System.Drawing.Size(15, 13);
			this.lb_box_other.TabIndex = 4;
			this.lb_box_other.Text = "0";
			// 
			// lb_box_fragile
			// 
			this.lb_box_fragile.AutoSize = true;
			this.lb_box_fragile.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.lb_box_fragile.Location = new System.Drawing.Point(117, 50);
			this.lb_box_fragile.Name = "lb_box_fragile";
			this.lb_box_fragile.Size = new System.Drawing.Size(15, 13);
			this.lb_box_fragile.TabIndex = 4;
			this.lb_box_fragile.Text = "0";
			// 
			// lb_Product_cnt_fragile
			// 
			this.lb_Product_cnt_fragile.AutoSize = true;
			this.lb_Product_cnt_fragile.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.lb_Product_cnt_fragile.Location = new System.Drawing.Point(117, 47);
			this.lb_Product_cnt_fragile.Name = "lb_Product_cnt_fragile";
			this.lb_Product_cnt_fragile.Size = new System.Drawing.Size(15, 13);
			this.lb_Product_cnt_fragile.TabIndex = 4;
			this.lb_Product_cnt_fragile.Text = "0";
			// 
			// lb_box_ice
			// 
			this.lb_box_ice.AutoSize = true;
			this.lb_box_ice.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.lb_box_ice.Location = new System.Drawing.Point(44, 50);
			this.lb_box_ice.Name = "lb_box_ice";
			this.lb_box_ice.Size = new System.Drawing.Size(15, 13);
			this.lb_box_ice.TabIndex = 4;
			this.lb_box_ice.Text = "0";
			// 
			// lb_Product_cnt_ice
			// 
			this.lb_Product_cnt_ice.AutoSize = true;
			this.lb_Product_cnt_ice.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.lb_Product_cnt_ice.Location = new System.Drawing.Point(44, 47);
			this.lb_Product_cnt_ice.Name = "lb_Product_cnt_ice";
			this.lb_Product_cnt_ice.Size = new System.Drawing.Size(15, 13);
			this.lb_Product_cnt_ice.TabIndex = 4;
			this.lb_Product_cnt_ice.Text = "0";
			// 
			// label16
			// 
			this.label16.AutoSize = true;
			this.label16.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.label16.Location = new System.Drawing.Point(166, 23);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(49, 13);
			this.label16.TabIndex = 3;
			this.label16.Text = "나머지";
			// 
			// label15
			// 
			this.label15.AutoSize = true;
			this.label15.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.label15.Location = new System.Drawing.Point(95, 23);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(63, 13);
			this.label15.TabIndex = 3;
			this.label15.Text = "취급주의";
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.label14.Location = new System.Drawing.Point(14, 23);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(77, 13);
			this.label14.TabIndex = 3;
			this.label14.Text = "아이스박스";
			// 
			// lb_Product_cnt
			// 
			this.lb_Product_cnt.AutoSize = true;
			this.lb_Product_cnt.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.lb_Product_cnt.Location = new System.Drawing.Point(115, 26);
			this.lb_Product_cnt.Name = "lb_Product_cnt";
			this.lb_Product_cnt.Size = new System.Drawing.Size(17, 16);
			this.lb_Product_cnt.TabIndex = 2;
			this.lb_Product_cnt.Text = "0";
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.label13.Location = new System.Drawing.Point(6, 26);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(99, 16);
			this.label13.TabIndex = 1;
			this.label13.Text = "총 물품개수";
			// 
			// lb_show
			// 
			this.lb_show.AutoSize = true;
			this.lb_show.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.lb_show.Location = new System.Drawing.Point(298, 7);
			this.lb_show.Name = "lb_show";
			this.lb_show.Size = new System.Drawing.Size(219, 16);
			this.lb_show.TabIndex = 0;
			this.lb_show.Text = "최적화 적재 방법 제시 보기";
			this.lb_show.Visible = false;
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.groupBox5);
			this.groupBox3.Controls.Add(this.groupBox4);
			this.groupBox3.Controls.Add(this.label13);
			this.groupBox3.Controls.Add(this.lb_Product_cnt);
			this.groupBox3.Location = new System.Drawing.Point(11, 18);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(251, 255);
			this.groupBox3.TabIndex = 0;
			this.groupBox3.TabStop = false;
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.label16);
			this.groupBox4.Controls.Add(this.lb_prduct_other);
			this.groupBox4.Controls.Add(this.label14);
			this.groupBox4.Controls.Add(this.label15);
			this.groupBox4.Controls.Add(this.lb_Product_cnt_fragile);
			this.groupBox4.Controls.Add(this.lb_Product_cnt_ice);
			this.groupBox4.Location = new System.Drawing.Point(10, 70);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(230, 76);
			this.groupBox4.TabIndex = 3;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "세부 분류";
			// 
			// groupBox5
			// 
			this.groupBox5.Controls.Add(this.label38);
			this.groupBox5.Controls.Add(this.label40);
			this.groupBox5.Controls.Add(this.label41);
			this.groupBox5.Controls.Add(this.lb_box_ice);
			this.groupBox5.Controls.Add(this.lb_box_fragile);
			this.groupBox5.Controls.Add(this.lb_box_other);
			this.groupBox5.Location = new System.Drawing.Point(10, 167);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(230, 76);
			this.groupBox5.TabIndex = 3;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "박스 개수 제안";
			// 
			// label38
			// 
			this.label38.AutoSize = true;
			this.label38.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.label38.Location = new System.Drawing.Point(166, 23);
			this.label38.Name = "label38";
			this.label38.Size = new System.Drawing.Size(49, 13);
			this.label38.TabIndex = 3;
			this.label38.Text = "나머지";
			// 
			// label40
			// 
			this.label40.AutoSize = true;
			this.label40.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.label40.Location = new System.Drawing.Point(14, 23);
			this.label40.Name = "label40";
			this.label40.Size = new System.Drawing.Size(77, 13);
			this.label40.TabIndex = 3;
			this.label40.Text = "아이스박스";
			// 
			// label41
			// 
			this.label41.AutoSize = true;
			this.label41.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.label41.Location = new System.Drawing.Point(95, 23);
			this.label41.Name = "label41";
			this.label41.Size = new System.Drawing.Size(63, 13);
			this.label41.TabIndex = 3;
			this.label41.Text = "취급주의";
			// 
			// groupBox6
			// 
			this.groupBox6.Controls.Add(this.label21);
			this.groupBox6.Controls.Add(this.label22);
			this.groupBox6.Controls.Add(this.label23);
			this.groupBox6.Controls.Add(this.label24);
			this.groupBox6.Controls.Add(this.label25);
			this.groupBox6.Controls.Add(this.label27);
			this.groupBox6.Controls.Add(this.label26);
			this.groupBox6.Controls.Add(this.label28);
			this.groupBox6.Location = new System.Drawing.Point(6, 26);
			this.groupBox6.Name = "groupBox6";
			this.groupBox6.Size = new System.Drawing.Size(140, 65);
			this.groupBox6.TabIndex = 1;
			this.groupBox6.TabStop = false;
			this.groupBox6.Text = "8박스";
			// 
			// groupBox7
			// 
			this.groupBox7.Controls.Add(this.label32);
			this.groupBox7.Controls.Add(this.label30);
			this.groupBox7.Controls.Add(this.label31);
			this.groupBox7.Controls.Add(this.label29);
			this.groupBox7.Location = new System.Drawing.Point(6, 98);
			this.groupBox7.Name = "groupBox7";
			this.groupBox7.Size = new System.Drawing.Size(140, 65);
			this.groupBox7.TabIndex = 1;
			this.groupBox7.TabStop = false;
			this.groupBox7.Text = "4박스";
			// 
			// groupBox8
			// 
			this.groupBox8.Controls.Add(this.label33);
			this.groupBox8.Controls.Add(this.label34);
			this.groupBox8.Location = new System.Drawing.Point(6, 177);
			this.groupBox8.Name = "groupBox8";
			this.groupBox8.Size = new System.Drawing.Size(140, 65);
			this.groupBox8.TabIndex = 1;
			this.groupBox8.TabStop = false;
			this.groupBox8.Text = "2박스";
			// 
			// groupBox9
			// 
			this.groupBox9.Controls.Add(this.groupBox10);
			this.groupBox9.Controls.Add(this.groupBox3);
			this.groupBox9.Location = new System.Drawing.Point(771, 77);
			this.groupBox9.Name = "groupBox9";
			this.groupBox9.Size = new System.Drawing.Size(432, 273);
			this.groupBox9.TabIndex = 54;
			this.groupBox9.TabStop = false;
			// 
			// groupBox10
			// 
			this.groupBox10.Controls.Add(this.groupBox8);
			this.groupBox10.Controls.Add(this.groupBox6);
			this.groupBox10.Controls.Add(this.groupBox7);
			this.groupBox10.Location = new System.Drawing.Point(268, 18);
			this.groupBox10.Name = "groupBox10";
			this.groupBox10.Size = new System.Drawing.Size(153, 255);
			this.groupBox10.TabIndex = 1;
			this.groupBox10.TabStop = false;
			// 
			// checkBox1
			// 
			this.checkBox1.AutoSize = true;
			this.checkBox1.Location = new System.Drawing.Point(517, 9);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(15, 14);
			this.checkBox1.TabIndex = 55;
			this.checkBox1.UseVisualStyleBackColor = true;
			this.checkBox1.Visible = false;
			this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
			// 
			// rfid
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(769, 402);
			this.Controls.Add(this.groupBox9);
			this.Controls.Add(this.label11);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.textBox5);
			this.Controls.Add(this.tb_barcode4);
			this.Controls.Add(this.tb_barcode3);
			this.Controls.Add(this.tb_barcode1);
			this.Controls.Add(this.tb_barcode2);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.cb_location);
			this.Controls.Add(this.panel_tag);
			this.Controls.Add(this.panel_main);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.btn_OpenPort);
			this.Controls.Add(this.progressBar_PortStatus);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.cb_Bps);
			this.Controls.Add(this.cb_Port);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.btn_ClosePort);
			this.KeyPreview = true;
			this.Name = "rfid";
			this.Text = "RFID";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
			this.Load += new System.EventHandler(this.Form1_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.panel_main.ResumeLayout(false);
			this.panel_main.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.panel_tag.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.groupBox4.ResumeLayout(false);
			this.groupBox4.PerformLayout();
			this.groupBox5.ResumeLayout(false);
			this.groupBox5.PerformLayout();
			this.groupBox6.ResumeLayout(false);
			this.groupBox6.PerformLayout();
			this.groupBox7.ResumeLayout(false);
			this.groupBox7.PerformLayout();
			this.groupBox8.ResumeLayout(false);
			this.groupBox8.PerformLayout();
			this.groupBox9.ResumeLayout(false);
			this.groupBox10.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label lb_ComPort;
		private System.Windows.Forms.Button btn_OpenPort;
		private System.Windows.Forms.ProgressBar progressBar_PortStatus;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox cb_Bps;
		private System.Windows.Forms.ComboBox cb_Port;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.TextBox tb_ReceiveData;
		private System.Windows.Forms.Button btn_ClosePort;
		private System.IO.Ports.SerialPort serialPort1;
		private System.Windows.Forms.Panel panel_main;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.ListView listView_sawon;
		private System.Windows.Forms.Label lb_CarNum;
		private System.Windows.Forms.Label lb_Name;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.ComboBox cb_location;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox tb_barcode4;
		public System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Panel panel_tag;
		private System.Windows.Forms.TextBox textBox5;
		private System.Windows.Forms.TextBox tb_barcode3;
		private System.Windows.Forms.TextBox tb_barcode1;
		private System.Windows.Forms.TextBox tb_barcode2;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label33;
		private System.Windows.Forms.Label label34;
		private System.Windows.Forms.Label label29;
		private System.Windows.Forms.Label label30;
		private System.Windows.Forms.Label label31;
		private System.Windows.Forms.Label label32;
		private System.Windows.Forms.Label label28;
		private System.Windows.Forms.Label label27;
		private System.Windows.Forms.Label label26;
		private System.Windows.Forms.Label label25;
		private System.Windows.Forms.Label label24;
		private System.Windows.Forms.Label label23;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.Label lb_prduct_other;
		private System.Windows.Forms.Label lb_box_other;
		private System.Windows.Forms.Label lb_box_fragile;
		private System.Windows.Forms.Label lb_Product_cnt_fragile;
		private System.Windows.Forms.Label lb_box_ice;
		private System.Windows.Forms.Label lb_Product_cnt_ice;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label lb_Product_cnt;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label lb_show;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.GroupBox groupBox7;
		private System.Windows.Forms.GroupBox groupBox6;
		private System.Windows.Forms.GroupBox groupBox5;
		private System.Windows.Forms.Label label38;
		private System.Windows.Forms.Label label40;
		private System.Windows.Forms.Label label41;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.GroupBox groupBox8;
		private System.Windows.Forms.GroupBox groupBox9;
		private System.Windows.Forms.GroupBox groupBox10;
		private System.Windows.Forms.CheckBox checkBox1;
	}
}

