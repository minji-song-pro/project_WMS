using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using MySql.Data.MySqlClient;

namespace WMS
{
	public partial class rfid : Form
	{
		InputDevice id;
		int NumberOfKeyboards;

		public rfid()
		{
			InitializeComponent();
			getAvailablePorts();

			id = new InputDevice(Handle);
			NumberOfKeyboards = id.EnumerateDevices();
			id.KeyPressed += new InputDevice.DeviceEventHandler(m_KeyPressed);
		}
		//add
		protected override void WndProc(ref Message message)
		{
			if (id != null)
			{
				id.ProcessMessage(message);
			}
			base.WndProc(ref message);
		}

		private void m_KeyPressed(object sender, InputDevice.KeyControlEventArgs e)
		{
			//#1.바코드리더기1번
			if (e.Keyboard.deviceName == "\\\\?\\HID#VID_AC90&PID_3002#7&2b1cd6bf&0&0000#{884b96c3-56ef-11d1-bc8c-00a0c91405dd}")
			{
				tb_barcode1.Focus();
			}
			//#2.바코드리더기2번
			else if (e.Keyboard.deviceName == "\\\\?\\HID#VID_AC90&PID_3002#6&341fd876&0&0000#{884b96c3-56ef-11d1-bc8c-00a0c91405dd}")
			{
				tb_barcode2.Focus();
			}
			//#3.바코드리더기3번
			else if (e.Keyboard.deviceName == "\\\\?\\HID#VID_AC90&PID_3002#7&341fd876&0&0000#{884b96c3-56ef-11d1-bc8c-00a0c91405dd}")
			{
				tb_barcode3.Focus();
			}
			//#4.바코드리더기4번
			else if (e.Keyboard.deviceName == "\\\\?\\HID#VID_AC90&PID_3002#7&1863261a&0&0000#{884b96c3-56ef-11d1-bc8c-00a0c91405dd}")
			{
				tb_barcode4.Focus();
			}
			else
			{
				textBox5.Focus();
			}
		}
		//add end

		//전역변수 설정
		string dataIn;  //Add RS232C from Atmega128A
		String strConn = "Server=10.10.15.154;Uid=user;Pwd=1234;Database=warehousedb;CHARSET=UTF8";
		MySqlConnection conn;
		MySqlCommand cmd;
		MySqlDataReader reader;
		string e_id, e_name, e_car;

		private void Form1_Load(object sender, EventArgs e)
		{
			conn = new MySqlConnection(strConn);
			conn.Open();
			cmd = new MySqlCommand("", conn);
		}

		private void Form1_FormClosed(object sender, FormClosedEventArgs e)
		{
			conn.Close();
		}

		void getAvailablePorts()
		{
			string[] ports = SerialPort.GetPortNames();
			cb_Port.Items.AddRange(ports);
		}

