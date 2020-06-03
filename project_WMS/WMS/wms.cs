using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WMS
{
	public partial class wms : Form
	{
		public wms()
		{
			InitializeComponent();
		}
		//폼이동 변수 선언
		private Point mousePoint;

		//전역변수 선언
		int co_num = 1;

		//DB변수 선언
		String strConn = "Server=10.10.15.154;Uid=user;Pwd=1234;Database=warehousedb;CHARSET=UTF8";
		MySqlConnection conn;
		MySqlCommand cmd;
		MySqlDataReader reader;

		private void wms_Load(object sender, EventArgs e)
		{
			conn = new MySqlConnection(strConn);
			conn.Open();
			cmd = new MySqlCommand("", conn);

			//거래처주문 num 부여
			try
			{
				//co_num
				string[] CONum = { };
				string sql = "select num from customer_order order by num desc limit 1";
				cmd.CommandText = sql;
				reader = cmd.ExecuteReader();
				while (reader.Read())
				{
					string num = reader["num"].ToString();
					Array.Resize(ref CONum, CONum.Length + 1);
					CONum[CONum.Length - 1] = num;
				}
				reader.Close();
				co_num = int.Parse(CONum[0]) + 1;
				//tb_co_num.Text = co_num.ToString();
			}
			catch
			{
				//tb_co_num.Text = co_num.ToString();
			}

			listview();
			combobox();
			timer1.Start();
		}

		private void wms_FormClosed(object sender, FormClosedEventArgs e)
		{
			conn.Close();
		}
		private void timer1_Tick(object sender, EventArgs e)
		{
			listview();
		}
		public void combobox() //콤보박스
		{
			//콤보박스에 채우기(p_id)
			cb_p_id_r.Items.Clear();
			cb_p_id_e.Items.Clear();
			cb_i_p_id_r.Items.Clear();
			string[] PIDNames = { };
			string sql = "SELECT p_id FROM product";
			cmd.CommandText = sql;
			reader = cmd.ExecuteReader();
			while (reader.Read())
			{
				string p_id = (string)reader["p_id"];
				Array.Resize(ref PIDNames, PIDNames.Length + 1);
				PIDNames[PIDNames.Length - 1] = p_id;
			}
			reader.Close();

			cb_p_id_r.Items.AddRange(PIDNames);
			cb_p_id_e.Items.AddRange(PIDNames);
			cb_i_p_id_r.Items.AddRange(PIDNames);

			//콤보박스에 채우기(e_id)
			cb_o_e_id.Items.Clear();
			cb_i_e_id_e.Items.Clear();
			cb_i_e_id_r.Items.Clear();
			string[] EIDNames = { };
			sql = "SELECT e_id FROM employee";
			cmd.CommandText = sql;
			reader = cmd.ExecuteReader();
			while (reader.Read())
			{
				string e_id = (string)reader["e_id"];
				Array.Resize(ref EIDNames, EIDNames.Length + 1);
				EIDNames[EIDNames.Length - 1] = e_id;
			}
			reader.Close();

			cb_o_e_id.Items.AddRange(EIDNames);
			cb_o_u_e_id.Items.AddRange(EIDNames);
			cb_i_e_id_e.Items.AddRange(EIDNames);
			cb_i_e_id_r.Items.AddRange(EIDNames);

			//콤보박스에 채우기(c_id)
			cb_o_c_id.Items.Clear();
			string[] CIDNames = { };
			sql = "SELECT c_id FROM customer";
			cmd.CommandText = sql;
			reader = cmd.ExecuteReader();
			while (reader.Read())
			{
				string c_id = reader["c_id"].ToString();
				Array.Resize(ref CIDNames, CIDNames.Length + 1);
				CIDNames[CIDNames.Length - 1] = c_id;
			}
			reader.Close();

			cb_o_c_id.Items.AddRange(CIDNames);
		}
		public void listview() //리스트뷰
		{

			//리스트뷰 행 전체 선택 --> listView_product.FullRowSelect = true

			///////////////////////////////////////////////////////////////////////////////////////////
			///생산품 리스트뷰 설정////////////////////////////////////////////////////////////////////
			//////////////////////////////////////////////////////////////////////////////////////////
			listView_real_product.Clear();
			listView_real_product.BeginUpdate(); //리스트뷰 업데이트 시작
			listView_real_product.View = View.Details;
			listView_real_product.Columns.Add("", 0, HorizontalAlignment.Center);
			listView_real_product.Columns.Add("생산품바코드번호", 130, HorizontalAlignment.Center);
			listView_real_product.Columns.Add("제품코드", 80, HorizontalAlignment.Center);
			listView_real_product.Columns.Add("제품명", 80, HorizontalAlignment.Center);
			listView_real_product.Columns.Add("제조일자", 130, HorizontalAlignment.Center);
			listView_real_product.Columns.Add("유통기한", 80, HorizontalAlignment.Center);
			listView_real_product.Columns.Add("물류상태", 80, HorizontalAlignment.Center);

			//생산품 데이터 조회 쿼리
			string r_barcode, p_id, p_name, r_MFD, r_EXP, r_status;
			String sql = "SELECT r_barcode, r.p_id, p_name, r_MFD, r_EXP, r_status FROM real_product r inner join product p on r.p_id=p.p_id";
			cmd.CommandText = sql;
			reader = cmd.ExecuteReader();
			ListViewItem item;
			
			while (reader.Read())
			{
				r_barcode = reader["r_barcode"].ToString();
				p_id = reader["p_id"].ToString();
				p_name = reader["p_name"].ToString();
				r_MFD = reader["r_MFD"].ToString();
				r_EXP = reader["r_EXP"].ToString();
				r_status = reader["r_status"].ToString();

				item = new ListViewItem();
				item.SubItems.Add(r_barcode);
				item.SubItems.Add(p_id);
				item.SubItems.Add(p_name);
				item.SubItems.Add(r_MFD);
				item.SubItems.Add(r_EXP);
				item.SubItems.Add(r_status);

				listView_real_product.Items.Add(item);
			}
			reader.Close();
			listView_real_product.EndUpdate();

			///////////////////////////////////////////////////////////////////////////////////////////
			///거래처주문 리스트뷰 설정////////////////////////////////////////////////////////////////
			//////////////////////////////////////////////////////////////////////////////////////////
			listView_customer_ordering.Clear();
			listView_customer_ordering.BeginUpdate(); //리스트뷰 업데이트 시작
			listView_customer_ordering.View = View.Details;
			listView_customer_ordering.Columns.Add("", 0, HorizontalAlignment.Center);
			listView_customer_ordering.Columns.Add("주문번호", 130, HorizontalAlignment.Center);
			listView_customer_ordering.Columns.Add("제품코드", 130, HorizontalAlignment.Center);
			listView_customer_ordering.Columns.Add("제품명", 130, HorizontalAlignment.Center);
			listView_customer_ordering.Columns.Add("수량", 130, HorizontalAlignment.Center);
			listView_customer_ordering.Columns.Add("거래처코드", 130, HorizontalAlignment.Center);

			//거래처주문 데이터 조회 쿼리
			string co_num, co_p_id, co_p_name, co_quntity, co_c_id;
			sql = "SELECT num, co.p_id, p.p_name, co_quntity,c_id FROM customer_order co inner join product p on co.p_id=p.p_id where co_status='진행'";
			cmd.CommandText = sql;
			reader = cmd.ExecuteReader();
			ListViewItem item_co;
			while (reader.Read())
			{
				co_num = reader["num"].ToString();
				co_p_id = reader["p_id"].ToString();
				co_p_name = reader["p_name"].ToString();
				co_quntity = reader["co_quntity"].ToString();
				co_c_id = reader["c_id"].ToString();

				item_co = new ListViewItem();
				item_co.SubItems.Add(co_num);
				item_co.SubItems.Add(co_p_id);
				item_co.SubItems.Add(co_p_name);
				item_co.SubItems.Add(co_quntity);
				item_co.SubItems.Add(co_c_id);

				listView_customer_ordering.Items.Add(item_co);
			}
			reader.Close();
			listView_customer_ordering.EndUpdate();

			///////////////////////////////////////////////////////////////////////////////////////////
			///입고 리스트뷰 설정////////////////////////////////////////////////////////////////////
			//////////////////////////////////////////////////////////////////////////////////////////
			listView_incoming.Clear();
			listView_incoming.BeginUpdate(); //리스트뷰 업데이트 시작
			listView_incoming.View = View.Details;
			listView_incoming.Columns.Add("", 0, HorizontalAlignment.Center);
			listView_incoming.Columns.Add("생산품바코드번호", 130, HorizontalAlignment.Center);
			listView_incoming.Columns.Add("제품코드", 80, HorizontalAlignment.Center);
			listView_incoming.Columns.Add("제품명", 100, HorizontalAlignment.Center);
			listView_incoming.Columns.Add("제조일자", 130, HorizontalAlignment.Center);
			listView_incoming.Columns.Add("사원코드", 120, HorizontalAlignment.Center);
			listView_incoming.Columns.Add("사원명", 100, HorizontalAlignment.Center);

			//입고 데이터 조회 쿼리
			string i_r_barcode, i_p_id, i_p_name,i_r_MFD, i_e_id,i_e_name;
			sql = "SELECT r_barcode, r.p_id, p_name,r_MFD, r_status, r.e_id, e_name FROM real_product r ";
			sql += "inner join employee e on r.e_id = e.e_id inner join product p on p.p_id=r.p_id where r_status='입고'";
			cmd.CommandText = sql;
			reader = cmd.ExecuteReader();
			ListViewItem item_i;
			while (reader.Read())
			{
				i_r_barcode = reader["r_barcode"].ToString();
				i_p_id = reader["p_id"].ToString();
				i_p_name = reader["p_name"].ToString();
				i_r_MFD = reader["r_MFD"].ToString();
				i_e_id = reader["e_id"].ToString();
				i_e_name = reader["e_name"].ToString();

				item_i = new ListViewItem();
				item_i.SubItems.Add(i_r_barcode);
				item_i.SubItems.Add(i_p_id);
				item_i.SubItems.Add(i_p_name);
				item_i.SubItems.Add(i_r_MFD);
				item_i.SubItems.Add(i_e_id);
				item_i.SubItems.Add(i_e_name);

				listView_incoming.Items.Add(item_i);
			}
			reader.Close();
			listView_incoming.EndUpdate();

			///////////////////////////////////////////////////////////////////////////////////////////
			///입고등록 리스트뷰 설정/////////////////////////////////////////////////////////////////
			//////////////////////////////////////////////////////////////////////////////////////////
			listView_incoming_registration.Clear();
			listView_incoming_registration.BeginUpdate(); //리스트뷰 업데이트 시작
			listView_incoming_registration.View = View.Details;
			listView_incoming_registration.Columns.Add("", 0, HorizontalAlignment.Center);
			listView_incoming_registration.Columns.Add("생산품바코드번호", 130, HorizontalAlignment.Center);
			listView_incoming_registration.Columns.Add("제품코드", 80, HorizontalAlignment.Center);
			listView_incoming_registration.Columns.Add("제품명", 100, HorizontalAlignment.Center);
			listView_incoming_registration.Columns.Add("제조일자", 130, HorizontalAlignment.Center);
			listView_incoming_registration.Columns.Add("물류상태", 100, HorizontalAlignment.Center);

			//입고등록 데이터 조회 쿼리
			string ir_r_barcode, ir_p_id, ir_p_name, ir_r_MFD, ir_r_status;
			sql = "SELECT r_barcode, r.p_id, p_name, r_MFD, r_status FROM real_product r inner join product p on r.p_id=p.p_id WHERE r_status='생산'";
			cmd.CommandText = sql;
			reader = cmd.ExecuteReader();
			ListViewItem item_ir;
			while (reader.Read())
			{
				ir_r_barcode = reader["r_barcode"].ToString();
				ir_p_id = reader["p_id"].ToString();
				ir_p_name = reader["p_name"].ToString();
				ir_r_MFD = reader["r_MFD"].ToString();
				ir_r_status = reader["r_status"].ToString();

				item_ir = new ListViewItem();
				item_ir.SubItems.Add(ir_r_barcode);
				item_ir.SubItems.Add(ir_p_id);
				item_ir.SubItems.Add(ir_p_name);
				item_ir.SubItems.Add(ir_r_MFD);
				item_ir.SubItems.Add(ir_r_status);

				listView_incoming_registration.Items.Add(item_ir);
			}
			reader.Close();
			listView_incoming_registration.EndUpdate();

			///////////////////////////////////////////////////////////////////////////////////////////
			///창고재고 리스트뷰 설정/////////////////////////////////////////////////////////////////
			//////////////////////////////////////////////////////////////////////////////////////////
			listView_warehouse.Clear();
			listView_warehouse.BeginUpdate(); //리스트뷰 업데이트 시작
			listView_warehouse.View = View.Details;
			listView_warehouse.Columns.Add("", 0, HorizontalAlignment.Center);
			listView_warehouse.Columns.Add("일련번호", 80, HorizontalAlignment.Center);
			listView_warehouse.Columns.Add("생산품바코드", 100, HorizontalAlignment.Center);
			listView_warehouse.Columns.Add("입고일자", 100, HorizontalAlignment.Center);
			listView_warehouse.Columns.Add("창고구역", 80, HorizontalAlignment.Center);
			listView_warehouse.Columns.Add("창고번호", 80, HorizontalAlignment.Center);
			listView_warehouse.Columns.Add("출고일자", 100, HorizontalAlignment.Center);
			listView_warehouse.Columns.Add("출고장번호", 80, HorizontalAlignment.Center);

			//창고재고 데이터 조회 쿼리
			string num, w_indate, w_section, w_location, w_outdate, w_outlocation;
			sql = "SELECT w.num, w.r_barcode, w.w_indate, w.w_section, w.w_location, w.w_outdate, w.w_outlocation FROM warehouse w ";
			sql += "inner join real_product r on w.r_barcode = r.r_barcode where r.r_status='적재'";
			cmd.CommandText = sql;
			reader = cmd.ExecuteReader();
			ListViewItem item_w; //각 행데이터
			while (reader.Read())
			{
				num = reader["num"].ToString();
				r_barcode = reader["r_barcode"].ToString();
				w_indate = reader["w_indate"].ToString();
				w_section = reader["w_section"].ToString();
				w_location = reader["w_location"].ToString();
				w_outdate = reader["w_outdate"].ToString();
				w_outlocation = reader["w_outlocation"].ToString();

				item_w = new ListViewItem();
				item_w.SubItems.Add(num.ToString());
				item_w.SubItems.Add(r_barcode);
				item_w.SubItems.Add(w_indate);
				item_w.SubItems.Add(w_section);
				item_w.SubItems.Add(w_location);
				item_w.SubItems.Add(w_outdate);
				item_w.SubItems.Add(w_outlocation);

				listView_warehouse.Items.Add(item_w);
			}
			reader.Close();
			listView_warehouse.EndUpdate(); //리스트뷰 업데이트 끝

			///////////////////////////////////////////////////////////////////////////////////////////
			///발주(패킹) 리스트뷰 설정////////////////////////////////////////////////////////////////
			//////////////////////////////////////////////////////////////////////////////////////////
			listView_ordering.Clear();
			listView_ordering.BeginUpdate(); //리스트뷰 업데이트 시작
			listView_ordering.View = View.Details;
			listView_ordering.Columns.Add("", 0, HorizontalAlignment.Center);
			listView_ordering.Columns.Add("패킹바코드", 120, HorizontalAlignment.Center);
			listView_ordering.Columns.Add("생산품바코드", 120, HorizontalAlignment.Center);
			listView_ordering.Columns.Add("거래처코드", 120, HorizontalAlignment.Center);
			listView_ordering.Columns.Add("사원코드", 120, HorizontalAlignment.Center);
			listView_ordering.Columns.Add("담당사원", 120, HorizontalAlignment.Center);

			//발주(패킹) 데이터 조회 쿼리
			string pac_barcode, c_id, e_id, e_name;
			sql = "SELECT pac_barcode,r_barcode, c_id, p.e_id, e_name FROM packing p inner join employee e on p.e_id = e.e_id where delivery_date is null";
			cmd.CommandText = sql;
			reader = cmd.ExecuteReader();
			ListViewItem item_pac; //각 행데이터
			while (reader.Read())
			{
				pac_barcode = reader["pac_barcode"].ToString();
				r_barcode = reader["r_barcode"].ToString();
				c_id = reader["c_id"].ToString();
				e_id = reader["e_id"].ToString();
				e_name = reader["e_name"].ToString();

				item_pac = new ListViewItem();
				item_pac.SubItems.Add(pac_barcode);
				item_pac.SubItems.Add(r_barcode);
				item_pac.SubItems.Add(c_id);
				item_pac.SubItems.Add(e_id);
				item_pac.SubItems.Add(e_name);

				listView_ordering.Items.Add(item_pac);
			}
			reader.Close();
			listView_ordering.EndUpdate(); //리스트뷰 업데이트 끝

			///////////////////////////////////////////////////////////////////////////////////////////
			///배송 리스트뷰 설정////////////////////////////////////////////////////////////////////
			//////////////////////////////////////////////////////////////////////////////////////////
			listView_delivery.Clear();
			listView_delivery.BeginUpdate(); //리스트뷰 업데이트 시작
			listView_delivery.View = View.Details;
			listView_delivery.Columns.Add("", 0, HorizontalAlignment.Center);
			listView_delivery.Columns.Add("배송일자", 110, HorizontalAlignment.Center);
			listView_delivery.Columns.Add("패킹바코드", 100, HorizontalAlignment.Center);
			listView_delivery.Columns.Add("거래처명", 100, HorizontalAlignment.Center);
			listView_delivery.Columns.Add("담당사원", 100, HorizontalAlignment.Center);

			//배송 데이터 조회 쿼리
			string d_delivery_date, d_pac_barcode, d_c_name, d_e_name;
			sql = "SELECT delivery_date, pac_barcode, c_name, e_name FROM packing p inner join employee e ";
			sql += "on p.e_id=e.e_id inner join customer c on c.c_id=p.c_id where delivery_date is not null";
			cmd.CommandText = sql;
			reader = cmd.ExecuteReader();
			ListViewItem item_d;
			while (reader.Read())
			{
				d_delivery_date = reader["delivery_date"].ToString();
				d_pac_barcode = reader["pac_barcode"].ToString();
				d_c_name = reader["c_name"].ToString();
				d_e_name = reader["e_name"].ToString();

				item_d = new ListViewItem();
				item_d.SubItems.Add(d_delivery_date);
				item_d.SubItems.Add(d_pac_barcode);
				item_d.SubItems.Add(d_c_name);
				item_d.SubItems.Add(d_e_name);

				listView_delivery.Items.Add(item_d);
			}
			reader.Close();
			listView_delivery.EndUpdate();

			///////////////////////////////////////////////////////////////////////////////////////////
			///사원 리스트뷰 설정////////////////////////////////////////////////////////////////////
			//////////////////////////////////////////////////////////////////////////////////////////
			listView_employee.Clear();
			listView_employee.BeginUpdate(); //리스트뷰 업데이트 시작
			listView_employee.View = View.Details;
			listView_employee.Columns.Add("", 0, HorizontalAlignment.Center);
			listView_employee.Columns.Add("사원코드", 130, HorizontalAlignment.Center);
			listView_employee.Columns.Add("사원명", 130, HorizontalAlignment.Center);
			listView_employee.Columns.Add("차량번호", 130, HorizontalAlignment.Center);

			//사원 데이터 조회 쿼리
			string e_car;
			sql = "SELECT e_id,e_name,e_car FROM employee";
			cmd.CommandText = sql;
			reader = cmd.ExecuteReader();
			ListViewItem item_e; //각 행데이터
			while (reader.Read())
			{
				e_id = reader["e_id"].ToString();
				e_name = reader["e_name"].ToString();
				e_car = reader["e_car"].ToString();

				item_e = new ListViewItem();
				item_e.SubItems.Add(e_id);
				item_e.SubItems.Add(e_name);
				item_e.SubItems.Add(e_car);

				listView_employee.Items.Add(item_e);
			}
			reader.Close();
			listView_employee.EndUpdate(); //리스트뷰 업데이트 끝

			///////////////////////////////////////////////////////////////////////////////////////////
			///거래처 리스트뷰 설정////////////////////////////////////////////////////////////////////
			//////////////////////////////////////////////////////////////////////////////////////////
			listView_customer.Clear();
			listView_customer.BeginUpdate(); //리스트뷰 업데이트 시작
			listView_customer.View = View.Details;
			listView_customer.Columns.Add("", 0, HorizontalAlignment.Center);
			listView_customer.Columns.Add("거래처코드", 130, HorizontalAlignment.Center);
			listView_customer.Columns.Add("거래처명", 130, HorizontalAlignment.Center);
			listView_customer.Columns.Add("주소", 130, HorizontalAlignment.Center);
			listView_customer.Columns.Add("전화번호", 130, HorizontalAlignment.Center);

			//거래처 데이터 조회 쿼리
			string c_name, c_address, c_phone;
			sql = "SELECT c_id, c_name, c_address, c_phone FROM customer";
			cmd.CommandText = sql;
			reader = cmd.ExecuteReader();
			ListViewItem item_c; //각 행데이터
			while (reader.Read())
			{
				c_id = reader["c_id"].ToString();
				c_name = reader["c_name"].ToString();
				c_address = reader["c_address"].ToString();
				c_phone = reader["c_phone"].ToString();

				item_c = new ListViewItem();
				item_c.SubItems.Add(c_id);
				item_c.SubItems.Add(c_name);
				item_c.SubItems.Add(c_address);
				item_c.SubItems.Add(c_phone);

				listView_customer.Items.Add(item_c);
			}
			reader.Close();
			listView_customer.EndUpdate(); //리스트뷰 업데이트 끝

			///////////////////////////////////////////////////////////////////////////////////////////
			///제품정보 리스트뷰 설정////////////////////////////////////////////////////////////////////
			//////////////////////////////////////////////////////////////////////////////////////////
			listView_product.Clear();
			listView_product.BeginUpdate(); //리스트뷰 업데이트 시작
			listView_product.View = View.Details;
			listView_product.Columns.Add("", 0, HorizontalAlignment.Center);
			listView_product.Columns.Add("제품코드", 80, HorizontalAlignment.Center);
			listView_product.Columns.Add("제품명", 60, HorizontalAlignment.Center);
			listView_product.Columns.Add("단가", 100, HorizontalAlignment.Center);
			listView_product.Columns.Add("가로", 50, HorizontalAlignment.Center);
			listView_product.Columns.Add("세로", 50, HorizontalAlignment.Center);
			listView_product.Columns.Add("높이", 50, HorizontalAlignment.Center);
			listView_product.Columns.Add("무게", 50, HorizontalAlignment.Center);
			listView_product.Columns.Add("제품조건", 100, HorizontalAlignment.Center);
			listView_product.Columns.Add("취급주의", 80, HorizontalAlignment.Center);
			listView_product.Columns.Add("유통기한", 80, HorizontalAlignment.Center);

			//제품정보 데이터 조회 쿼리
			string p_price, p_width, p_depth, p_height, p_weight, p_condition, p_fragile, p_EXP;
			sql = "SELECT p_id, p_name, p_price, p_width,p_depth, p_height, p_weight, p_condition, p_fragile, p_EXP FROM product";
			cmd.CommandText = sql;
			reader = cmd.ExecuteReader();
			ListViewItem item_p; //각 행데이터
			while (reader.Read())
			{
				p_id = reader["p_id"].ToString();
				p_name = reader["p_name"].ToString();
				p_price = reader["p_price"].ToString();
				p_width = reader["p_width"].ToString();
				p_depth = reader["p_depth"].ToString();
				p_height = reader["p_height"].ToString();
				p_weight = reader["p_weight"].ToString();
				p_condition = reader["p_condition"].ToString();
				p_fragile = reader["p_fragile"].ToString();
				p_EXP = reader["p_EXP"].ToString();

				item_p = new ListViewItem();
				item_p.SubItems.Add(p_id);
				item_p.SubItems.Add(p_name);
				item_p.SubItems.Add(p_price);
				item_p.SubItems.Add(p_width);
				item_p.SubItems.Add(p_depth);
				item_p.SubItems.Add(p_height);
				item_p.SubItems.Add(p_weight);
				item_p.SubItems.Add(p_condition);
				item_p.SubItems.Add(p_fragile);
				item_p.SubItems.Add(p_EXP);

				listView_product.Items.Add(item_p);
			}
			reader.Close();
			listView_product.EndUpdate(); //리스트뷰 업데이트 끝
		}

		private void tabPage13_Click(object sender, EventArgs e)
		{

		}

		/////////////////////////////////////////////////////////////////////////////////////////////////////
		///입고 리스트뷰 선택 이벤트 설정////////////////////////////////////////////////////////////////////
		/////////////////////////////////////////////////////////////////////////////////////////////////////
		private void listView_incoming_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
		{
			e.DrawDefault = true;
		}
		private void listView_incoming_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
		{
			if (this.listView_incoming_registration.SelectedIndices.Contains(e.ItemIndex))
			{
				e.SubItem.BackColor = Color.PeachPuff;
			}
			else
			{
				e.SubItem.BackColor = Color.White;
			}
			e.DrawBackground();
			e.DrawText();
		}
		private void listView_incoming_SelectedIndexChanged(object sender, EventArgs e)
		{
			//리스트뷰 선택행 텍스트박스에 넣기
			int indexnum;
			//입고등록시
			indexnum = listView_incoming_registration.FocusedItem.Index;
			tb_i_barcode_r.Text = listView_incoming_registration.Items[indexnum].SubItems[1].Text;
			cb_i_p_id_r.Text = listView_incoming_registration.Items[indexnum].SubItems[2].Text;
			tb_i_r_MFD_r.Text = listView_incoming_registration.Items[indexnum].SubItems[3].Text;
		}
		/////////////////////////////////////////////////////////////////////////////////////////////////////
		///고객주문 리스트뷰 선택 이벤트 설정////////////////////////////////////////////////////////////////
		/////////////////////////////////////////////////////////////////////////////////////////////////////
		private void listView_customer_ordering_SelectedIndexChanged(object sender, EventArgs e)
		{
			//리스트뷰 선택행 텍스트박스에 넣기
			int indexnum;
			//발주등록시
			indexnum = listView_customer_ordering.FocusedItem.Index;
			tb_o_pac_barcode.Text = listView_customer_ordering.Items[indexnum].SubItems[1].Text;
			tb_o_p_id.Text = listView_customer_ordering.Items[indexnum].SubItems[2].Text;
			tb_o_co_quntity.Text = listView_customer_ordering.Items[indexnum].SubItems[4].Text;
			cb_o_c_id.Text = listView_customer_ordering.Items[indexnum].SubItems[5].Text;
		}
		private void listView_customer_ordering_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
		{
			if (this.listView_customer_ordering.SelectedIndices.Contains(e.ItemIndex))
			{
				e.SubItem.BackColor = Color.PeachPuff;
			}
			else
			{
				e.SubItem.BackColor = Color.White;
			}
			e.DrawBackground();
			e.DrawText();
		}
		private void listView_customer_ordering_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
		{
			e.DrawDefault = true;
		}
		/////////////////////////////////////////////////////////////////////////////////////////////////////
		///입고 리스트뷰 선택 이벤트 설정////////////////////////////////////////////////////////////////
		/////////////////////////////////////////////////////////////////////////////////////////////////////
		private void listView_incoming_DrawColumnHeader_1(object sender, DrawListViewColumnHeaderEventArgs e)
		{
			e.DrawDefault = true;
		}
		private void listView_incoming_DrawSubItem_1(object sender, DrawListViewSubItemEventArgs e)
		{
			if (this.listView_incoming.SelectedIndices.Contains(e.ItemIndex))
			{
				e.SubItem.BackColor = Color.PeachPuff;
			}
			else
			{
				e.SubItem.BackColor = Color.White;
			}
			e.DrawBackground();
			e.DrawText();
		}
		private void listView_incoming_SelectedIndexChanged_1(object sender, EventArgs e)
		{
			//리스트뷰 선택행 텍스트박스에 넣기
			int indexnum;
			indexnum = listView_incoming.FocusedItem.Index;
			cb_i_e_id_e.Text = listView_incoming.Items[indexnum].SubItems[5].Text;
			tb_i_barcode_e.Text = listView_incoming.Items[indexnum].SubItems[1].Text;
			tb_i_barcode_u.Text = listView_incoming.Items[indexnum].SubItems[1].Text;
		}
		/////////////////////////////////////////////////////////////////////////////////////////////////////
		///발주 리스트뷰 선택 이벤트 설정////////////////////////////////////////////////////////////////////
		/////////////////////////////////////////////////////////////////////////////////////////////////////
		private void listView_ordering_SelectedIndexChanged(object sender, EventArgs e)
		{
			//리스트뷰 선택행 텍스트박스에 넣기
			int indexnum;
			indexnum = listView_ordering.FocusedItem.Index;
			tb_o_u_pac_barcode.Text = listView_ordering.Items[indexnum].SubItems[1].Text;
			cb_o_u_e_id.Text = listView_ordering.Items[indexnum].SubItems[4].Text;
			label31.Text = listView_ordering.Items[indexnum].SubItems[1].Text;
		}
		private void listView_ordering_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
		{
			e.DrawDefault = true;
		}
		private void listView_ordering_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
		{
			if (this.listView_ordering.SelectedIndices.Contains(e.ItemIndex))
			{
				e.SubItem.BackColor = Color.PeachPuff;
			}
			else
			{
				e.SubItem.BackColor = Color.White;
			}
			e.DrawBackground();
			e.DrawText();
		}
		/////////////////////////////////////////////////////////////////////////////////////////////////////
		///생산품 리스트뷰 선택 이벤트 설정////////////////////////////////////////////////////////////////
		/////////////////////////////////////////////////////////////////////////////////////////////////////
		private void listView_real_product_SelectedIndexChanged_1(object sender, EventArgs e)
		{
			//리스트뷰 선택행 텍스트박스에 넣기
			int indexnum;
			indexnum = listView_real_product.FocusedItem.Index;
			tb_r_barcode_e.Text = listView_real_product.Items[indexnum].SubItems[1].Text;
			cb_p_id_e.Text = listView_real_product.Items[indexnum].SubItems[2].Text;
			tb_r_MFD_e.Text = listView_real_product.Items[indexnum].SubItems[4].Text;
			tb_r_EXP_e.Text = listView_real_product.Items[indexnum].SubItems[5].Text;
		}
		private void listView_real_product_DrawColumnHeader_1(object sender, DrawListViewColumnHeaderEventArgs e)
		{
			e.DrawDefault = true;
		}
		private void listView_real_product_DrawSubItem_1(object sender, DrawListViewSubItemEventArgs e)
		{
			if (this.listView_real_product.SelectedIndices.Contains(e.ItemIndex))

			{
				e.SubItem.BackColor = Color.PeachPuff;
			}
			else
			{
				e.SubItem.BackColor = Color.White;
			}
			e.DrawBackground();
			e.DrawText();
		}
		/////////////////////////////////////////////////////////////////////////////////////////////////////
		///배송 리스트뷰 선택 이벤트 설정////////////////////////////////////////////////////////////////
		/////////////////////////////////////////////////////////////////////////////////////////////////////
		private void listView_delivery_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
		{
			e.DrawDefault = true;
		}
		private void listView_delivery_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
		{
			if (this.listView_delivery.SelectedIndices.Contains(e.ItemIndex))
			{
				e.SubItem.BackColor = Color.PeachPuff;
			}
			else
			{
				e.SubItem.BackColor = Color.White;
			}
			e.DrawBackground();
			e.DrawText();
		}
		/////////////////////////////////////////////////////////////////////////////////////////////////////
		///창고(재고) 리스트뷰 선택 이벤트 설정////////////////////////////////////////////////////////////////
		/////////////////////////////////////////////////////////////////////////////////////////////////////
		private void listView_warehouse_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
		{
			if (this.listView_warehouse.SelectedIndices.Contains(e.ItemIndex))
			{
				e.SubItem.BackColor = Color.PeachPuff;
			}
			else
			{
				e.SubItem.BackColor = Color.White;
			}
			e.DrawBackground();
			e.DrawText();
		}

		private void listView_warehouse_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
		{
			e.DrawDefault = true;
		}
		/////////////////////////////////////////////////////////////////////////////////////////////////////
		///제품정보 리스트뷰 선택 이벤트 설정////////////////////////////////////////////////////////////////
		/////////////////////////////////////////////////////////////////////////////////////////////////////
		private void listView_product_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
		{
			e.DrawDefault = true;
		}
		private void listView_product_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
		{
			if (this.listView_product.SelectedIndices.Contains(e.ItemIndex))
			{
				e.SubItem.BackColor = Color.PeachPuff;
			}
			else
			{
				e.SubItem.BackColor = Color.White;
			}
			e.DrawBackground();
			e.DrawText();
		}
		private void listView_product_SelectedIndexChanged(object sender, EventArgs e)
		{
			int indexnum;
			indexnum = listView_product.FocusedItem.Index;
			tb_p_id_e.Text = listView_product.Items[indexnum].SubItems[1].Text;
			tb_p_name_e.Text = listView_product.Items[indexnum].SubItems[2].Text;
			tb_p_price_e.Text = listView_product.Items[indexnum].SubItems[3].Text;
			tb_p_width_e.Text = listView_product.Items[indexnum].SubItems[4].Text;
			tb_p_depth_e.Text = listView_product.Items[indexnum].SubItems[5].Text;
			tb_p_height_e.Text = listView_product.Items[indexnum].SubItems[6].Text;
			tb_p_weight_e.Text = listView_product.Items[indexnum].SubItems[7].Text;
			cb_p_condition_e.Text = listView_product.Items[indexnum].SubItems[8].Text;
			cb_p_fragile_e.Text = listView_product.Items[indexnum].SubItems[9].Text;
			tb_p_EXP_e.Text = listView_product.Items[indexnum].SubItems[10].Text;
		}
		/////////////////////////////////////////////////////////////////////////////////////////////////////
		///거래처 리스트뷰 선택 이벤트 설정////////////////////////////////////////////////////////////////
		/////////////////////////////////////////////////////////////////////////////////////////////////////
		private void listView_customer_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
		{
			e.DrawDefault = true;
		}
		private void listView_customer_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
		{
			if (this.listView_customer.SelectedIndices.Contains(e.ItemIndex))
			{
				e.SubItem.BackColor = Color.PeachPuff;
			}
			else
			{
				e.SubItem.BackColor = Color.White;
			}
			e.DrawBackground();
			e.DrawText();
		}
		private void listView_customer_SelectedIndexChanged(object sender, EventArgs e)
		{
			int indexnum;
			indexnum = listView_customer.FocusedItem.Index;
			tb_c_id_e.Text = listView_customer.Items[indexnum].SubItems[1].Text;
			tb_c_name_e.Text = listView_customer.Items[indexnum].SubItems[2].Text;
			tb_c_address_e.Text = listView_customer.Items[indexnum].SubItems[3].Text;
			tb_c_phone_e.Text = listView_customer.Items[indexnum].SubItems[4].Text;
		}
		/////////////////////////////////////////////////////////////////////////////////////////////////////
		///사원 리스트뷰 선택 이벤트 설정////////////////////////////////////////////////////////////////
		/////////////////////////////////////////////////////////////////////////////////////////////////////
		private void listView_employee_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
		{
			if (this.listView_employee.SelectedIndices.Contains(e.ItemIndex))
			{
				e.SubItem.BackColor = Color.PeachPuff;
			}
			else
			{
				e.SubItem.BackColor = Color.White;
			}
			e.DrawBackground();
			e.DrawText();
		}
		private void listView_employee_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
		{
			e.DrawDefault = true;
		}
		private void listView_employee_SelectedIndexChanged(object sender, EventArgs e)
		{
			int indexnum;
			indexnum = listView_employee.FocusedItem.Index;
			tb_e_id_e.Text = listView_employee.Items[indexnum].SubItems[1].Text;
			tb_e_name_e.Text = listView_employee.Items[indexnum].SubItems[2].Text;
			tb_e_car_e.Text = listView_employee.Items[indexnum].SubItems[3].Text;
		}

		/// <summary>
		/// WMS 메뉴바 설정
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btn_menu1_Click(object sender, EventArgs e) //메인_생산품 버튼
		{
			panel_side.Height = btn_menu1.Height;
			panel_side.Top = btn_menu1.Top;
			tabControl_main.SelectedIndex = 0;
		}
		private void btn_menu2_Click(object sender, EventArgs e) //메인_발주 버튼
		{
			panel_side.Height = btn_menu2.Height;
			panel_side.Top = btn_menu2.Top;
			tabControl_main.SelectedIndex = 1;
		}
		private void btn_menu3_Click(object sender, EventArgs e) //메인_입고 버튼
		{
			panel_side.Height = btn_menu3.Height;
			panel_side.Top = btn_menu3.Top;
			tabControl_main.SelectedIndex = 2;
		}
		private void btn_menu4_Click(object sender, EventArgs e) //메인_재고 버튼
		{
			panel_side.Height = btn_menu4.Height;
			panel_side.Top = btn_menu4.Top;
			tabControl_main.SelectedIndex = 3;
		}
		private void btn_menu5_Click(object sender, EventArgs e)  //메인_배송 버튼
		{
			panel_side.Height = btn_menu5.Height;
			panel_side.Top = btn_menu5.Top;
			tabControl_main.SelectedIndex = 4;
		}
		private void btn_menu6_Click(object sender, EventArgs e)  //메인_통계 버튼
		{
			panel_side.Height = btn_menu6.Height;
			panel_side.Top = btn_menu6.Top;
			tabControl_main.SelectedIndex = 5;
		}
		private void btn_menu7_Click(object sender, EventArgs e)  //메인_관리 버튼
		{
			panel_side.Height = btn_menu7.Height;
			panel_side.Top = btn_menu7.Top;
			tabControl_main.SelectedIndex = 6;
		}
		private void button23_Click(object sender, EventArgs e) //생산품_상단바_추가버튼
		{
			panel_product_registration.Location = new Point(732, 62);
			panel_real_product_registration.Visible = true;
			panel_real_product_edit.Visible = false;
		}
		private void button1_Click(object sender, EventArgs e)
		{
			Close();
		}
		
		/////////////////////////////////////////////////////////////////////////////////////////////////////
		///버튼 이벤트 설정//////////////////////////////////////////////////////////////////////////////////
		/////////////////////////////////////////////////////////////////////////////////////////////////////
		private void btn_e_registration_Click(object sender, EventArgs e) //관리_사원관리_사원등록
		{
			string e_id, e_name, e_car;
			e_id = tb_e_id_r.Text.ToString();
			e_name = tb_e_name_r.Text.ToString();
			e_car = tb_e_car_r.Text.ToString();

			// 데이터 입력 쿼리
			string sql = "INSERT INTO employee(e_id, e_name, e_car)";
			sql += " VALUES('" + e_id + "', '" + e_name + "', '" + e_car + "')";

			cmd.CommandText = sql;
			cmd.ExecuteNonQuery();

			tb_e_id_r.Text = "";
			tb_e_name_r.Text = "";
			tb_e_car_r.Text = "";
			listview();
			combobox();
		}
		private void button35_Click(object sender, EventArgs e) //사원관리 상단 추가버튼
		{
			panel_employee_registration.Location = new Point(736, 67);
			panel_employee_registration.Visible = true;
			panel_employee_edit.Visible = false;
		}
		private void btn_c_registration_Click(object sender, EventArgs e) //관리_거래처관리_거래처등록
		{
			string c_id, c_name, c_address, c_phone;
			c_id = tb_c_id_r.Text.ToString();
			c_name = tb_c_name_r.Text.ToString();
			c_address = tb_c_address_r.Text.ToString();
			c_phone = tb_c_phone_r.Text.ToString();

			// 데이터 입력 쿼리
			string sql = "INSERT INTO customer(c_id, c_name, c_address, c_phone)";
			sql += " VALUES('" + c_id + "', '" + c_name + "', '" + c_address + "','" + c_phone + "')";

			cmd.CommandText = sql;
			cmd.ExecuteNonQuery();

			tb_c_id_r.Text = "";
			tb_c_name_r.Text = "";
			tb_c_address_r.Text = "";
			tb_c_phone_r.Text = "";
			listview();
			combobox();
		}
		private void btn_p_registration_Click(object sender, EventArgs e) //관리_제품관리_제품정보등록
		{
			string p_id, p_name, p_price, p_width, p_depth, p_height, p_EXP, p_weight, p_condition, p_fragile;
			p_id = tb_p_id_r.Text.ToString();
			p_name = tb_p_name_r.Text.ToString();
			p_price = tb_p_price_r.Text.ToString();
			p_width = tb_p_width_r.Text.ToString();
			p_depth = tb_p_depth_r.Text.ToString();
			p_height = tb_p_height_r.Text.ToString();
			p_EXP = tb_p_EXP_r.Text.ToString();
			p_weight = tb_p_weight_r.Text.ToString();
			p_condition = cb_p_condition_r.Text.ToString();
			p_fragile = cb_p_fragile_r.Text.ToString();

			// 데이터 입력 쿼리
			string sql = "INSERT INTO product(p_id, p_name, p_price, p_width, p_depth, p_height,p_EXP, p_weight, p_condition, p_fragile)";
			sql += " VALUES('" + p_id + "','" + p_name + "'," + p_price + "," + p_width + "," + p_depth + "," + p_height + "," + p_EXP;
			sql += "," + p_weight + ",'" + p_condition + "','" + p_fragile + "')";

			cmd.CommandText = sql;
			cmd.ExecuteNonQuery();

			tb_p_id_r.Text = "";
			tb_p_name_r.Text = "";
			tb_p_price_r.Text = "";
			tb_p_width_r.Text = "";
			tb_p_depth_r.Text = "";
			tb_p_height_r.Text = "";
			tb_p_EXP_r.Text = "";
			tb_p_weight_r.Text = "";
			cb_p_condition_r.Text = "";
			cb_p_fragile_r.Text = "";
			listview();
			combobox();
		}
		private void button38_Click(object sender, EventArgs e) //관리_거래처관리_거래처등록
		{
			panel_customer_registration.Location = new Point(736, 67);
			panel_customer_registration.Visible = true;
			panel_customer_edit.Visible = false;
		}
		private void button41_Click(object sender, EventArgs e) //관리_제품정보관리_제품정보등록
		{
			panel_product_registration.Location = new Point(736, 67);
			panel_product_registration.Visible = true;
			panel_product_edit.Visible = false;
		}
		private void button1_Click_1(object sender, EventArgs e) //관리_제품정보관리_제품정보등록_닫기
		{
			panel_product_registration.Visible = false;
		}
		private void button11_Click_1(object sender, EventArgs e) //관리_거래처관리_거래처등록_닫기
		{
			panel_customer_registration.Visible = false;
		}
		private void button15_Click_2(object sender, EventArgs e) //관리_사원관리_사원등록_닫기
		{
			panel_employee_registration.Visible = false;
		}
		private void button34_Click(object sender, EventArgs e) //관리_사원관리_사원정보_편집
		{
			panel_employee_edit.Location = new Point(736, 67);
			panel_employee_edit.Visible = true;
			panel_employee_registration.Visible = false;
		}
		private void button16_Click_1(object sender, EventArgs e) //관리_사원관리_사원정보_수정_닫기
		{
			panel_employee_edit.Visible = false;
		}
		private void button42_Click(object sender, EventArgs e) //관리_사원관리_사원정보_수정버튼
		{
			string e_id, e_name, e_car;
			e_id = tb_e_id_e.Text.ToString();
			e_name = tb_e_name_e.Text.ToString();
			e_car = tb_e_car_e.Text.ToString();

			// 데이터 수정 쿼리
			string sql = "UPDATE employee SET e_name = '" + e_name + "', e_car= '" + e_car + "'";
			sql += " WHERE e_id = '" + e_id + "'";

			cmd.CommandText = sql;
			cmd.ExecuteNonQuery();

			tb_e_id_e.Text = "";
			tb_e_name_e.Text = "";
			tb_e_car_e.Text = "";
			listview();
			combobox();
		}
		private void btn_e_delete_Click(object sender, EventArgs e) //관리_사원관리_사원정보_삭제버튼
		{
			string e_id, e_name, e_car;
			e_id = tb_e_id_e.Text.ToString();
			e_name = tb_e_name_e.Text.ToString();
			e_car = tb_e_car_e.Text.ToString();

			// 데이터 삭제 쿼리
			string sql = "DELETE FROM employee WHERE e_id = '" + e_id + "'";

			cmd.CommandText = sql;
			cmd.ExecuteNonQuery();

			tb_e_id_e.Text = "";
			tb_e_name_e.Text = "";
			tb_e_car_e.Text = "";
			listview();
			combobox();
		}
		private void button33_Click(object sender, EventArgs e) //관리_거래처정보_편집_x버튼
		{
			panel_customer_edit.Visible = false;
		}
		private void button37_Click(object sender, EventArgs e) //관리_거래처정보_편집(상단)
		{
			panel_customer_edit.Location = new Point(736, 67);
			panel_customer_edit.Visible = true;
			panel_customer_registration.Visible = false;
		}
		private void btn_c_update_Click(object sender, EventArgs e) //관리_거래처정보_수정버튼
		{
			string c_id, c_name, c_address, c_phone;
			c_id = tb_c_id_e.Text.ToString();
			c_name = tb_c_name_e.Text.ToString();
			c_address = tb_c_address_e.Text.ToString();
			c_phone = tb_c_phone_e.Text.ToString();

			// 데이터 수정 쿼리
			string sql = "UPDATE customer SET c_name = '" + c_name + "', c_address= '" + c_address + "', c_phone= '" + c_phone + "'";
			sql += " WHERE c_id = '" + c_id + "'";

			cmd.CommandText = sql;
			cmd.ExecuteNonQuery();

			tb_c_id_e.Text = "";
			tb_c_name_e.Text = "";
			tb_c_address_e.Text = "";
			tb_c_phone_e.Text = "";
			listview();
			combobox();
		}		
		private void btn_c_delete_Click(object sender, EventArgs e) //관리_거래처정보_삭제버튼
		{
			string c_id, c_name, c_address, c_phone;
			c_id = tb_c_id_e.Text.ToString();
			c_name = tb_c_name_e.Text.ToString();
			c_address = tb_c_address_e.Text.ToString();
			c_phone = tb_c_phone_e.Text.ToString();

			// 데이터 삭제 쿼리
			string sql = "DELETE FROM customer WHERE c_id = '" + c_id + "'";

			cmd.CommandText = sql;
			cmd.ExecuteNonQuery();

			tb_e_id_e.Text = "";
			tb_e_name_e.Text = "";
			tb_e_car_e.Text = "";
			listview();
			combobox();
		}
		private void button40_Click(object sender, EventArgs e) //관리_제품정보_편집버튼(상단)
		{
			panel_product_edit.Location = new Point(736, 67);
			panel_product_edit.Visible = true;
			panel_product_registration.Visible = false;
		}
		private void button36_Click(object sender, EventArgs e) //관리_제품정보_편집_x버튼
		{
			panel_product_edit.Visible = false;
		}
		private void btn_product_update_Click(object sender, EventArgs e) //관리_제품정보_편집_수정버튼	
		{
			string p_id, p_name, p_price, p_width, p_depth, p_height, p_EXP, p_weight, p_condition, p_fragile;
			p_id = tb_p_id_e.Text.ToString();
			p_name = tb_p_name_e.Text.ToString();
			p_price = tb_p_price_e.Text.ToString();
			p_width = tb_p_width_e.Text.ToString();
			p_depth = tb_p_depth_e.Text.ToString();
			p_height = tb_p_height_e.Text.ToString();
			p_EXP = tb_p_EXP_e.Text.ToString();
			p_weight = tb_p_weight_e.Text.ToString();
			p_condition = cb_p_condition_e.Text.ToString();
			p_fragile = cb_p_fragile_e.Text.ToString();

			// 데이터 수정 쿼리
			string sql = "UPDATE product SET p_name='" + p_name + "', p_price =" + p_price + ", p_width=" + p_width + ",p_depth=" + p_depth;
			sql += ", p_height=" + p_height + ",p_EXP = " + p_EXP + ", p_weight=" + p_weight + ", p_condition = '" + p_condition + "'";
			sql += ", p_fragile = '" + p_fragile + "' WHERE p_id = '" + p_id + "'";

			cmd.CommandText = sql;
			cmd.ExecuteNonQuery();

			tb_p_id_e.Text = "";
			tb_p_name_e.Text = "";
			tb_p_price_e.Text = "";
			tb_p_width_e.Text = "";
			tb_p_depth_e.Text = "";
			tb_p_height_e.Text = "";
			tb_p_EXP_e.Text = "";
			tb_p_weight_e.Text = "";
			cb_p_condition_e.Text = "";
			cb_p_fragile_e.Text = "";
			listview();
			combobox();
		}
		private void btn_product_delete_Click(object sender, EventArgs e) //관리_제품정보_편집_삭제버튼
		{
			string p_id, p_name, p_price, p_width, p_depth, p_height, p_EXP, p_weight, p_condition, p_fragile;
			p_id = tb_p_id_e.Text.ToString();
			p_name = tb_p_name_e.Text.ToString();
			p_price = tb_p_price_e.Text.ToString();
			p_width = tb_p_width_e.Text.ToString();
			p_depth = tb_p_depth_e.Text.ToString();
			p_height = tb_p_height_e.Text.ToString();
			p_EXP = tb_p_EXP_e.Text.ToString();
			p_weight = tb_p_weight_e.Text.ToString();
			p_condition = cb_p_condition_e.Text.ToString();
			p_fragile = cb_p_fragile_e.Text.ToString();

			// 데이터 삭제 쿼리
			string sql = "DELETE FROM product WHERE p_id = '" + p_id + "'";

			cmd.CommandText = sql;
			cmd.ExecuteNonQuery();

			tb_e_id_e.Text = "";
			tb_e_name_e.Text = "";
			tb_e_car_e.Text = "";
			listview();
			combobox();
		}
		private void btn_r_registration_Click_1(object sender, EventArgs e) //생산품_생산품 등록버튼		
		{
			string r_barcode, p_id, r_MFD, r_EXP;
			r_barcode = tb_r_barcode_r.Text.ToString();
			p_id = cb_p_id_r.Text.ToString();
			r_MFD = tb_r_MFD_r.Text.ToString();
			r_EXP = tb_r_EXP_r.Text.ToString();

			// 데이터 입력 쿼리
			string sql = "INSERT INTO real_product(r_barcode, p_id, r_MFD, r_EXP, r_status)";
			sql += " VALUES('" + r_barcode + "', '" + p_id + "', '" + r_MFD + "', '" + r_EXP + "','생산')";

			cmd.CommandText = sql;
			cmd.ExecuteNonQuery();

			tb_r_barcode_r.Text = "";
			cb_p_id_r.Text = "";
			tb_r_MFD_r.Text = "";
			tb_r_EXP_r.Text = "";
			listview();
		}
		private void btn_r_update_Click_1(object sender, EventArgs e) //생산품_생산품 수정버튼	
		{
			string r_barcode, p_id, r_MFD, r_EXP;
			r_barcode = tb_r_barcode_e.Text.ToString();
			p_id = cb_p_id_e.Text.ToString();
			r_MFD = tb_r_MFD_e.Text.ToString();
			r_EXP = tb_r_EXP_e.Text.ToString();

			// 데이터 수정 쿼리
			string sql = "UPDATE real_product SET p_id = '" + p_id + "', r_MFD = '" + r_MFD + "', r_EXP = '" + r_EXP + "'";
			sql += " WHERE r_barcode = '" + r_barcode + "'";

			cmd.CommandText = sql;
			cmd.ExecuteNonQuery();

			tb_r_barcode_e.Text = "";
			cb_p_id_e.Text = "";
			tb_r_MFD_e.Text = "";
			tb_r_EXP_e.Text = "";
			listview();
		}
		private void btn_r_delete_Click(object sender, EventArgs e) //생산품_생산품 삭제버튼
		{
			string r_barcode, p_id, r_MFD, r_EXP;
			r_barcode = tb_r_barcode_e.Text.ToString();
			p_id = cb_p_id_e.Text.ToString();
			r_MFD = tb_r_MFD_e.Text.ToString();
			r_EXP = tb_r_EXP_e.Text.ToString();

			// 데이터 삭제 쿼리
			string sql = "DELETE FROM real_product WHERE r_barcode = '" + r_barcode + "'";

			cmd.CommandText = sql;
			cmd.ExecuteNonQuery();

			tb_r_barcode_e.Text = "";
			cb_p_id_e.Text = "";
			tb_r_MFD_e.Text = "";
			tb_r_EXP_e.Text = "";
			listview();
		}
		private void button22_Click_1(object sender, EventArgs e) // 생산품_편집버튼(상단)
		{
			panel_real_product_edit.Location = new Point(732, 65);
			panel_real_product_edit.Visible = true;
			panel_real_product_registration.Visible = false;
		}
		private void button2_Click_1(object sender, EventArgs e) //생산품_생산품 등록_x버튼
		{
			panel_real_product_registration.Visible = false;
		}
		private void button3_Click_1(object sender, EventArgs e) //생산품_생산품 편집_x버튼
		{
			panel_real_product_edit.Visible = false;
		}
		private void button21_Click_1(object sender, EventArgs e) //입고_입고등록_등록버튼
		{
			//입고등록 - 생산품DB 물류상태(생산->입고), 사원id 변경
			string e_id, r_barcode;
			r_barcode = tb_i_barcode_r.Text;
			e_id = cb_i_e_id_r.Text;

			// 데이터 업데이트 쿼리
			string sql = "UPDATE real_product ";
			sql += "SET e_id = '" + e_id + "'," + "r_status = '입고' ";
			sql += "WHERE r_barcode = '" + r_barcode + "'";
			cmd.CommandText = sql;
			cmd.ExecuteNonQuery();
			listview();
		}
		private void button26_Click(object sender, EventArgs e)//입고예정목록 추가 버튼
		{
			panel_i_registration.Visible = true;
		}
		private void button17_Click(object sender, EventArgs e)//입고_입고등록 x버튼
		{
			panel_i_registration.Visible = false;
		}
		private void button8_Click_1(object sender, EventArgs e)//입고_입고취소 버튼(상단)
		{
			panel_i_cancel.Location = new Point(732, 64);
			panel_i_cancel.Visible = true;
			panel_i_update.Visible = false;
		}
		private void button4_Click_2(object sender, EventArgs e)//입고_입고목록_담당자변경 버튼
		{
			panel_i_update.Visible = false;
		}
		private void button5_Click_1(object sender, EventArgs e)//입고_입고취소_x버튼
		{
			panel_i_cancel.Visible = false;
		}
		private void button7_Click_1(object sender, EventArgs e) //입고_입고취소_취소버튼
		{
			//입고취소 - 생산품DB 물류상태(입고->생산), 사원id null값으로 수정
			string r_barcode = tb_i_barcode_e.Text;

			// 데이터 업데이트 쿼리
			string sql = "UPDATE real_product ";
			sql += "SET e_id = '', " + "r_status = '생산'";
			sql += " WHERE r_barcode = '" + r_barcode + "'";
			cmd.CommandText = sql;
			cmd.ExecuteNonQuery();
			listview();
		}
		private void button19_Click(object sender, EventArgs e) //입고탭_담당자변경버튼
		{
			panel_i_cancel.Visible = false;
			panel_i_update.Visible = true;
		}
		private void button9_Click(object sender, EventArgs e) //발주탭_거래처주문 버튼
		{
			customer_order co_form = new customer_order(this);
			co_form.Show();
		}
		private void button20_Click(object sender, EventArgs e) //발주등록 버튼
		{
			string o_pac_barcode, o_r_barcode, o_c_id, o_e_id;
			o_pac_barcode = tb_o_pac_barcode.Text.ToString();
			o_e_id = cb_o_e_id.Text.ToString();
			o_c_id = cb_o_c_id.Text.ToString();

			// 데이터 입력 쿼리
			string sql;
			int listbox_length = listBox_o_r_barcode.Items.Count;

			for (int i = 0; i < listbox_length; i++)
			{
				o_r_barcode = listBox_o_r_barcode.Items[i].ToString();
				sql = "INSERT INTO packing(pac_barcode, r_barcode, e_id, c_id) VALUES('" + o_pac_barcode;
				sql += "','" + o_r_barcode + "','" + o_e_id + "','" + o_c_id + "');";
				// 데이터 업데이트 쿼리
				sql += "UPDATE real_product ";
				sql += "SET r_status = '출고' WHERE r_barcode = '" + o_r_barcode + "'";
				cmd.CommandText = sql;
				cmd.ExecuteNonQuery();
			}
			tb_o_p_id.Text = "";
			listBox_o_r_barcode.Text = "";
			cb_o_e_id.Text = "";
			cb_o_c_id.Text = "";
			tb_o_co_quntity.Text = "";
			listBox_o_r_barcode.Items.Clear();
			textBox3.Text = "";

			listview();
		}
		private void button24_Click(object sender, EventArgs e) //발주탭 담당자 변경
		{
			//발주탭 담당자 수정 - 패킹DB 사원id 변경
			string e_id, pac_barcode;
			pac_barcode = tb_o_u_pac_barcode.Text;
			e_id = cb_o_u_e_id.Text;

			// 데이터 업데이트 쿼리
			string sql = "UPDATE packing ";
			sql += "SET e_id = '" + e_id + "' WHERE pac_barcode = '" + pac_barcode + "'";
			cmd.CommandText = sql;
			cmd.ExecuteNonQuery();
			listview();
		}
		private void button12_Click(object sender, EventArgs e) //발주 취소 버튼
		{
			//발주취소 - 패킹DB 삭제, 거래처주문DB 주문상태 수정(완료->진행)
			string pac_barcode;
			pac_barcode = label31.Text;

			//패킹DB 삭제 쿼리
			string sql = "DELETE FROM packing WHERE pac_barcode= '" + pac_barcode + "';";
			// 거래처DB 주문상태 수정 쿼리
			sql += "UPDATE customer_order SET co_status = '진행' ";
			sql += "WHERE num = '" + pac_barcode + "'";
			//생산품DB 제품상태 수정 쿼리(출고->적재)
			sql += "UPDATE real_product r inner join packing p on r.r_barcode = p.r_barcode ";
			sql += "SET r_status = '적재' WHERE pac_barcode = '" + pac_barcode + "'";
			cmd.CommandText = sql;
			cmd.ExecuteNonQuery();
			listview();
		}
		private void button30_Click(object sender, EventArgs e) //발주취소 버튼
		{
			panel_o_cancel.Location = new Point(732, 67);
			panel_o_cancel.Visible = true;
			panel_o_update.Visible = false;
		}
		private void button31_Click(object sender, EventArgs e) //발주탭 담당자변경(상단)
		{
			panel_o_cancel.Visible = false;
			panel_o_update.Visible = true;
		}
		private void button29_Click(object sender, EventArgs e)//발주등록버튼
		{
			panel_order.Visible = true;
		}
		private void button18_Click(object sender, EventArgs e)//발주등록 X버튼
		{
			panel_order.Visible = false;
		}
		private void button10_Click_1(object sender, EventArgs e) //발주취소창 x버튼
		{
			panel_o_cancel.Visible = false;
		}
		private void button13_Click(object sender, EventArgs e)//발주 담당자변경창 x버튼
		{
			panel_o_update.Visible = false;
		}	
		private void button6_Click(object sender, EventArgs e) //입고 담당자 변경
		{
			//입고탭 담당자 수정 - 생산품DB 사원id 변경
			string e_id, r_barcode;
			r_barcode = tb_i_barcode_u.Text;
			e_id = cb_i_e_id_e.Text;

			// 데이터 업데이트 쿼리
			string sql = "UPDATE real_product ";
			sql += "SET e_id = '" + e_id + "' WHERE r_barcode = '" + r_barcode + "'";
			cmd.CommandText = sql;
			cmd.ExecuteNonQuery();
			listview();
		}
		private void btn_p_id_find_Click_1(object sender, EventArgs e) //제품코드 중 제조일자가 빠른 순
		{
			string o_p_id, o_co_quntity;
			o_p_id = tb_o_p_id.Text.ToString();
			o_co_quntity = tb_o_co_quntity.Text.ToString();

			//리스트박스에 채우기
			listBox_o_r_barcode.Items.Clear();
			string[] R_barcodes = { };
			// 데이터 조회 쿼리
			string sql = "SELECT r_barcode FROM real_product WHERE p_id = '" + o_p_id + "' and r_status = '적재'";
			sql += " ORDER BY r_MFD LIMIT " + o_co_quntity;
			cmd.CommandText = sql;
			reader = cmd.ExecuteReader();
			while (reader.Read())
			{
				string o_r_barcode = (string)reader["r_barcode"];
				Array.Resize(ref R_barcodes, R_barcodes.Length + 1);
				R_barcodes[R_barcodes.Length - 1] = o_r_barcode;
			}
			reader.Close();

			listBox_o_r_barcode.Items.AddRange(R_barcodes);
		}
        private void button14_Click(object sender, EventArgs e) //발주등록_완료버튼
        {
            string o_pac_barcode = tb_o_pac_barcode.Text.ToString();
            // 데이터 업데이트 쿼리
            string sql = "UPDATE customer_order ";
            sql += "SET co_status = '완료' ";
            sql += "WHERE num = '" + o_pac_barcode + "'";
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
			tb_o_pac_barcode.Text = "";


		}
		/////////////////////////////////////////////////////////////////////////////////////////////////////
		///메인폼 드래그 이벤트 설정/////////////////////////////////////////////////////////////////////////
		/////////////////////////////////////////////////////////////////////////////////////////////////////
		private void wms_MouseDown(object sender, MouseEventArgs e)
		{
			//폼이동
			mousePoint = new Point(e.X, e.Y);
		}
		private void wms_MouseMove(object sender, MouseEventArgs e)
		{
			//폼이동
			if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
			{
				Location = new Point(this.Left - (mousePoint.X - e.X), this.Top - (mousePoint.Y - e.Y));
			}
		}

		private void cb_o_u_e_id_SelectedIndexChanged(object sender, EventArgs e)
		{
			//사원명 tb 채우기
			string[] ENames = { };
			string sql = "select e_name from employee where e_id = '" + cb_o_u_e_id.Text + "'";
			cmd.CommandText = sql;
			reader = cmd.ExecuteReader();
			while (reader.Read())
			{
				string e_name = reader["e_name"].ToString();
				Array.Resize(ref ENames, ENames.Length + 1);
				ENames[ENames.Length - 1] = e_name;
			}
			textBox2.Text = ENames[0];
			reader.Close();
		}

		private void cb_o_e_id_SelectedIndexChanged(object sender, EventArgs e)
		{
			//사원명 tb 채우기
			string[] ENames = { };
			string sql = "select e_name from employee where e_id = '" + cb_o_e_id.Text + "'";
			cmd.CommandText = sql;
			reader = cmd.ExecuteReader();
			while (reader.Read())
			{
				string e_name = reader["e_name"].ToString();
				Array.Resize(ref ENames, ENames.Length + 1);
				ENames[ENames.Length - 1] = e_name;
			}
			textBox3.Text = ENames[0];
			reader.Close();
		}

		private void cb_i_e_id_e_SelectedIndexChanged(object sender, EventArgs e)
		{
			//사원명 tb 채우기
			string[] ENames = { };
			string sql = "select e_name from employee where e_id = '" + cb_i_e_id_e.Text + "'";
			cmd.CommandText = sql;
			reader = cmd.ExecuteReader();
			while (reader.Read())
			{
				string e_name = reader["e_name"].ToString();
				Array.Resize(ref ENames, ENames.Length + 1);
				ENames[ENames.Length - 1] = e_name;
			}
			textBox4.Text = ENames[0];
			reader.Close();
		}

		private void cb_i_e_id_r_SelectedIndexChanged(object sender, EventArgs e)
		{
			//사원명 tb 채우기
			string[] ENames = { };
			string sql = "select e_name from employee where e_id = '" + cb_i_e_id_r.Text + "'";
			cmd.CommandText = sql;
			reader = cmd.ExecuteReader();
			while (reader.Read())
			{
				string e_name = reader["e_name"].ToString();
				Array.Resize(ref ENames, ENames.Length + 1);
				ENames[ENames.Length - 1] = e_name;
			}
			textBox5.Text = ENames[0];
			reader.Close();
		}

		private void button24_Click_1(object sender, EventArgs e) //통계탭 돋보기 버튼 클릭
		{
			listView_daily.Clear();
			listView_daily.BeginUpdate(); //리스트뷰 업데이트 시작
			listView_daily.View = View.Details;
			listView_daily.Columns.Add("", 0, HorizontalAlignment.Center);
			listView_daily.Columns.Add("제품코드", 130, HorizontalAlignment.Center);
			listView_daily.Columns.Add("제품명", 130, HorizontalAlignment.Center);
			listView_daily.Columns.Add("입고량", 130, HorizontalAlignment.Center);
			listView_daily.Columns.Add("출고량", 130, HorizontalAlignment.Center);

			//일일통계 조회 쿼리
			string p_id, p_name, cnt_indate, cnt_outdate;
			string sql = "select a.p_id, a.p_name, ifnull(b.cnt_indate,'0') as cnt_indate, ifnull(c.cnt_outdate,'0') as cnt_outdate ";
			sql += "from (SELECT p_id, p_name FROM product) a ";
			sql += "left JOIN (select p_id, count(w_indate) as cnt_indate FROM warehouse w ";
			sql += "inner join real_product r on w.r_barcode=r.r_barcode ";
			sql += "where left(w_indate,10)='" + tb_date.Text + "' group by p_id) b on a.p_id=b.p_id ";
			sql += "left join (select p_id, count(w_outdate) as cnt_outdate FROM warehouse w ";
			sql += "inner join real_product r on w.r_barcode=r.r_barcode ";
			sql += "where left(w_outdate,10)='" + tb_date.Text + "' group by p_id) c on a.p_id=c.p_id";
			cmd.CommandText = sql;
			reader = cmd.ExecuteReader();
			ListViewItem item;
			string[] PIDNames = { };
			while (reader.Read())
			{
				p_id = reader["p_id"].ToString();
				p_name = reader["p_name"].ToString();
				cnt_indate = reader["cnt_indate"].ToString();
				cnt_outdate = reader["cnt_outdate"].ToString();

				Array.Resize(ref PIDNames, PIDNames.Length + 1);
				PIDNames[PIDNames.Length - 1] = p_name;

				item = new ListViewItem();
				item.SubItems.Add(p_id);
				item.SubItems.Add(p_name);
				item.SubItems.Add(cnt_indate);
				item.SubItems.Add(cnt_outdate);

				listView_daily.Items.Add(item);
			}
			reader.Close();
			listView_daily.EndUpdate();

			//chart 설정
			chart_daily.ChartAreas[0].AxisY.Title = "개수";
			//chart_daily.AxisFactor.XAxis.Interval = 5;
			for (int i = 1; i < PIDNames.Length+1; i++)
			{
				string series = "series" + i;
				chart_daily.Series.Add(series);
				chart_daily.Series[series].Points.Clear();
				chart_daily.Series[series].Points.Add(int.Parse(listView_daily.Items[i-1].SubItems[3].Text));
				chart_daily.Series[series].Points.Add(int.Parse(listView_daily.Items[i-1].SubItems[4].Text));
			}
			

			//chart
			// Monitoring탭 Chart 설정
			//chart_daily.ChartAreas[0].AxisX.Title = "Count";
			//chart_daily.ChartAreas[0].AxisY.Title = "Product";
			//chart_daily.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bar;
			//chart_daily.Series[0].Points.Clear();

			//chart_daily.Series[0].Points.Add(cnt_indate);

		}

		private void tb_date_MouseClick(object sender, MouseEventArgs e)
		{
			tb_date.Text = "";
			tb_date.ForeColor = Color.Black;
		}
	}
}