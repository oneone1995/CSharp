using System;
using System.Collections;
using System.Net;
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
            ArrayList ipArray = new ArrayList();
            string myIp = "";

            foreach (IPAddress ip in IpEntry.AddressList)
            {
                if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)//ipv4的获取
                {
                    myIp = ip.ToString();
                    ipArray.Add(myIp);
                    //break;
                }
            }

            foreach(string resultIp in ipArray)//通过经验发现i-hdu分配的ip几乎是以10.开头，暂时没有其他办法，有更好的办法会改进
            {
                if(resultIp.StartsWith("10."))
                {
                    myIp = resultIp;
                    break;
                }
            }
            

            MessageBox.Show(myIp);
            System.Diagnostics.Process.Start("http://192.168.2.165/portal/logon.htm?userip=" + myIp);//用默认浏览器打开
            this.Close();
        }
    }
}