		private void btn_OpenPort_Click(object sender, EventArgs e) //Port열기
		{
			try
			{
				if (cb_Port.Text == "" || cb_Bps.Text == "")
				{
					tb_ReceiveData.Text = "Please Select Port Setting!!";
				}
				else
				{
					serialPort1.PortName = cb_Port.Text;
					serialPort1.BaudRate = Convert.ToInt32(cb_Bps.Text);
					serialPort1.Open();
					progressBar_PortStatus.Value = 100;
					lb_ComPort.Text = " ON";
					btn_OpenPort.Enabled = false;
					btn_ClosePort.Enabled = true;
				}
			}
			catch (UnauthorizedAccessException)
			{
				tb_ReceiveData.Text = "UnauthorizedAccessException Occurs!!";
			}
		}
		private void btn_ClosePort_Click(object sender, EventArgs e) //Port닫기
		{
			serialPort1.Close();
			progressBar_PortStatus.Value = 0;
			lb_ComPort.Text = "OFF";
			btn_OpenPort.Enabled = true;
			btn_ClosePort.Enabled = false;
			tb_ReceiveData.Text = "";
		}
		private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e) //Port Data읽기
		{
			string data = serialPort1.ReadExisting();
			dataIn += data;
			if (data == "\n")
			{
				this.Invoke(new EventHandler(ShowData));
			}
		}
		private void ShowData(object sender, EventArgs e)    //Port Data textbox에 뿌리기
		{
			tb_ReceiveData.AppendText(dataIn);

			// rfid 사원증 태그 할 경우
			if (dataIn.Contains("e_id"))
			{
				string[] aryE_id = dataIn.Split(':');
				e_id = aryE_id[aryE_id.Length - 2];
				string r_barcode = "", pac_barcode = "";

				//위치가 입고장일 때
				if (cb_location.Text == "입고장")
				{
					//사원증을 태그한 사원이 가지고 있는 생산품 조회 쿼리
					r_barcode = "";
					string sql = "SELECT r_barcode,e_name,e_car FROM real_product r inner join employee e on r.e_id= e.e_id ";
					sql += "WHERE r.r_status='입고' AND r.e_id ='" + e_id + "'";
					cmd.CommandText = sql;
					reader = cmd.ExecuteReader();

					//리스트뷰 설정
					lb_Name.Text = "";
					lb_CarNum.Text = "";
					listView_sawon.Clear();
					listView_sawon.BeginUpdate(); //리스트뷰 업데이트 시작
					listView_sawon.View = View.Details;
					listView_sawon.Columns.Add("생산품바코드정보", 150, HorizontalAlignment.Center);
					ListViewItem item; //각 행데이터

					e_name = ""; //미등록카드 태그 시 메세지박스 출력

					while (reader.Read())
					{
						r_barcode = (string)reader["r_barcode"];
						e_name = (string)reader["e_name"];
						e_car = (string)reader["e_car"];

						lb_Name.Text = e_name;
						lb_CarNum.Text = e_car;

						item = new ListViewItem(r_barcode);
						listView_sawon.Items.Add(item);
					}
					reader.Close();
					listView_sawon.EndUpdate(); //리스트뷰 업데이트 끝

					panel_tag.Visible = false;
					lb_show.Visible = false;
					checkBox1.Visible = false;

					//물품이 없을 경우 메세지박스 출력
					if (r_barcode == "")
					{
						MessageBox.Show("물품이 없습니다.");
					}
				}

				//위치가 출고장1일 경우
				else if (cb_location.Text == "출고장1")
				{
					//사원증을 태그한 사원이 가지고 있는 출고상품 조회 쿼리
					r_barcode = "";
					string sql = "SELECT r_barcode,e_name,e_car FROM real_product r inner join employee e on r.e_id= e.e_id ";
					sql += "WHERE r.r_status='출고' AND r.e_id ='" + e_id + "'";
					cmd.CommandText = sql;
					reader = cmd.ExecuteReader();

					e_name = ""; //미등록카드 태그 시 메세지박스 출력

					//리스트뷰 설정
					lb_Name.Text = "";
					lb_CarNum.Text = "";
					listView_sawon.Clear();
					listView_sawon.BeginUpdate(); //리스트뷰 업데이트 시작
					listView_sawon.View = View.Details;
					listView_sawon.Columns.Add("생산품바코드정보", 150, HorizontalAlignment.Center);
					ListViewItem item; //각 행데이터

					while (reader.Read())
					{
						r_barcode = reader["r_barcode"].ToString();
						e_name = (string)reader["e_name"];
						e_car = (string)reader["e_car"];

						lb_Name.Text = e_name;
						lb_CarNum.Text = e_car;

						item = new ListViewItem(r_barcode);
						listView_sawon.Items.Add(item);
					}
					reader.Close();
					listView_sawon.EndUpdate(); //리스트뷰 업데이트 끝

					panel_tag.Visible = false;

					lb_show.Visible = true;
					checkBox1.Visible = true;

					//창고DB 출고장번호 업데이트 (출고장번호:1)
					sql = "update warehouse w JOIN packing p ON w.r_barcode = p.r_barcode ";
					sql += "SET w_outlocation = '1' WHERE p.pac_barcode is not null AND  w.w_outdate is null AND p.e_id = '" + e_id + "'";
					cmd.CommandText = sql;
					cmd.ExecuteNonQuery();

					//물품이 없을 경우 메세지박스 출력
					if (r_barcode == "")
					{
						MessageBox.Show("물품이 없습니다.");
					}
				}

				//위치가 출고장2일 경우
				else if (cb_location.Text == "출고장2")
				{
					//사원증을 태그한 사원이 가지고 있는 출고상품 조회 쿼리
					r_barcode = "";
					string sql = "SELECT r_barcode,e_name,e_car FROM real_product r inner join employee e on r.e_id= e.e_id ";
					sql += "WHERE r.r_status='출고' AND r.e_id ='" + e_id + "'";
					cmd.CommandText = sql;
					reader = cmd.ExecuteReader();

					e_name = ""; //미등록카드 태그 시 메세지박스 출력

					//리스트뷰 설정
					lb_Name.Text = "";
					lb_CarNum.Text = "";
					listView_sawon.Clear();
					listView_sawon.BeginUpdate(); //리스트뷰 업데이트 시작
					listView_sawon.View = View.Details;
					listView_sawon.Columns.Add("생산품바코드정보", 150, HorizontalAlignment.Center);
					ListViewItem item; //각 행데이터

					while (reader.Read())
					{
						r_barcode = reader["r_barcode"].ToString();
						e_name = (string)reader["e_name"];
						e_car = (string)reader["e_car"];

						lb_Name.Text = e_name;
						lb_CarNum.Text = e_car;

						item = new ListViewItem(r_barcode);
						listView_sawon.Items.Add(item);
					}
					reader.Close();
					listView_sawon.EndUpdate(); //리스트뷰 업데이트 끝

					panel_tag.Visible = false;

					lb_show.Visible = true;
					checkBox1.Visible = true;

					//창고DB 출고장번호 업데이트 (출고장번호:2)
					sql = "update warehouse w JOIN packing p ON w.r_barcode = p.r_barcode ";
					sql += "SET w_outlocation = '2' WHERE p.pac_barcode is not null AND  p.w_outdate is null AND p.e_id = '" + e_id + "'";
					cmd.CommandText = sql;
					cmd.ExecuteNonQuery();

					//물품이 없을 경우 메세지박스 출력
					if (r_barcode == "")
					{
						MessageBox.Show("물품이 없습니다.");
					}
				}
				else
				{
					MessageBox.Show("위치를 선택해주세요");
				}

				//미등록카드 태그 시 메세지박스 출력
				if (e_name == "" && r_barcode != "")
				{
					panel_tag.Visible = true;
					MessageBox.Show("미등록 사원입니다.");
				}
			}
		}

