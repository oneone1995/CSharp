using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            IPHostEntry IpEntry = Dns.GetHostEntry(Dns.GetHostName());
            string myIp = "";
            foreach (IPAddress ip in IpEntry.AddressList)
            {
                if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    //System.Diagnostics.Debug.WriteLine("LocalIPadress: " + ip);
                    myIp = ip.ToString();
                    break;
                }
            }
            System.Diagnostics.Process.Start("http://192.168.2.165/portal/logon.htm?userip=" + myIp);
            this.Close();
        }
    }
}
