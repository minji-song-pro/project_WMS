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
	public partial class customer_order : Form
	{
		wms wms_form;
		public customer_order()
		{
			InitializeComponent();
		}
		public customer_order(wms _wms)
		{
			InitializeComponent();
			wms_form = _wms;
		}

		//전역변수
		int co_num=1;
		string sql;

		//폼이동 변수 선언
		private Point mousePoint;

		String strConn = "Server=10.10.15.154;Uid=user;Pwd=1234;Database=warehousedb;CHARSET=UTF8";
		MySqlConnection conn;
		MySqlCommand cmd;
		MySqlDataReader reader;

		private void customer_order_Load(object sender, EventArgs e)
		{
			conn = new MySqlConnection(strConn);
			conn.Open();
			cmd = new MySqlCommand("", conn);

			listview_co();

			//콤보박스에 채우기(c_id)
			cb_co_c_id.Items.Clear();
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

			cb_co_c_id.Items.AddRange(CIDNames);

			//거래처주문 num부여
			try
			{
				//co_num
				string[] CONum = { };
				sql = "select num from customer_order order by num desc limit 1";
				cmd.CommandText = sql;
				reader = cmd.ExecuteReader();
				while (reader.Read())
				{
					string conum = reader["num"].ToString();
					Array.Resize(ref CONum, CONum.Length + 1);
					CONum[CONum.Length - 1] = conum;
				}
				reader.Close();
				co_num = int.Parse(CONum[0]) + 1;
				tb_co_num.Text = co_num.ToString();
			}
			catch
			{
				tb_co_num.Text = "1";
			}
		}

		private void btn_customer_order_Click(object sender, EventArgs e) //거래처 주문 등록
		{
			//거래처 주문 등록
			string co_c_id, co_p_id, co_quntity, co_stock;
			co_c_id = cb_co_c_id.Text.ToString();
			co_p_id = tb_co_p_id.Text.ToString();
			co_quntity = tb_co_quntity.Text.ToString();
			co_stock = lb_stock.Text.ToString();

			if (int.Parse(co_quntity) > int.Parse(co_stock))
			{
				MessageBox.Show("수량을 다시 입력해주세요.");
			}
			else
			{
				//데이터 입력 쿼리
				string sql = "INSERT INTO customer_order(num, c_id, p_id, co_quntity, co_status) ";
				sql += "VALUES(" + co_num + ",'" + co_c_id + "','" + co_p_id + "','" + co_quntity + "', '진행')";
				cmd.CommandText = sql;
				cmd.ExecuteNonQuery();

				//거래처주문 데이터 조회 쿼리
				string num;
				sql = "SELECT num, p_id, co_quntity,c_id FROM customer_order where co_status='진행' and c_id=" + co_c_id;
				cmd.CommandText = sql;
				reader = cmd.ExecuteReader();
				ListViewItem item_co;
				while (reader.Read())
				{
					num = reader["num"].ToString();
					co_p_id = reader["p_id"].ToString();
					co_quntity = reader["co_quntity"].ToString();

					item_co = new ListViewItem();
					item_co.SubItems.Add(num);
					item_co.SubItems.Add(co_p_id);
					item_co.SubItems.Add(co_quntity);

					listView_customer_ordering.Items.Add(item_co);
				}
				reader.Close();
				listView_customer_ordering.EndUpdate();

                tb_co_p_id.Text = "";
				tb_co_quntity.Text = "";
                lb_stock.Text = "";

                wms_form.listview();
				listview_co();
			}
		}
		private void btn_customer_order_OK_Click(object sender, EventArgs e)
		{
			co_num += 1;
			tb_co_num.Text = co_num.ToString();
			Close();
		}
		private void customer_order_FormClosed(object sender, FormClosedEventArgs e)
		{
			conn.Close();
		}

		private void button17_Click(object sender, EventArgs e) //x버튼
		{
			Close();
		}

		private void listView_stock_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
		{
			e.DrawDefault = true;
		}

		private void listView_stock_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
		{
			if (this.listView_stock.SelectedIndices.Contains(e.ItemIndex))

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

		private void listView_stock_SelectedIndexChanged(object sender, EventArgs e)
		{
			//리스트뷰 선택행 텍스트박스에 넣기
			int indexnum;
			indexnum = listView_stock.FocusedItem.Index;
			tb_co_p_id.Text = listView_stock.Items[indexnum].SubItems[1].Text;
			lb_stock.Text = listView_stock.Items[indexnum].SubItems[2].Text;
		}
		public void listview_co()
		{
			///////////////////////////////////////////////////////////////////////////////////////////
			///물품재고 리스트뷰 설정/////////////////////////////////////////////////////////////////
			//////////////////////////////////////////////////////////////////////////////////////////
			listView_stock.Clear();
			listView_stock.BeginUpdate(); //리스트뷰 업데이트 시작
			listView_stock.View = View.Details;
			listView_stock.Columns.Add("", 0, HorizontalAlignment.Center);
			listView_stock.Columns.Add("제품코드", 80, HorizontalAlignment.Center);
			listView_stock.Columns.Add("주문가능수량", 100, HorizontalAlignment.Center);

			//재고량 데이터 조회 쿼리
			string s_p_id, cnt_stock, cnt_order, cnt_able_buy;
			//창고 재고
			sql = "select * from(select p_id, count(r_barcode) as cnt_stock from real_product r ";
			sql += "where r_status = '적재' group by p_id) as s";
			sql += " left outer join";
			sql += "(select p_id, sum(co_quntity) as cnt_order from customer_order group by p_id) as co";
			sql += " on s.p_id = co.p_id";
			cmd.CommandText = sql;
			reader = cmd.ExecuteReader();
			ListViewItem item_stock;
			while (reader.Read())
			{
				s_p_id = reader["p_id"].ToString();
				cnt_stock = reader["cnt_stock"].ToString();
				cnt_order = reader["cnt_order"].ToString();
				if (cnt_order == "")
				{
					cnt_order = "0";
				}
				cnt_able_buy = (int.Parse(cnt_stock) - int.Parse(cnt_order)).ToString();

				item_stock = new ListViewItem();
				item_stock.SubItems.Add(s_p_id);
				item_stock.SubItems.Add(cnt_able_buy);

				listView_stock.Items.Add(item_stock);
			}
			reader.Close();
			listView_stock.EndUpdate();

			///////////////////////////////////////////////////////////////////////////////////////////
			///거래처주문 리스트뷰 설정////////////////////////////////////////////////////////////////
			//////////////////////////////////////////////////////////////////////////////////////////
			listView_customer_ordering.Clear();
			listView_customer_ordering.BeginUpdate(); //리스트뷰 업데이트 시작
			listView_customer_ordering.View = View.Details;
			listView_customer_ordering.Columns.Add("", 0, HorizontalAlignment.Center);
			listView_customer_ordering.Columns.Add("주문번호", 70, HorizontalAlignment.Center);
			listView_customer_ordering.Columns.Add("제품코드", 70, HorizontalAlignment.Center);
			listView_customer_ordering.Columns.Add("수량", 50, HorizontalAlignment.Center);
			listView_customer_ordering.Columns.Add("거래처코드", 80, HorizontalAlignment.Center);

			//거래처주문 데이터 조회 쿼리
			string num, co_p_id, co_quntity,co_c_id;
			sql = "SELECT num, p_id, co_quntity,c_id FROM customer_order where co_status='진행' and c_id='" + cb_co_c_id.Text + "'";
			cmd.CommandText = sql;
			reader = cmd.ExecuteReader();
			ListViewItem item_co;
			while (reader.Read())
			{
				num = reader["num"].ToString();
				co_p_id = reader["p_id"].ToString();
				co_quntity = reader["co_quntity"].ToString();
				co_c_id = reader["c_id"].ToString();

				item_co = new ListViewItem();
				item_co.SubItems.Add(num);
				item_co.SubItems.Add(co_p_id);
				item_co.SubItems.Add(co_quntity);
				item_co.SubItems.Add(co_c_id);

				listView_customer_ordering.Items.Add(item_co);
			}
			reader.Close();
			listView_customer_ordering.EndUpdate();
		}

		private void customer_order_MouseDown(object sender, MouseEventArgs e)
		{
			//폼이동
			mousePoint = new Point(e.X, e.Y);
		}

		private void customer_order_MouseMove(object sender, MouseEventArgs e)
		{
			//폼이동
			if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
			{
				Location = new Point(this.Left - (mousePoint.X - e.X), this.Top - (mousePoint.Y - e.Y));
			}
		}

		private void cb_co_c_id_SelectedIndexChanged(object sender, EventArgs e)
		{
			listview_co();
		}
	}
}