		private void tb_barcode1_KeyUp(object sender, KeyEventArgs e) //(하차장) 바코드리더기1 동작
		{
			string r_barcode;

			//바코드 리드
			if (e.KeyCode == Keys.Enter) //엔터키 입력 시 
			{
				if (tb_barcode1.Text == "")
				{
					return;
				}
				r_barcode = tb_barcode1.Text;

				//입고예정물품 -> 창고
				if (cb_location.Text == "입고장")
				{
					//창고DB 입력 쿼리(생산품바코드,입고일자,창고번호)
					string w_location, w_indate, p_condition, w_section, p_id;
					string many = "3", least = "5";
					w_indate = DateTime.Now.ToString("yyyy-MM-dd-HH:mm:ss");

					string sql = "SELECT p_condition FROM product p inner join real_product r on p.p_id=r.p_id WHERE  r_barcode= '" + r_barcode + "'";
					cmd.CommandText = sql;
					reader = cmd.ExecuteReader();
					reader.Read();//어차피 1건
					p_condition = reader["p_condition"].ToString();
					reader.Close();

					sql = "SELECT p_id FROM real_product WHERE  r_barcode = '" + r_barcode + "'";
					cmd.CommandText = sql;
					reader = cmd.ExecuteReader();
					reader.Read();//어차피 1건
					p_id = reader["p_id"].ToString();
					reader.Close();

					// 창고에서 섹션별 분류 과정
					if (p_condition == "저온보관")
					{
						w_section = "B";
					}
					else if (p_id == many)
					{
						w_section = "A";
					}
					else if (p_id == least)
					{
						w_section = "D";
					}
					else
					{
						w_section = "C";
					}

					//창고번호 지정
					sql = "SELECT MIN(w_location) FROM wnum WHERE w_status = 'x' AND w_section='" + w_section + "'";
					cmd.CommandText = sql;
					reader = cmd.ExecuteReader();
					reader.Read();//어차피 1건
					w_location = reader["MIN(w_location)"].ToString();
					reader.Close();

					sql = "INSERT INTO warehouse(r_barcode, w_location,w_section, w_indate)";
					sql += " VALUES('" + r_barcode + "', '" + w_location + "','" + w_section + "', '" + w_indate + "');";

					//창고번호DB 업데이트 쿼리
					sql += "UPDATE wnum SET w_status = 'o' WHERE w_location = '" + w_location + "'and w_section='" + w_section + "'";
					cmd.CommandText = sql;
					cmd.ExecuteNonQuery();

					//생산품DB 업데이트 쿼리(물류상태:입고->적재)
					sql = "UPDATE real_product SET r_status = '적재대기' ";
					sql += "WHERE r_barcode = '" + r_barcode + "'";
					cmd.CommandText = sql;
					cmd.ExecuteNonQuery();

					tb_barcode1.Text = "";

					sql = "SELECT r_barcode,e_name,e_car FROM real_product r inner join employee e on r.e_id= e.e_id ";
					sql += "WHERE r.r_status='입고' AND r.e_id ='" + e_id + "'";
					cmd.CommandText = sql;
					reader = cmd.ExecuteReader();

					//리스트뷰 설정
					lb_Name.Text = "";
					lb_CarNum.Text = "";
					listView_sawon.Clear();
					listView_sawon.BeginUpdate(); //리스트뷰 업데이트 시작
					listView_sawon.View = View.Details;
					listView_sawon.Columns.Add("생산품바코드정보", 150, HorizontalAlignment.Center);
					ListViewItem item; //각 행데이터

					e_name = ""; //미등록카드 태그 시 메세지박스 출력

					while (reader.Read())
					{
						r_barcode = (string)reader["r_barcode"];
						e_name = (string)reader["e_name"];
						e_car = (string)reader["e_car"];

						lb_Name.Text = e_name;
						lb_CarNum.Text = e_car;

						item = new ListViewItem(r_barcode);
						listView_sawon.Items.Add(item);
					}
					reader.Close();
					listView_sawon.EndUpdate(); //리스트뷰 업데이트 끝
				}
				else
				{
					MessageBox.Show("위치를 확인해주세요.");
				}

				tb_barcode1.Text = "";
			}
		}

