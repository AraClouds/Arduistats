using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Management;
using Hanssens.Net;

namespace Arduistats
{
    public partial class MainWindow : Form
    {
        bool isConnected;
        String[] ports;
        string selectedPort;
        SerialPort port;
        private Timer timer1;
        public static object storage;
        string userout;
        //Config
        const string url = "https://www.araclouds.com/ct/users.txt";
        int refresh = 5000;
        //Config
        

        public MainWindow()
        {
           // outToRichLog("before component");
            InitializeComponent();
            outToRichLog("Engine loaded...");
            Debug.WriteLine("Engine loaded... \n");
             //  InitTimer();
            outToRichLog("Checking serial ports...");
            initBase();
            // init storage
            storage = new LocalStorage();

            foreach (string port in ports)
            {
                comboBox1.Items.Add(port);
                Debug.WriteLine(port);
                if (ports[0] != null)
                {
                    comboBox1.SelectedItem = ports[0];
                }
            }
            /*  var doc = webload.Load(url);*/



        }

        private void initBase()
        {
            ports = SerialPort.GetPortNames();
            outToRichLog("Checking serial ports...");
            Debug.WriteLine("Ports : \n");
            Debug.WriteLine(ports);
            //afficher log loading
            //afficher les ports

        }

        async static Task<string> getTxt()
        {
            HttpClient client = new HttpClient();
            string result = await client.GetStringAsync(url);

            char ch = '|';
            int freq = result.Count(f => (f == ch));

            var key = "phpusers";
            var value = freq;

            return freq.ToString();
   
        }

        public void InitTimer()
        {
            timer1 = new Timer();
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Interval = refresh; // in miliseconds
            timer1.Start();
        }

        private async void timer1_Tick(object sender, EventArgs e)
        {
             
            userout = await getTxt();
            /*  string data_rx = port.ReadLine();*/
            Debug.WriteLine("TEST STRING ASYNC    "+ userout);
            outToRichLog("write from timerTick" + userout);
        }


        public string GetCurrentPortInformation(string selectedport)
        {
            ManagementClass processClass = new ManagementClass("Win32_PnPEntity");
            ManagementObjectCollection Ports = processClass.GetInstances();
            foreach (ManagementObject property in Ports)
            {
                var name = property.GetPropertyValue("Name");
                var desc = property.GetPropertyValue("Description");
                var status = property.GetPropertyValue("Status");
               

                if (name != null && name.ToString().Contains(selectedport))
                {
                    var portInfo = new SerialPortInfo(property);
                    Debug.WriteLine(status);
                    Debug.WriteLine(desc);
                    Debug.WriteLine(portInfo);
                    //Thats all information i got from port.
                    //Do whatever you want with this information
                }
            }
            return string.Empty;
        }

        private void btn_serielConnect_Click(object sender, EventArgs e)
        {

            selectedPort = comboBox1.GetItemText(comboBox1.SelectedItem);
            port = new SerialPort(selectedPort, 9600, Parity.None, 8, StopBits.One);
            port.DtrEnable = true;
            port.RtsEnable = true;
            text_iSconnected.Text = isConnected.ToString();


            text_iSconnected.Text = port.IsOpen.ToString();

            if (port.IsOpen == true) {
                //  outToRichLog("֍ Connected to " + selectedPort);
                //       SerialDisconnect();
                port.Close();
                btn_readShit.Enabled = true;
                isConnected = false;
             //   Debug.WriteLine("FILS DE PUTE EST IL FERME APRES PORT.CLOSE   " + port.IsOpen);
            }
            else if (port.IsOpen == false) {
                btn_serielConnect.Text = "Disconnect";
                
             //   btn_serielConnect.Enabled = true;
                outToRichLog("► Port of XXX is open");
                port.Open();
           //     Debug.WriteLine("FILS DE PUTE EST IL OUVERT APRES PORT.OPEN   " + port.IsOpen);
                // ça bougera dans une fonction activate
                   port.DataReceived += serialPort1_DataReceived;
                isConnected = true;

                InitTimer();
            }


            text_iSconnected.Text = port.IsOpen.ToString();


        }



        private void PortInfos_Click(object sender, EventArgs e)
        {
            string selectedPort = comboBox1.GetItemText(comboBox1.SelectedItem);
            GetCurrentPortInformation(selectedPort);
           // string a = port.ReadExisting();
          //  Debug.WriteLine(a);
        }

        private void write_Click(object sender, EventArgs e)
        {
        
        }

        void outToRichLog(string output)
        {

            


            RichLogBox.AppendText(output + "\r\n");
            RichLogBox.ScrollToCaret();
        }


        private void btn_readShit_Click(object sender, EventArgs e)
        {

            
            
            
         //      outToRichLog(phpUser.ToString);

        }

        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
      
                string line = port.ReadLine();
                this.BeginInvoke(new LineReceivedEvent(LineReceived), line);
             //   outToRichLog(line);
              //  Debug.WriteLine(line);
    
  
     
           
        }

        private delegate void LineReceivedEvent(string line);

        private void LineReceived(string line)
        {
            //What to do with the received line here
            Debug.WriteLine("test + line : " + line);
            outToRichLog(line);

       //     storage.Get(key);


            port.WriteLine(userout);
            outToRichLog("write from LineReceived" + userout);
            // progressBar1.Value = int.Parse(line);
        }


        private void btn_startphpfetch_Click(object sender, EventArgs e)
        {
            InitTimer();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //test
            var porttostring = port.IsOpen;
            outToRichLog(porttostring.ToString());
            outToRichLog(selectedPort);
        }
    }
}
