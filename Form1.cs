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
            OutToRichLog("Engine loaded...");
            Debug.WriteLine("Engine loaded... \n");
             //  InitTimer();
            OutToRichLog("Checking serial ports...");
            InitBase();
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

        private void InitBase()
        {
            ports = SerialPort.GetPortNames();
            OutToRichLog("Checking serial ports...");
            Debug.WriteLine("Ports : \n");
            Debug.WriteLine(ports);
            //afficher log loading
            //afficher les ports

        }

        async static Task<string> GetTxt()
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
            timer1.Tick += new EventHandler(Timer1_Tick);
            timer1.Interval = refresh; // in miliseconds
            timer1.Start();
        }

        private async void Timer1_Tick(object sender, EventArgs e)
        {
             
            userout = await GetTxt();
            /*  string data_rx = port.ReadLine();*/
            Debug.WriteLine("TEST STRING ASYNC    "+ userout);
            OutToRichLog("write from timerTick" + userout);
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

        private void Btn_serielConnect_Click(object sender, EventArgs e)
        {
            // TODO IMPORTANT : trouver un moyen de disconnect proprement
            selectedPort = comboBox1.GetItemText(comboBox1.SelectedItem);
            port = new SerialPort(selectedPort, 9600, Parity.None, 8, StopBits.One);
            port.DtrEnable = true;
            port.RtsEnable = true;
            text_iSconnected.Text = isConnected.ToString();


            text_iSconnected.Text = port.IsOpen.ToString();

            if (port.IsOpen == true) {

                port.Close();
                btn_readShit.Enabled = true;
                isConnected = false;

            }
            else if (port.IsOpen == false) {
                btn_serielConnect.Text = "Disconnect";
                OutToRichLog("► Port of XXX is open");
                port.Open();
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

        private void Btn_listenToArduino_Click(object sender, EventArgs e)
        {
            // TODO RICH Now let arduino Speak...
            port.DataReceived += SerialPort1_DataReceived;
        }

        void OutToRichLog(string output)
        {
            // TODO ajouter string type string output avec couleurs et charmap
            


            RichLogBox.AppendText(output + "\r\n");
            RichLogBox.ScrollToCaret();
        }


        private void btn_readShit_Click(object sender, EventArgs e)
        {

            
            
            
         //      outToRichLog(phpUser.ToString);

        }

        private void SerialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
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
            OutToRichLog(line);

       //     storage.Get(key);


            port.WriteLine(userout);
            OutToRichLog("write from LineReceived" + userout);
            // progressBar1.Value = int.Parse(line);
        }


        private void Btn_StartPHPfetch_Click(object sender, EventArgs e)
        {
            // TODO RICH START PHP LOOP
            InitTimer();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //test
            var porttostring = port.IsOpen;
            OutToRichLog(porttostring.ToString());
            OutToRichLog(selectedPort);
        }
    }
}