		private void tb_barcode2_KeyUp(object sender, KeyEventArgs e) //(하역장-컨베이어벨트)바코드리더기2에서 바코드 읽을 때
		{
			string barcode2_value;
			bool barcode2_flag = true;

			//바코드 리드
			if (e.KeyCode == Keys.Enter) //엔터키 입력 시 
			{
				if (tb_barcode2.Text == "")
				{
					return;
				}
				barcode2_value = tb_barcode2.Text;

				//해당물품이 창고에 적재하는 물품이 맞는지 확인
				//DB
				string[] ary_barcode2 = { };
				string sql = "SELECT r_barcode FROM real_product WHERE r_status = '적재대기'";
				cmd.CommandText = sql;
				reader = cmd.ExecuteReader();
				while (reader.Read())
				{
					string r_barcode = (string)reader["r_barcode"];
					Array.Resize(ref ary_barcode2, ary_barcode2.Length + 1);
					ary_barcode2[ary_barcode2.Length - 1] = r_barcode;
				}
				reader.Close();

				//비교(해당물품과 적재대기 물품목록)
				for (int i = 0; i < ary_barcode2.Length; i++)
				{
					if (barcode2_value == ary_barcode2[i])
					{
						//창고번호 조회
						string w_location = "", w_section = "";
						sql = "SELECT w_section, w_location FROM warehouse WHERE r_barcode = '" + barcode2_value + "'";
						cmd.CommandText = sql;
						reader = cmd.ExecuteReader();
						while (reader.Read())
						{
							w_section = (string)reader["w_section"];
							w_location = (string)reader["w_location"];
						}
						reader.Close();
						string w_name = w_section + w_location;

						//AVR (LCD창고번호 출력 명령)
						//serialPort1.WriteLine(w_name + Environment.NewLine);
						serialPort1.WriteLine(w_name);

						//MessageBox.Show("창고번호는 " + w_name + "입니다");

						//생산품DB 업데이트 쿼리(물류상태:적재대기->적재)
						sql = "UPDATE real_product SET r_status = '적재' WHERE r_barcode = '" + barcode2_value + "'";
						cmd.CommandText = sql;
						cmd.ExecuteNonQuery();

						barcode2_flag = false;
						break;
					}
				}
				tb_barcode2.Text = "";

				if (barcode2_flag == true) //적재대기 물품목록과 일치하지 않으면 
				{
					//AVR (LCD창고번호 출력 명령)
					serialPort1.WriteLine("None");
					//MessageBox.Show("None");
				}
				barcode2_flag = true;
			}
		}

