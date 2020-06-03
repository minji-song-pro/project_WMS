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
	public partial class main : Form
	{
		public main()
		{
			InitializeComponent();
		}

		private void main_Load(object sender, EventArgs e)
		{

		}

		private void btn_wms_Click(object sender, EventArgs e)
		{
			wms wms_form = new wms();
			wms_form.Show();
		}

		private void btn_rfid_Click(object sender, EventArgs e)
		{
			rfid rfid_form = new rfid();
			rfid_form.Show();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Sensor sensor_form = new Sensor();
			sensor_form.Show();
		}
	}
}