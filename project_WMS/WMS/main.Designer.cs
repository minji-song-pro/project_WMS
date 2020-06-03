namespace WMS
{
	partial class main
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
			this.btn_wms = new System.Windows.Forms.Button();
			this.btn_rfid = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// btn_wms
			// 
			this.btn_wms.Font = new System.Drawing.Font("AmeriGarmnd BT", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_wms.Location = new System.Drawing.Point(402, 146);
			this.btn_wms.Name = "btn_wms";
			this.btn_wms.Size = new System.Drawing.Size(335, 407);
			this.btn_wms.TabIndex = 0;
			this.btn_wms.Text = "WMS";
			this.btn_wms.UseVisualStyleBackColor = true;
			this.btn_wms.Click += new System.EventHandler(this.btn_wms_Click);
			// 
			// btn_rfid
			// 
			this.btn_rfid.Font = new System.Drawing.Font("AmeriGarmnd BT", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_rfid.Location = new System.Drawing.Point(35, 146);
			this.btn_rfid.Name = "btn_rfid";
			this.btn_rfid.Size = new System.Drawing.Size(339, 407);
			this.btn_rfid.TabIndex = 0;
			this.btn_rfid.Text = "RFID";
			this.btn_rfid.UseVisualStyleBackColor = true;
			this.btn_rfid.Click += new System.EventHandler(this.btn_rfid_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("굴림", 27.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.label1.Location = new System.Drawing.Point(266, 58);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(607, 37);
			this.label1.TabIndex = 10;
			this.label1.Text = "Warehouse Management System";
			// 
			// button1
			// 
			this.button1.Font = new System.Drawing.Font("AmeriGarmnd BT", 20.25F, System.Drawing.FontStyle.Bold);
			this.button1.Location = new System.Drawing.Point(763, 146);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(339, 407);
			this.button1.TabIndex = 11;
			this.button1.Text = "Sensor";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// main
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1138, 584);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btn_rfid);
			this.Controls.Add(this.btn_wms);
			this.Name = "main";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = " ";
			this.Load += new System.EventHandler(this.main_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btn_wms;
		private System.Windows.Forms.Button btn_rfid;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button button1;
	}
}

