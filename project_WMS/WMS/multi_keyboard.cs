using System.Windows.Forms;

namespace WMS
{
    public partial class Form1 : Form
    {
        InputDevice id;
        int NumberOfKeyboards;

       
        public Form1()
        {
            InitializeComponent();

            id = new InputDevice(Handle);
            NumberOfKeyboards = id.EnumerateDevices();
            id.KeyPressed += new InputDevice.DeviceEventHandler(m_KeyPressed);
            
        }
        protected override void WndProc( ref Message message )
        {
           if( id != null )
           {
               id.ProcessMessage( message );
           }
           base.WndProc( ref message );
        }

        private void m_KeyPressed(object sender, InputDevice.KeyControlEventArgs e)
        {
            lbHandle.Text = e.Keyboard.deviceHandle.ToString();
            lbType.Text = e.Keyboard.deviceType;
            lbName.Text = e.Keyboard.deviceName.Replace("&", "&&");
            lbDescription.Text = e.Keyboard.Name;
            //lbKey.Text = e.Keyboard.key.ToString();
            lbNumKeyboards.Text = NumberOfKeyboards.ToString();
            //lbVKey.Text = e.Keyboard.vKey;


            //#1.바코드리더기1번
            if (e.Keyboard.deviceName == "\\\\?\\HID#VID_AC90&PID_3002#6&341fd876&0&0000#{884b96c3-56ef-11d1-bc8c-00a0c91405dd}")
            {
                textBox1.Focus();
            }
            //#2.바코드리더기2번
            else if (e.Keyboard.deviceName == "\\\\?\\HID#VID_AC90&PID_3002#7&2e8a8ed7&0&0000#{884b96c3-56ef-11d1-bc8c-00a0c91405dd}")
            {
                textBox2.Focus();
            }
            else
            {
                textBox4.Focus();
            }
        }
        private void btnClose_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {

        }
    }
}