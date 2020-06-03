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
	public partial class Sensor : Form
	{
		public Sensor()
		{
			InitializeComponent();
			getAvailablePorts();
		}

		//전역변수 설정
		string dataIn;  // Add RS232C from Atmega128A
		String strConn = "Server=10.10.16.9;;Uid=user;Pwd=1234;Database=warehousedb;CHARSET=UTF8";
		MySqlConnection conn;
		MySqlCommand cmd;
		MySqlDataReader reader;
		string humid, vr;

		void getAvailablePorts()
		{
			string[] ports = SerialPort.GetPortNames();
			cb_Port.Items.AddRange(ports);
		}
		private void Sensor_Load(object sender, EventArgs e)
		{
			conn = new MySqlConnection(strConn);
			conn.Open();
			cmd = new MySqlCommand("", conn);

			// Monitoring탭 Chart 설정
			chart_DHT11.ChartAreas[0].AxisX.Title = "Time";
			chart_DHT11.ChartAreas[0].AxisY.Title = "Humid";
			chart_DHT11.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
			chart_DHT11.Series[0].Points.Clear();

			chart_VR.ChartAreas[0].AxisX.Title = "Time";
			chart_VR.ChartAreas[0].AxisY.Title = "VR";
			chart_VR.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
			chart_VR.Series[0].Points.Clear();

			//Sensor_log 리스트뷰
			//센서로그 리스트뷰 설정
			listView_sensor_log.Clear();
			listView_sensor_log.BeginUpdate(); //리스트뷰 업데이트 시작
			listView_sensor_log.View = View.Details;
			listView_sensor_log.Columns.Add("일시", 130, HorizontalAlignment.Center);
			listView_sensor_log.Columns.Add("센서명", 50, HorizontalAlignment.Center);
			listView_sensor_log.Columns.Add("센서값", 60, HorizontalAlignment.Center);
			listView_sensor_log.Columns.Add("이상여부", 100, HorizontalAlignment.Center);

			//센서로그 데이터 조회 쿼리
			try
			{
				string s_date, s_id, s_value, s_error;
				string sql = "SELECT s_date, s_id, s_value, s_error FROM sensor_log";
				cmd.CommandText = sql;
				reader = cmd.ExecuteReader();
				ListViewItem item;
				while (reader.Read())
				{
					s_date = reader["s_date"].ToString();
					s_id = reader["s_id"].ToString();
					s_value = reader["s_value"].ToString();
					s_error = reader["s_error"].ToString();

					item = new ListViewItem(s_date);
					item.SubItems.Add(s_id);
					item.SubItems.Add(s_value);
					item.SubItems.Add(s_error);

					listView_sensor_log.Items.Add(item);
				}
				reader.Close();
				listView_sensor_log.EndUpdate();
				this.listView_sensor_log.EnsureVisible(this.listView_sensor_log.Items.Count - 1);//마지막 아이템 선택

				sensor_error_cnt();
				ListView_s_info();
				ListView_s_error_standard();
			}
			catch { }
		}

		private void Sensor_FormClosed(object sender, FormClosedEventArgs e)
		{
			conn.Close();
		}

		private void btn_OpenPort_Click(object sender, EventArgs e)
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
					btn_OpenPort.Enabled = false;
					btn_ClosePort.Enabled = true;
				}
			}
			catch (UnauthorizedAccessException)
			{
				tb_ReceiveData.Text = "UnauthorizedAccessException Occurs!!";
			}
		}
		private void btn_ClosePort_Click(object sender, EventArgs e)
		{
			serialPort1.Close();
			progressBar_PortStatus.Value = 0;
			btn_OpenPort.Enabled = true;
			btn_ClosePort.Enabled = false;
			tb_ReceiveData.Text = "";
		}

		private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)     // Port Data읽기
		{
			string data = serialPort1.ReadExisting();
			dataIn += data;
			if (data == "\n")
			{
				this.Invoke(new EventHandler(ShowData));
			}
		}

		private void ShowData(object sender, EventArgs e)    // Port Data textbox에 뿌리기
		{
			tb_ReceiveData.AppendText(dataIn);

			if (dataIn.Contains("sensor") == true)
			{
				string[] value = dataIn.Split(':');
				humid = value[4];
				vr = value[6];

				//센서값 DB저장
				string date = DateTime.Now.ToString("yyyy-MM-dd-HH:mm:ss");
				string s_id = "1"; //DHT11
				string r_humid_error = "";

				//센서값-고장기준값 비교
				if (double.Parse(humid) > 40)
				{
					r_humid_error = "이상감지";
				}
				string sql = "INSERT INTO sensor_log(s_date, s_id, s_value,s_error) VALUES('";
				sql += date + "','" + s_id + "','" + humid + "','" + r_humid_error + "');";
				cmd.CommandText = sql;
				cmd.ExecuteNonQuery();
				sensor_error_cnt();

				//센서값 DB저장
				date = DateTime.Now.ToString("yyyy-MM-dd-HH:mm:ss");
				s_id = "2"; //VR
				string r_vr_error = "";
				if (int.Parse(vr) > 800)
				{
					r_vr_error = "이상감지";
				}
				sql = "INSERT INTO sensor_log(s_date, s_id, s_value,s_error) VALUES('";
				sql += date + "'," + s_id + "," + vr + ",'" + r_vr_error + "')";
				cmd.CommandText = sql;
				cmd.ExecuteNonQuery();

				lb_humid.Text = humid;
				lb_vr.Text = vr;
				r_humid_error = "";
				r_vr_error = "";

				Draw_Chart_Sensor();
				ListView_s_log();
				sensor_error_cnt();
			}
			dataIn = "";
		}
		private void Draw_Chart_Sensor()    //Sensor값 Chart그리기
		{
			// 차트 그리기(DHT11)
			// 데이터 조회 쿼리
			string s_time, s_date, humid, vr;
			string sql = "SELECT s_date, s_id, s_value FROM sensor_log WHERE s_id = 1 ORDER BY s_date DESC LIMIT 1;";
			cmd.CommandText = sql;
			try
			{
				reader = cmd.ExecuteReader();
				reader.Read();//어차피 1건
				s_date = reader["s_date"].ToString();
				s_time = s_date.Substring(11);
				humid = reader["s_value"].ToString();
				reader.Close();

				chart_DHT11.Series[0].Points.AddXY(s_time, humid);
			}
			catch (MySqlException)
			{
				reader.Close();
			}

			// 차트 그리기(VR)
			// 데이터 조회 쿼리
			sql = "SELECT s_date, s_id, s_value FROM sensor_log WHERE s_id = 2 ORDER BY s_date DESC LIMIT 1;";
			cmd.CommandText = sql;
			try
			{
				reader = cmd.ExecuteReader();
				reader.Read();//어차피 1건
				s_date = reader["s_date"].ToString();
				s_time = s_date.Substring(11);
				vr = reader["s_value"].ToString();
				reader.Close();

				chart_VR.Series[0].Points.AddXY(s_time, vr);
			}
			catch (MySqlException)
			{
				reader.Close();
			}
		}

		private void button11_Click(object sender, EventArgs e) //센서정보 등록
		{
			string s_name, s_location, s_true;
			s_name = tb_s_name.Text.ToString();
			s_location = tb_s_location.Text.ToString();
			s_true = tb_s_true.Text.ToString();

			// 데이터 입력 쿼리
			string sql = "INSERT INTO sensor_info(s_name, s_loca, s_true)";
			sql += " VALUES('" + s_name + "', '" + s_location + "'," + s_true + ")";
			cmd.CommandText = sql;
			cmd.ExecuteNonQuery();

			tb_s_name.Text = "";
			tb_s_location.Text = "";
			tb_s_true.Text = "";
			ListView_s_info();
		}
		public void ListView_s_info()
		{
			//센서정보 리스트뷰 설정
			listView_sensor_info.Clear();
			listView_sensor_info.BeginUpdate(); //리스트뷰 업데이트 시작
			listView_sensor_info.View = View.Details;
			listView_sensor_info.Columns.Add("센서코드", 130, HorizontalAlignment.Center);
			listView_sensor_info.Columns.Add("센서명", 130, HorizontalAlignment.Center);
			listView_sensor_info.Columns.Add("센서위치", 130, HorizontalAlignment.Center);
			listView_sensor_info.Columns.Add("정상값", 130, HorizontalAlignment.Center);

			//센서정보 데이터 조회 쿼리
			string s_id, s_name, s_location, s_true;
			String sql = "SELECT s_id, s_name, s_loca, s_true FROM sensor_info";
			cmd.CommandText = sql;
			reader = cmd.ExecuteReader();
			ListViewItem item;
			while (reader.Read())
			{
				s_id = reader["s_id"].ToString();
				s_name = reader["s_name"].ToString();
				s_location = reader["s_loca"].ToString();
				s_true = reader["s_true"].ToString();

				item = new ListViewItem(s_id);
				item.SubItems.Add(s_name);
				item.SubItems.Add(s_location);
				item.SubItems.Add(s_true);

				listView_sensor_info.Items.Add(item);
			}
			reader.Close();
			listView_sensor_info.EndUpdate();
		}

		public void ListView_s_log()
		{
			///센서로그 데이터 조회 쿼리
			string s_date, s_id, s_value, s_error;
			string sql = "SELECT s_date, s_id, s_value, s_error FROM sensor_log ORDER BY s_date DESC LIMIT 2";
			cmd.CommandText = sql;
			reader = cmd.ExecuteReader();
			ListViewItem item;
			while (reader.Read())
			{
				s_date = reader["s_date"].ToString();
				s_id = reader["s_id"].ToString();
				s_value = reader["s_value"].ToString();
				s_error = reader["s_error"].ToString();

				item = new ListViewItem(s_date);
				item.SubItems.Add(s_id);
				item.SubItems.Add(s_value);
				item.SubItems.Add(s_error);

				listView_sensor_log.Items.Add(item);
			}
			reader.Close();
			this.listView_sensor_log.EnsureVisible(this.listView_sensor_log.Items.Count - 1);//마지막 아이템 선택
		}
		public void ListView_s_error_standard()
		{
			//센서에러 리스트뷰 설정
			listView_error_standard.Clear();
			listView_error_standard.BeginUpdate(); //리스트뷰 업데이트 시작
			listView_error_standard.View = View.Details;
			listView_error_standard.Columns.Add("일시", 130, HorizontalAlignment.Center);
			listView_error_standard.Columns.Add("센서명", 50, HorizontalAlignment.Center);
			listView_error_standard.Columns.Add("고장기준값", 100, HorizontalAlignment.Center);

			//센서에러 데이터 조회 쿼리
			string error_date, s_id, error_value;
			string sql = "SELECT error_date,s_id,error_value FROM sensor_error";
			cmd.CommandText = sql;
			reader = cmd.ExecuteReader();
			ListViewItem item;
			while (reader.Read())
			{
				error_date = reader["error_date"].ToString();
				s_id = reader["s_id"].ToString();
				error_value = reader["error_value"].ToString();

				item = new ListViewItem(error_date);
				item.SubItems.Add(s_id);
				item.SubItems.Add(error_value);

				listView_error_standard.Items.Add(item);
			}
			reader.Close();
			listView_error_standard.EndUpdate();
			this.listView_error_standard.EnsureVisible(this.listView_error_standard.Items.Count - 1);//마지막 아이템 선택
		}
		public void sensor_error_cnt()
		{
			//이상감지 count
			//p_id=1
			string sql = "select count(s_error) as cnt_error_1 from sensor_log where s_error = '이상감지' and s_id = '1' group by s_id";
			cmd.CommandText = sql;
			try
			{
				reader = cmd.ExecuteReader();
				reader.Read();//어차피 1건
				string cnt_error_1 = reader["cnt_error_1"].ToString();
				reader.Close();

				lb_humid_error_cnt.Text = cnt_error_1;
			}
			catch (MySqlException)
			{
				reader.Close();
			}
			//p_id=2
			sql = "select count(s_error) as cnt_error_2 from sensor_log where s_error = '이상감지' and s_id = '2' group by s_id";
			cmd.CommandText = sql;
			try
			{
				reader = cmd.ExecuteReader();
				reader.Read();//어차피 1건
				string cnt_error_2 = reader["cnt_error_2"].ToString();
				reader.Close();

				lb_VR_error_cnt.Text = cnt_error_2;
			}
			catch (MySqlException)
			{
				reader.Close();
			}
		}
	}
}
