namespace WMS
{
	partial class customer_order
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(customer_order));
			this.listView_stock = new System.Windows.Forms.ListView();
			this.cb_co_c_id = new System.Windows.Forms.ComboBox();
			this.tb_co_num = new System.Windows.Forms.TextBox();
			this.tb_co_p_id = new System.Windows.Forms.TextBox();
			this.tb_co_quntity = new System.Windows.Forms.TextBox();
			this.panel_customer_order = new System.Windows.Forms.Panel();
			this.label2 = new System.Windows.Forms.Label();
			this.lb_stock = new System.Windows.Forms.Label();
			this.btn_customer_order_OK = new System.Windows.Forms.Button();
			this.label42 = new System.Windows.Forms.Label();
			this.btn_customer_order = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label94 = new System.Windows.Forms.Label();
			this.label96 = new System.Windows.Forms.Label();
			this.button17 = new System.Windows.Forms.Button();
			this.label92 = new System.Windows.Forms.Label();
			this.label93 = new System.Windows.Forms.Label();
			this.label95 = new System.Windows.Forms.Label();
			this.listView1 = new System.Windows.Forms.ListView();
			this.listView_customer_ordering = new System.Windows.Forms.ListView();
			this.panel_customer_order.SuspendLayout();
			this.SuspendLayout();
			// 
			// listView_stock
			// 
			this.listView_stock.FullRowSelect = true;
			this.listView_stock.HideSelection = false;
			this.listView_stock.Location = new System.Drawing.Point(26, 127);
			this.listView_stock.Name = "listView_stock";
			this.listView_stock.Size = new System.Drawing.Size(195, 111);
			this.listView_stock.TabIndex = 45;
			this.listView_stock.UseCompatibleStateImageBehavior = false;
			this.listView_stock.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.listView_stock_DrawColumnHeader);
			this.listView_stock.DrawSubItem += new System.Windows.Forms.DrawListViewSubItemEventHandler(this.listView_stock_DrawSubItem);
			this.listView_stock.SelectedIndexChanged += new System.EventHandler(this.listView_stock_SelectedIndexChanged);
			// 
			// cb_co_c_id
			// 
			this.cb_co_c_id.FormattingEnabled = true;
			this.cb_co_c_id.Location = new System.Drawing.Point(411, 59);
			this.cb_co_c_id.Name = "cb_co_c_id";
			this.cb_co_c_id.Size = new System.Drawing.Size(100, 20);
			this.cb_co_c_id.TabIndex = 44;
			this.cb_co_c_id.Text = "1";
			this.cb_co_c_id.SelectedIndexChanged += new System.EventHandler(this.cb_co_c_id_SelectedIndexChanged);
			// 
			// tb_co_num
			// 
			this.tb_co_num.Enabled = false;
			this.tb_co_num.Location = new System.Drawing.Point(62, 59);
			this.tb_co_num.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.tb_co_num.Name = "tb_co_num";
			this.tb_co_num.Size = new System.Drawing.Size(100, 21);
			this.tb_co_num.TabIndex = 23;
			// 
			// tb_co_p_id
			// 
			this.tb_co_p_id.Location = new System.Drawing.Point(121, 252);
			this.tb_co_p_id.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.tb_co_p_id.Name = "tb_co_p_id";
			this.tb_co_p_id.Size = new System.Drawing.Size(100, 21);
			this.tb_co_p_id.TabIndex = 23;
			// 
			// tb_co_quntity
			// 
			this.tb_co_quntity.Location = new System.Drawing.Point(121, 283);
			this.tb_co_quntity.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.tb_co_quntity.Name = "tb_co_quntity";
			this.tb_co_quntity.Size = new System.Drawing.Size(100, 21);
			this.tb_co_quntity.TabIndex = 23;
			// 
			// panel_customer_order
			// 
			this.panel_customer_order.Controls.Add(this.listView_customer_ordering);
			this.panel_customer_order.Controls.Add(this.label2);
			this.panel_customer_order.Controls.Add(this.lb_stock);
			this.panel_customer_order.Controls.Add(this.btn_customer_order_OK);
			this.panel_customer_order.Controls.Add(this.label42);
			this.panel_customer_order.Controls.Add(this.btn_customer_order);
			this.panel_customer_order.Controls.Add(this.label1);
			this.panel_customer_order.Controls.Add(this.listView_stock);
			this.panel_customer_order.Controls.Add(this.label94);
			this.panel_customer_order.Controls.Add(this.label96);
			this.panel_customer_order.Controls.Add(this.tb_co_quntity);
			this.panel_customer_order.Controls.Add(this.tb_co_p_id);
			this.panel_customer_order.Controls.Add(this.label92);
			this.panel_customer_order.Controls.Add(this.label93);
			this.panel_customer_order.Controls.Add(this.cb_co_c_id);
			this.panel_customer_order.Controls.Add(this.label95);
			this.panel_customer_order.Controls.Add(this.tb_co_num);
			this.panel_customer_order.Controls.Add(this.listView1);
			this.panel_customer_order.Location = new System.Drawing.Point(32, 48);
			this.panel_customer_order.Name = "panel_customer_order";
			this.panel_customer_order.Size = new System.Drawing.Size(530, 412);
			this.panel_customer_order.TabIndex = 55;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.label2.Location = new System.Drawing.Point(233, 103);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(56, 16);
			this.label2.TabIndex = 58;
			this.label2.Text = "주문 목록";
			// 
			// lb_stock
			// 
			this.lb_stock.AutoSize = true;
			this.lb_stock.ForeColor = System.Drawing.Color.DarkRed;
			this.lb_stock.Location = new System.Drawing.Point(140, 308);
			this.lb_stock.Name = "lb_stock";
			this.lb_stock.Size = new System.Drawing.Size(11, 12);
			this.lb_stock.TabIndex = 47;
			this.lb_stock.Text = "0";
			// 
			// btn_customer_order_OK
			// 
			this.btn_customer_order_OK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(126)))), ((int)(((byte)(49)))));
			this.btn_customer_order_OK.FlatAppearance.BorderSize = 0;
			this.btn_customer_order_OK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn_customer_order_OK.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.btn_customer_order_OK.ForeColor = System.Drawing.Color.White;
			this.btn_customer_order_OK.Location = new System.Drawing.Point(235, 373);
			this.btn_customer_order_OK.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btn_customer_order_OK.Name = "btn_customer_order_OK";
			this.btn_customer_order_OK.Size = new System.Drawing.Size(61, 29);
			this.btn_customer_order_OK.TabIndex = 38;
			this.btn_customer_order_OK.Text = "완료";
			this.btn_customer_order_OK.UseVisualStyleBackColor = false;
			this.btn_customer_order_OK.Click += new System.EventHandler(this.btn_customer_order_OK_Click);
			// 
			// label42
			// 
			this.label42.AutoSize = true;
			this.label42.ForeColor = System.Drawing.Color.DarkRed;
			this.label42.Location = new System.Drawing.Point(28, 308);
			this.label42.Name = "label42";
			this.label42.Size = new System.Drawing.Size(83, 12);
			this.label42.TabIndex = 46;
			this.label42.Text = "*주문가능수량";
			// 
			// btn_customer_order
			// 
			this.btn_customer_order.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(126)))), ((int)(((byte)(49)))));
			this.btn_customer_order.FlatAppearance.BorderSize = 0;
			this.btn_customer_order.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn_customer_order.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.btn_customer_order.ForeColor = System.Drawing.Color.White;
			this.btn_customer_order.Location = new System.Drawing.Point(160, 322);
			this.btn_customer_order.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btn_customer_order.Name = "btn_customer_order";
			this.btn_customer_order.Size = new System.Drawing.Size(61, 29);
			this.btn_customer_order.TabIndex = 38;
			this.btn_customer_order.Text = "추가";
			this.btn_customer_order.UseVisualStyleBackColor = false;
			this.btn_customer_order.Click += new System.EventHandler(this.btn_customer_order_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.label1.Location = new System.Drawing.Point(14, 103);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(119, 16);
			this.label1.TabIndex = 56;
			this.label1.Text = "주문 가능한 제품 목록";
			// 
			// label94
			// 
			this.label94.AutoSize = true;
			this.label94.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.label94.Location = new System.Drawing.Point(27, 252);
			this.label94.Name = "label94";
			this.label94.Size = new System.Drawing.Size(52, 16);
			this.label94.TabIndex = 33;
			this.label94.Text = "제품코드";
			// 
			// label96
			// 
			this.label96.AutoSize = true;
			this.label96.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.label96.Location = new System.Drawing.Point(27, 285);
			this.label96.Name = "label96";
			this.label96.Size = new System.Drawing.Size(30, 16);
			this.label96.TabIndex = 32;
			this.label96.Text = "수량";
			// 
			// button17
			// 
			this.button17.FlatAppearance.BorderSize = 0;
			this.button17.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button17.Image = ((System.Drawing.Image)(resources.GetObject("button17.Image")));
			this.button17.Location = new System.Drawing.Point(561, 12);
			this.button17.Name = "button17";
			this.button17.Size = new System.Drawing.Size(19, 20);
			this.button17.TabIndex = 43;
			this.button17.UseVisualStyleBackColor = true;
			this.button17.Click += new System.EventHandler(this.button17_Click);
			// 
			// label92
			// 
			this.label92.AutoSize = true;
			this.label92.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label92.Location = new System.Drawing.Point(204, 6);
			this.label92.Name = "label92";
			this.label92.Size = new System.Drawing.Size(127, 31);
			this.label92.TabIndex = 6;
			this.label92.Text = "거래처 주문";
			// 
			// label93
			// 
			this.label93.AutoSize = true;
			this.label93.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.label93.Location = new System.Drawing.Point(14, 63);
			this.label93.Name = "label93";
			this.label93.Size = new System.Drawing.Size(30, 16);
			this.label93.TabIndex = 34;
			this.label93.Text = "순번";
			// 
			// label95
			// 
			this.label95.AutoSize = true;
			this.label95.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.label95.Location = new System.Drawing.Point(328, 63);
			this.label95.Name = "label95";
			this.label95.Size = new System.Drawing.Size(63, 16);
			this.label95.TabIndex = 32;
			this.label95.Text = "거래처코드";
			// 
			// listView1
			// 
			this.listView1.HideSelection = false;
			this.listView1.Location = new System.Drawing.Point(17, 120);
			this.listView1.Name = "listView1";
			this.listView1.Size = new System.Drawing.Size(213, 241);
			this.listView1.TabIndex = 57;
			this.listView1.UseCompatibleStateImageBehavior = false;
			// 
			// listView_customer_ordering
			// 
			this.listView_customer_ordering.HideSelection = false;
			this.listView_customer_ordering.Location = new System.Drawing.Point(236, 120);
			this.listView_customer_ordering.Name = "listView_customer_ordering";
			this.listView_customer_ordering.Size = new System.Drawing.Size(275, 241);
			this.listView_customer_ordering.TabIndex = 56;
			this.listView_customer_ordering.UseCompatibleStateImageBehavior = false;
			// 
			// customer_order
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(595, 472);
			this.Controls.Add(this.panel_customer_order);
			this.Controls.Add(this.button17);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "customer_order";
			this.Text = "customer_order";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.customer_order_FormClosed);
			this.Load += new System.EventHandler(this.customer_order_Load);
			this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.customer_order_MouseDown);
			this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.customer_order_MouseMove);
			this.panel_customer_order.ResumeLayout(false);
			this.panel_customer_order.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.ListView listView_stock;
		private System.Windows.Forms.ComboBox cb_co_c_id;
		private System.Windows.Forms.TextBox tb_co_num;
		private System.Windows.Forms.TextBox tb_co_p_id;
		private System.Windows.Forms.TextBox tb_co_quntity;
		private System.Windows.Forms.Panel panel_customer_order;
		private System.Windows.Forms.Button button17;
		private System.Windows.Forms.Button btn_customer_order_OK;
		private System.Windows.Forms.Label label92;
		private System.Windows.Forms.Label label93;
		private System.Windows.Forms.Label label94;
		private System.Windows.Forms.Label label95;
		private System.Windows.Forms.Label label96;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btn_customer_order;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ListView listView1;
		private System.Windows.Forms.Label lb_stock;
		private System.Windows.Forms.Label label42;
		private System.Windows.Forms.ListView listView_customer_ordering;
	}
}