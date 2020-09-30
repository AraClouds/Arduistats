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
using System.Net;


// Todo refaire UI + ajouter un bouton expand controls
// ui arduino + blink si new visit


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
        string _storedUserOut;
        bool isHttpConnected;
        //Config
        int editHours;
        const string url = "https://www.araclouds.com/ct/users.txt";
        int refresh = 5000;
        //Config

        public MainWindow()
        {
            InitializeComponent();
            OutToRichLog("Frame", "Starting engine...");
            InitBase();
            // init storage
            storage = new LocalStorage();
            /*  var doc = webload.Load(url);*/
        }

        private void InitBase()
        {
            ports = SerialPort.GetPortNames();
            OutToRichLog("Frame", "Checking serial ports...");
            //afficher log loading
            //afficher les ports
            OutToRichLog("Com", "Ports found : ");
            GetPortInformation();
            foreach (string port in ports)
            {
                comboBox1.Items.Add(port);
                
                if (ports[0] != null)
                {
                    comboBox1.SelectedItem = ports[0];
                }
            }

        }

        async static Task<string> GetTxt()
        {
            HttpClient client = new HttpClient();
            string result = await client.GetStringAsync(url);
            if (result != null)
            {
             //   ishttpConnected = true;
                
            }
          //  Debug.WriteLine(result);
           
            // TODO il faut sortir tout le txt et le traiter autre part
            return result;
   
        }

        public void InitTimer()
        {
            timer1 = new Timer();
            timer1.Tick += new EventHandler(Timer1_Tick);
            timer1.Interval = refresh; // in miliseconds
            timer1.Start();
        }

        // CheckDifferentCounting : si la variable reçue du txt est la même que la précédente, ne rien faire.
        public void CheckDifferentCounting(string checkreceiveduser, string checkwithcurrentuser)
        {
            Debug.WriteLine(userout + "   " + _storedUserOut);
            if (checkreceiveduser != checkwithcurrentuser)
            {
                OutToRichLog("HTTP", "Different count detected");
                OutToRichLog("COM", "Sending to arduino");
                //  DoSomething(); //write
                port.WriteLine(userout);

                _storedUserOut = userout;
            }
            else
            {
               // OutToRichLog("PHP", "No different count detected");
              //  userout = _storedUserOut;
            }
        }

        private async void Timer1_Tick(object sender, EventArgs e)
        {
             try
            {

                string fetchedTxt = await GetTxt();
                char ch = '|';
                int freq = fetchedTxt.Count(f => (f == ch));
                var key = "phpusers";
                var value = freq;
                userout = freq.ToString();
                httpStatus.Text = "Connected";
                CheckDifferentCounting(userout, _storedUserOut);
                string lastWrittenUser = fetchedTxt.Substring(fetchedTxt.LastIndexOf("=") + 1);
                string[] splitString = lastWrittenUser.Split(',');
                editHours = 2;
                int receivedHour;
                receivedHour = Int16.Parse(splitString[3]);
                int veritableHour = receivedHour += editHours;
                // splitString[3] += editHours;
                //   string sYear = splitString[1].Trim();
                //  int iYear = Int16.Parse("100");


                //   int year = lastWrittenUser.IndexOf(',');
                //    int month = lastWrittenUser.IndexOf(',', lastWrittenUser.IndexOf(',') + 1);
                //la date d'édition du fichier nous donnera le timeout visiteur
                // convertir les deux en secondes, soustraire l'actual time avec le lastwrittenUser et si var time > x secondes write 0 a arduino
                DateTime a = new DateTime(
                    Int16.Parse(splitString[0]),
                    Int16.Parse(splitString[1]),
                    Int16.Parse(splitString[2]),
                    veritableHour,
                    Int16.Parse(splitString[4]),
                    Int16.Parse(splitString[5]));
               // DateTime b = new DateTime();
                var now = DateTime.Now;
                double secs = now.Subtract(a).TotalSeconds;
                // secs.Split(',')[0].Trim();
                string convert = secs.ToString();
                string number = convert.Split(',')[0].Trim();
                Debug.WriteLine(now.Subtract(a).TotalSeconds);

                //  Debug.WriteLine(lastWrittenUser);
                Debug.WriteLine("FINAL GAP : " + number + "\n");
            //    Debug.WriteLine("renowwww date time : " + now + "\n");
                //    Debug.WriteLine("year : " + year + "\n");
                //     Debug.WriteLine("month : " + month + "\n\n");
                //    Debug.WriteLine("splitString" + sYear + "\n");


                //    
                //  OutToRichLog("abouger", "write from timer : " + userout);
            }
            catch (HttpRequestException ex)
            {

                
     //    Debug.WriteLine("ex.Data : " + ex.Data + "\n");
      //          Debug.WriteLine("ex.HResult : " + ex.HResult + "\n");
      //          Debug.WriteLine("ex.Message : " + ex.Message + "\n");
                timer1.Stop();
                httpStatus.Text = "Not connected";
                var httpmessage = ex.Message;
                OutToRichLog("HTTP", httpmessage.ToString());

                
                isHttpConnected = false;
            }
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


        public string GetPortInformation()
        {
            ManagementClass processClass = new ManagementClass("Win32_PnPEntity");
            ManagementObjectCollection Ports = processClass.GetInstances();
            foreach (ManagementObject property in Ports)
            {
                var name = property.GetPropertyValue("Name");
                if (name != null && name.ToString().Contains("USB") && name.ToString().Contains("COM"))
                {
                    var portInfo = new SerialPortInfo(property);
                    //Thats all information i got from port.
                    //Do whatever you want with this information
                    OutToRichLog("Com", "" + name);
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
                OutToRichLog("Com","Closing " + port.PortName);

            }
            else if (port.IsOpen == false) {
                btn_serielConnect.Text = "Disconnect";
                port.Open();
                AllowComControls();
                //faire un fade ou un truc qui montre que c co

                OutToRichLog("Com", "Opening " + port.PortName + "...");
                isConnected = true;
                OutToRichLog("HTTP", "Trying to read txt file.. ");
                InitTimer();
            }

            text_iSconnected.Text = port.IsOpen.ToString();

        }

        private void AllowComControls()
        {
            //get info from current device (com)
            //test write
            Btn_GetCurPortInfo.Enabled = true;
            btn_listenToArduino.Enabled = true;
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




        private void btn_readShit_Click(object sender, EventArgs e)
        {
            
         //      outToRichLog(phpUser.ToString);

        }

        private void SerialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
      
                string line = port.ReadLine();
                this.BeginInvoke(new LineReceivedEvent(LineReceived), line);
                RichLogBox.AppendText(line + "\r\n");
                RichLogBox.ScrollToCaret();
       //     outToRichLog(line);
              //  Debug.WriteLine(line);

           
        }

        private delegate void LineReceivedEvent(string line);

        private void LineReceived(string line)
        {
            //What to do with the received line here
            Debug.WriteLine("test + line : " + line);
            OutToRichLog("Com", "Received from " + port.PortName + line);

        }


        private void Btn_StartPHPfetch_Click(object sender, EventArgs e)
        {
            // TODO RICH START PHP LOOP
            InitTimer();
        }

        private void Btn_GetCurPortInfo_Click(object sender, EventArgs e)
        {
            //test
            string selectedPort = comboBox1.GetItemText(comboBox1.SelectedItem);
            GetCurrentPortInformation(selectedPort);
            var porttostring = port.IsOpen;
            //ajouter port name et tout
        //    OutToRichLog(porttostring.ToString());
            
            OutToRichLog("Com", "Current port info : " + porttostring.ToString());
        }
        void OutToRichLog(string type, string output)
        {
            if (type == "HTTP")
            {
                RichLogBox.ForeColor = System.Drawing.Color.LightGreen;
                RichLogBox.AppendText("@ " + output + "\r\n");
                RichLogBox.ScrollToCaret();
            }
            else if (type == "Com")
            {
                RichLogBox.ForeColor = System.Drawing.Color.SkyBlue;
                RichLogBox.AppendText("● " + output + "\r\n");
                RichLogBox.ScrollToCaret();
            }
            else
            {
                RichLogBox.AppendText(output + "\r\n");
                RichLogBox.ScrollToCaret();
            }
           
        }

 
    }
}