		private void tb_barcode3_KeyUp(object sender, KeyEventArgs e) //(출고장) 바코드리더기3에서 바코드 읽을 때
		{
			string barcode3_value;

			//바코드 리드
			if (e.KeyCode == Keys.Enter) //엔터키 입력 시 
			{
				if (tb_barcode3.Text == "")
				{
					return;
				}
				barcode3_value = tb_barcode3.Text;

				//해당물품의 출고장 확인
				//출고장 조회
				string w_outlocation = "";
				string sql = "SELECT w_outlocation FROM warehouse WHERE r_barcode = '" + barcode3_value + "'";
				cmd.CommandText = sql;
				reader = cmd.ExecuteReader();
				while (reader.Read())
				{
					w_outlocation = (string)reader["w_outlocation"];
				}
				reader.Close();

				if (w_outlocation == "1")
				{
					//AVR (출력 명령)
					serialPort1.WriteLine("1");

					//MessageBox.Show("1");
				}
				else
				{
					//AVR (출력 명령)
					serialPort1.WriteLine("2");

					//MessageBox.Show("2");
				}
				tb_barcode3.Text = "";
			}
		}

		private void checkBox1_CheckedChanged(object sender, EventArgs e)
		{

			if (checkBox1.Checked == true)
			{
				this.Size = new Size(1229, 441);
				Boxing();
			}
			else
			{
				this.Size = new Size(785, 441);
			}
		}

		private void tb_barcode4_KeyUp(object sender, KeyEventArgs e) //(출고장) 바코드리더기4에서 바코드 읽을 때

