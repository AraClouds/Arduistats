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
using System.Configuration;


// Todo refaire UI + ajouter un bouton expand controls
// ui arduino + blink si new visit
// TODO parse plusieurs varaibles dans le arduino > live visit + elapsed time since user
// TODO remplacer 0 par ... sur le display arduino

// TODO Clean again and again the richlog


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
        public string userDomain = "";
        public string txtloc = "/ct/users.txt"; // var :: domainInput + "ct/users.txt"if (Uri.IsWellFormedUriString("https://www.google.com", UriKind.Absolute))
        int refresh = 5000;
        private bool advancedDebug;
        private double customUserHours = 0;
        private double secondstoadd = 0;
        private string finalurl;
        //   private FormSettings frmSettings1 = new FormSettings();
        //Config
        public static AppSettingsSection AppConfig { get; private set; } = null;

        public MainWindow()
        {
            InitializeComponent();
            OutToRichLog("Frame", "Starting engine...");
            InitBase();
            AppConfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None).AppSettings;
           // AppDomain.CurrentDomain.SetData("APP_CONFIG_FILE", "Arduistats.config");
            this.FormClosing += new FormClosingEventHandler(MainWindow_FormClosing);

            // init storage
            Debug.WriteLine("-------DIRECTORY");
            Debug.WriteLine(System.Runtime.InteropServices.RuntimeEnvironment.GetRuntimeDirectory());
            /*  var doc = webload.Load(url);*/
            Debug.WriteLine("-------DIRECTORY");


            var myValue = AppConfig.Settings["userdomain"].Value;
            Debug.WriteLine(myValue);

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

        async  Task<string> GetTxt()
        {
          //  string tamereee = userDomain;
            HttpClient client = new HttpClient();
            string result = await client.GetStringAsync(userDomain + txtloc);
            if (result != null)
            {
                //   ishttpConnected = true;
                OutToRichLog("HTTP", "ITS OKAY FROM TASK : ");

            }

            return result;
   
        }

        public void InitTimer()
        {
            timer1 = new Timer();
            timer1.Tick += new EventHandler(Timer1_Tick);
            timer1.Interval = refresh; // in miliseconds
            timer1.Start();
            // TODO send is connected write toa rduino
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
                if (advancedDebug == true) { OutToRichLog("HTTP", "CheckDifferentCounting() New heartbeat received\nSent " + userout + " to arduino\n"); }

                _storedUserOut = userout;
            }
            else
            {
                if (advancedDebug == true) { OutToRichLog("HTTP", "CheckDifferentCounting() ELSE"); }
             //   port.WriteLine("0");
                // OutToRichLog("PHP", "No different count detected");
                  userout = _storedUserOut;
            }
        }
        /// <summary>
        /// Récupère la totalité du txt
        /// 
        /// This is mostly a copy and paste of a bit I found online (probably stack exchange)
        /// </summary>
        private async void Timer1_Tick(object sender, EventArgs e)
        {
             try
            {
                Debug.WriteLine("----------Timer1_Tick > TRY-----------");
                string fetchedTxt = await GetTxt();
                char ch = '|';
                int freq = fetchedTxt.Count(f => (f == ch));
                var key = "phpusers";
                var value = freq;
                userout = freq.ToString();
                httpStatus.Text = "Connected";
                


                string lastWrittenUser = fetchedTxt.Substring(fetchedTxt.LastIndexOf("=") + 1);
                Debug.WriteLine("lastWrittenUser : " + lastWrittenUser);
                string[] splitString = lastWrittenUser.Split(',');
            
                // la date d'édition du fichier nous donnera le timeout visiteur
                // convertir les deux en secondes, soustraire l'actual time avec le lastwrittenUser et si var time > x secondes write 0 a arduino
                DateTime a = new DateTime(
                    Int16.Parse(splitString[0]),
                    Int16.Parse(splitString[1]),
                    Int16.Parse(splitString[2]),
                    Int16.Parse(splitString[3]),
                    Int16.Parse(splitString[4]),
                    Int16.Parse(splitString[5]));
                Debug.WriteLine("DateTime a =  " + a);
                // DateTime b = new DateTime();
                var now = DateTime.Now;
                double secs = now.Subtract(a).TotalSeconds; // ajouter les x secs avant la soustraction
                // on ajoute le time reçu du serveur et on rajoute l'input user
                double variableSecs = secs -= secondstoadd; // TODO brainfuck
                string convert = variableSecs.ToString();
                string secGap = convert.Split(',')[0].Trim();
                Debug.WriteLine("SECGAPSECGAP" + secGap);
                int isecGap = Int16.Parse(secGap);
                Debug.WriteLine(now.Subtract(a).TotalSeconds);
                advancedDebug = true;
                // mettre en variable option
                if (isecGap > 40) {
                    userout = "0";
                    CheckDifferentCounting(userout, _storedUserOut);
                    if (advancedDebug == true) { OutToRichLog("HTTP", "No visitors since " + isecGap + " secs\n Sent 0 to arduino" ); }
                  //  port.WriteLine("0");

                } else
                {
                    CheckDifferentCounting(userout, _storedUserOut);
                  
                }
              //  port.WriteLine(secGap);
                Debug.WriteLine("FINAL GAP : " + secGap + "\n");
            }
            catch (HttpRequestException ex)
            {

               
               // timer1.Stop();
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
                // passer la value disconneced à l'arduino
                btn_readShit.Enabled = true;
                isConnected = false;
                OutToRichLog("Com","Closing " + port.PortName);

            }
            else if (port.IsOpen == false) {
                btn_serielConnect.Text = "Disconnect";

                
                try
                {
                    port.Open();
                    AllowComControls();
                    //faire un fade ou un truc qui montre que c co
                    // TODO passer la value connected à l'arduino
                    OutToRichLog("Com", "Opening " + port.PortName + "...");
                    isConnected = true;
                    OutToRichLog("HTTP", "Trying to read txt file.. ");
                    InitTimer();
                }
                catch (UnauthorizedAccessException unauth)
                {
                    OutToRichLog("Com", "Port is open somewhere else \n" + unauth );
                }
                
             
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
               // string myfiles = Rich
                RichLogBox.ForeColor = System.Drawing.Color.LightGreen;
                RichLogBox.AppendText("@ " + output + "\r\n");
                RichLogBox.ScrollToCaret();


         /*       int line = 0;
                foreach (string HTTP in myfiles)
                {
                    // Whatever method you want to choose a color, here
                    // I'm just alternating between red and blue
                    RichLogBox.SelectionColor =
                        line % 2 == 0 ? Color.Red : Color.Blue;

                    // AppendText is better than rtb.Text += ...
                    RichLogBox.AppendText(HTTP + "\r\n");
                    line++;
                }*/

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

        // TODO ColorTextBoxeSelection()

        private void ColorTextBoxeSelection(RichTextBox textBox, string s, Color textColor, Color backColor)
        {
            int start = 0, current = 0;
            RichTextBoxFinds options = RichTextBoxFinds.MatchCase;
            start = textBox.Find(s, start, options);
            while (start >= 0)
            {
                textBox.SelectionStart = start;
                textBox.SelectionLength = s.Length;
                textBox.SelectionColor = textColor;
                textBox.SelectionBackColor = backColor;

                current = start + s.Length;
                if (current < textBox.TextLength)
                    start = textBox.Find(s, current, options);
                else
                    break;
            }
        }

        private void Inpt_ActualServerTime_TextChanged(object sender, EventArgs e)
        {

        }



      
        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            /* e.Cancel = MessageBox.Show("Are you sure you want to really exit ? ",
                        "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No;*/
            CloseAll();

        }

        private void CloseAll()
        {
            port.Close();
            //TODO Disconnected app on arduino (bitmap)
            Debug.WriteLine("CLOSINGCLOSINGCLOSINGCLOSINGCLOSING : ");
        }

        /// <summary> Inp_NumericHours_ValueChanged
        /// C'est juste matrixant
        /// </summary>
        private void Inp_NumericHours_ValueChanged(object sender, EventArgs e)
        {
            var actualH = Inp_NumericHours.Text;
            var todouble = Int16.Parse(actualH);
            // customUserHours = Inpt_ActualServerTime.Text;
            //    TimeSpan timespan = TimeSpan.FromHours(todouble);
            secondstoadd = TimeSpan.FromHours(todouble).TotalSeconds;
            //  secondstoadd = timespan;


            OutToRichLog("TEST", "customUserHours " + secondstoadd);
            Debug.WriteLine("timespantimespantimespan: " + secondstoadd);
            //Inpt_ActualServerTime.
        }

        private void Inp_Domain_TextChanged(object sender, EventArgs e)
        {
            userDomain = Inp_Domain.Text; 
        }


        /// <summary>
        /// Au clic on corrige le format, on "try" la requête http, si la requête est différente de null (souvent 404, mauvais input / htaccess)
        /// on vérifie si un domaine a déjà été enregistré, si oui on fait rien, si la variable est à "none" on l'enregistre
        /// </summary>
        private async void BtnVerifyUsrUrl_Click(object sender, EventArgs e)
        {
            
            if (Uri.IsWellFormedUriString(userDomain, UriKind.Absolute))
            {
                //corrige le format
                var _domain = new Uri(userDomain);
                var _domfinaloutput = new Uri(_domain, txtloc);
                OutToRichLog("TEST", "Trying to connect...  \n" + _domfinaloutput);

                try
                {
                    HttpClient client = new HttpClient();
                    string result = await client.GetStringAsync(_domfinaloutput);
                    if (result != null)
                    {
                        // on regarde si y'a déjà quelque chose d'enregistré
                        var myDomain = AppConfig.Settings["userdomain"].Value;

                        if (myDomain == "none") // value vierge, on enregistre le domaine
                        {

                            string _domValid = _domfinaloutput.ToString();

                            Configuration config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
                            config.AppSettings.Settings.Add("userdomain", _domValid);

                            // save que si c'est différent de "none"
                            //save que si l'url est véritablement vérifiée et fonctionnelle
                            config.Save(ConfigurationSaveMode.Minimal);
                            var myValue = AppConfig.Settings["userdomain"].Value;
                            // OutToRichLog("SETUP", " Verified OK  " + domainuser);
                            OutToRichLog("SETUP", " myValue AppConfig.Settings  " + myValue);
                        }
                        else
                        {

                        }


                    }


                }
                catch
                {
                    OutToRichLog("SETUP", "404 :  " + userDomain + txtloc);
                }

            }
        }


    }
}