		{
			//(출고장) 바코드리더기4 // 출고물품 -> 배송
			//바코드 리드
			string r_barcode;

			if (e.KeyCode == Keys.Enter) //엔터키 입력 시 
			{
				if (tb_barcode4.Text == "")
				{
					return;
				}

				r_barcode = tb_barcode4.Text;

				//출고물품 -> 배송
				if (cb_location.Text == "출고장1" || cb_location.Text == "출고장2")
				{
					//창고DB 입력 쿼리(출고일자)
					string w_outdate = DateTime.Now.ToString("yyyy-MM-dd-HH:mm:ss");
					string sql = "UPDATE warehouse ";
					sql += "SET w_outdate = '" + w_outdate + "' WHERE r_barcode = '" + r_barcode + "';";

					//생산품DB 업데이트 쿼리(물류상태:배송)
					sql += "UPDATE real_product ";
					sql += "SET r_status = '배송' ";
					sql += "WHERE r_barcode = '" + r_barcode + "';";

					//생산품DB 업데이트 쿼리(배송일자)
					string delivery_date = DateTime.Now.ToString("yyyy-MM-dd");
					sql += "UPDATE packing SET delivery_date = '" + delivery_date + "' ";
					sql += "WHERE r_barcode = '" + r_barcode + "'";
					cmd.CommandText = sql;
					cmd.ExecuteNonQuery();

					tb_barcode4.Text = "";

					//리스트뷰 리셋
					//사원증을 태그한 사원이 가지고 있는 출고상품 조회 쿼리
					sql = "SELECT r_barcode,e_name,e_car FROM real_product r inner join employee e on r.e_id= e.e_id ";
					sql += "WHERE r.r_status='출고' AND r.e_id ='" + e_id + "'";
					cmd.CommandText = sql;
					reader = cmd.ExecuteReader();

					//리스트뷰 설정
					lb_Name.Text = "";
					lb_CarNum.Text = "";
					listView_sawon.Clear();
					listView_sawon.BeginUpdate(); //리스트뷰 업데이트 시작
					listView_sawon.View = View.Details;
					listView_sawon.Columns.Add("생산품바코드정보", 150, HorizontalAlignment.Center);
					ListViewItem item; //각 행데이터

					while (reader.Read())
					{
						r_barcode = reader["r_barcode"].ToString();
						e_name = (string)reader["e_name"];
						e_car = (string)reader["e_car"];

						lb_Name.Text = e_name;
						lb_CarNum.Text = e_car;

						item = new ListViewItem(r_barcode);
						listView_sawon.Items.Add(item);
					}
					reader.Close();
					listView_sawon.EndUpdate(); //리스트뷰 업데이트 끝
				}
			}
		}
		public void Boxing()
		{
			//박스정보 출력
			//물품 개수
			int other = 0;
			string cnt = "", cnt_ice = "", cnt_fragile = "";
			string[] bar_bar = { };
			string sql = "SELECT count(r_barcode) as cnt FROM real_product r ";
			sql += "inner join employee e on r.e_id= e.e_id WHERE r.r_status='출고' AND r.e_id ='" + e_id + "'";
			cmd.CommandText = sql;
			reader = cmd.ExecuteReader();
			while (reader.Read())
			{
				cnt = reader["cnt"].ToString();

				lb_Product_cnt.Text = cnt;
			}
			reader.Close();
			//저온보관 물품 개수
			sql = "select count(pac.r_barcode) as cnt_ice from packing pac inner join real_product r on pac.r_barcode = r.r_barcode ";
			sql += "inner join product p on r.p_id = p.p_id where p.p_condition = '저온보관' and pac.e_id = '" + e_id + "'";
			cmd.CommandText = sql;
			reader = cmd.ExecuteReader();
			while (reader.Read())
			{
				cnt_ice = reader["cnt_ice"].ToString();

				lb_Product_cnt_ice.Text = cnt_ice;
			}
			reader.Close();
			//취급주의 물품 개수
			sql = "select count(pac.r_barcode) as cnt_fragile from packing pac inner join real_product r on pac.r_barcode = r.r_barcode ";
			sql += "inner join product p on r.p_id = p.p_id where p.p_fragile='o' and pac.e_id = '" + e_id + "'";
			cmd.CommandText = sql;
			reader = cmd.ExecuteReader();
			while (reader.Read())
			{
				cnt_fragile = reader["cnt_fragile"].ToString();

				lb_Product_cnt_fragile.Text = cnt_fragile;
			}
			reader.Close();

			lb_box_ice.Text = cnt_ice;
			lb_box_fragile.Text = cnt_fragile;
			lb_prduct_other.Text = (Convert.ToInt32(cnt) - Convert.ToInt32(cnt_ice) - Convert.ToInt32(cnt_fragile)).ToString();
			other = Convert.ToInt32(lb_prduct_other.Text);

			//박스개수제안
			switch (other)
			{
				case 1:
					lb_box_other.Text = "2 box *1";
					label34.BackColor = Color.Red;
					break;
				case 2:
					lb_box_other.Text = "2 box *1";
					label34.BackColor = Color.Red;
					label33.BackColor = Color.Blue;
					break;
				case 3:
					lb_box_other.Text = "4 box *1";
					label32.BackColor = Color.Purple;
					label31.BackColor = Color.Green;
					label30.BackColor = Color.Yellow;
					break;
				case 4:
					lb_box_other.Text = "4 box *1";
					label32.BackColor = Color.Red;
					label31.BackColor = Color.Red;
					label30.BackColor = Color.Blue;
					label29.BackColor = Color.Green;
					break;
				case 5:
					lb_box_other.Text = "4 box *1, 2 box *1";
					label32.BackColor = Color.Red;
					label31.BackColor = Color.Red;
					label30.BackColor = Color.Blue;
					label29.BackColor = Color.Green;
					label34.BackColor = Color.Orange;
					break;
				case 6:
					lb_box_other.Text = "4 box *1, 2 box *1";
					label32.BackColor = Color.Red;
					label31.BackColor = Color.Red;
					label30.BackColor = Color.Blue;
					label29.BackColor = Color.Green;
					label34.BackColor = Color.Orange;
					label33.BackColor = Color.Orange;
					break;
				case 7:
					lb_box_other.Text = "8 box *1";
					break;
				case 8:
					lb_box_other.Text = "8 box *1";
					break;
			}
		}
		//sql = "SELECT r_barcode FROM real_product r order by p_weight";
		//sql += "inner join employee e on r.e_id= e.e_id inner join product on r.p_id=product.p_id WHERE r.r_status='출고' AND r.e_id ='" + e_id + "'";
		//cmd.CommandText = sql;
		//reader = cmd.ExecuteReader();
		//while (reader.Read())
		//{
		//	string bar_bar1 = (string)reader["r_barcode"];
		//	Array.Resize(ref bar_bar, bar_bar.Length + 1);
		//	bar_bar[bar_bar.Length - 1] = bar_bar1;
		//}
		//reader.Close();

		//for (int i = 0; i < bar_bar.Length; i++)
		//{
		//	 label21.Text = bar_bar[i];
		//}
	}
}