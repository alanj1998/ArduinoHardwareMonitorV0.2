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
using OpenHardwareMonitor.Hardware;
using System.Management;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace ArduinoHardwareMonitor
{
    public partial class Form1 : Form
    {
        /*
         *  Class variables used in all methods.
         */
        //Getting access to the users computer by turning it into an object
        Computer userPc = new Computer()
        {
            CPUEnabled = true,
            RAMEnabled = true,
            HDDEnabled = true
        };

        //Necessary vars used throughout the progamme
        float cpuTemp, cpuLoad, ramClock, hddLeft;
        private SerialPort arduinoPort = new SerialPort();
        string ram, hdd, cpu;
        DateTime oldTime = DateTime.UtcNow;
        DateTime currentTime;
        int messagesSent = 0;

        /*
         *  These methods are used to initialise the programme.
         *  When the programme starts, all the elements are placed onto a windows form.
         *  Then all the active parts are initialised and added to a combo box.
         *  Then the intervals are added to the interval box.
         */
        public Form1()
        {
            InitializeComponent();
            SetInterval();
            PortInit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            userPc.Open();
        }

        private void PortInit()
        {
            try
            {
                arduinoPort.Parity = Parity.None;
                arduinoPort.DataBits = 8;
                arduinoPort.StopBits = StopBits.One;
                arduinoPort.Handshake = Handshake.None;
                arduinoPort.RtsEnable = true;
                arduinoPort.DtrEnable = true;
                portBox.Items.Clear();
                string[] pcPorts = SerialPort.GetPortNames();
                foreach (var ports in pcPorts)
                {
                    portBox.Items.Add(ports);
                }

                arduinoPort.BaudRate = 9600;
            }
            catch(Exception portInitError)
            {
                MessageBox.Show(portInitError.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetInterval()
        {
            for (int i = 100; i <= 1000; i += 100)
            {
                intrvlBox.Items.Add(i);
            }
        }

        /*
         *  The buttons here are all given a seperate method.
         *  When the connecect button is clicked, the port is opened and the timer is enabled to begin updates.
         *  When the disconnect button is clicked, then a DIS message is sent through the serial con.
         *  The email check button checks for the @ symbol in the email.
         */
        private void conBtn_Click(object sender, EventArgs e)
        {
            if (portBox.Text == "" || intrvlBox.Text == "" || !emailBox.Text.Contains("@"))
            {
                MessageBox.Show("Make sure no fields are empty and try again!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    if (!arduinoPort.IsOpen)
                    {
                        arduinoPort.PortName = portBox.Text;
                        arduinoPort.Open();
                        timer1.Enabled = true;
                        timer1.Interval = Convert.ToInt32(intrvlBox.Text);
                        status.Text = "Connected";
                        toolStatusLbl.Text = "Sending Data...";
                    }
                    conBtn.Enabled = false;
                    emailBox.Enabled = false;
                    emailCheckBtn.Enabled = false;
                    portBox.Enabled = false;
                    intrvlBox.Enabled = false;
                    disBtn.Enabled = true;
                    serverLinkLbl.Visible = true;
                    serverCheck.Enabled = false;
                }
                catch (Exception portOpenErr)
                {
                    MessageBox.Show(portOpenErr.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void disBtn_Click(object sender, EventArgs e)
        {
            try
            {
                arduinoPort.Write("DIS");
                arduinoPort.Close();
            }
            catch (Exception portCloseErr)
            {
                MessageBox.Show(portCloseErr.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            SendData(0, "DIS", "DIS", "DIS", "DIS", "DIS");
            conBtn.Enabled = true;
            emailBox.Enabled = true;
            emailCheckBtn.Enabled = true;
            portBox.Enabled = true;
            intrvlBox.Enabled = true;
            disBtn.Enabled = false;
            status.Text = "Disconnected";
            timer1.Enabled = false;
            toolStatusLbl.Text = "Connect to Arduino...";
            serverLinkLbl.Visible = false;
            serverCheck.Enabled = true;
        }

        private void emailCheckBtn_Click(object sender, EventArgs e)
        {
            var check = new EmailAddressAttribute();
            if (check.IsValid(emailBox.Text))
            {
                MessageBox.Show("Email is Good!", "Email", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Please enter a proper email address!", "Email Error!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void serverLinkLbl_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://localhost/index.html");
        }

        //When the email box is clicked, the text dissapears
        private void emailBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (emailBox.Text == "Enter Email Here...")
            {
                emailBox.Text = "";
                emailBox.Font = new Font(this.Font, FontStyle.Regular);
            }
        }

        /*
         *  Once the connect button is clicked, the timer1_tick method is deployed which works as a trigger for constamt updates.
         *  When it is time to update, the GetStatus method is deployed that gets the current temps and ram speed.
         *  It is then sent to be printed onto the arduino screen.
         */
        private void timer1_Tick(object sender, EventArgs e)
        {
            GetStatus();
        }

        private void GetStatus()
        {
            string cpuName = "";
            string ramName = "";

            foreach (var hardware in userPc.Hardware)
            {
                if (hardware.HardwareType == HardwareType.CPU)
                {
                    hardware.Update();

                    cpuName = hardware.Name;

                    foreach (var sensor in hardware.Sensors)
                    {
                        if (sensor.SensorType == SensorType.Temperature)
                        {
                            cpuTemp = sensor.Value.GetValueOrDefault();
                        }
                        if (sensor.SensorType == SensorType.Load)
                        {
                            cpuLoad = sensor.Value.GetValueOrDefault();
                            cpu = String.Format("{0:00.0}", cpuLoad);
                        }
                    }
                }
                else if (hardware.HardwareType == HardwareType.RAM)
                {
                    hardware.Update();

                    ramName = hardware.Name;
                    foreach (var sensor in hardware.Sensors)
                    {
                        if (sensor.SensorType == SensorType.Load)
                        {
                            ramClock = sensor.Value.GetValueOrDefault();
                            ram = String.Format("{0:00.0}", ramClock);
                        }
                    }
                }

                else if (hardware.HardwareType == HardwareType.HDD)
                {
                    hardware.Update();
                    foreach (var sensor in hardware.Sensors)
                    {
                        if (sensor.SensorType == SensorType.Load)
                        {
                            hddLeft = sensor.Value.GetValueOrDefault();
                            hdd = String.Format("{0:00.0}", hddLeft);
                        }
                    }
                }
            }
            arduinoPort.Write(cpuTemp + "*" + cpu + "@" + ram + "#" + hdd + "&");

            if (serverCheck.Checked)
            {
                SendData(cpuTemp, cpu, ram, hdd, cpuName, ramName);
                currentTime = DateTime.UtcNow;

                if (cpuTemp > 60 && (messagesSent == 0 || currentTime.Subtract(oldTime) > TimeSpan.FromMinutes(5)))
                {
                    SendEmail(emailBox.Text);
                    oldTime = currentTime;
                    messagesSent++;
                }
            }      
        }

        static void SendData(float cpuTemp, string cpuUsage, string ramUsage, string hddUsage, string cpuName, string ramName)
        {
            //Thanks to Robin Van Persi from stackoverflow.com for help!
            string url = "http://localhost/datacollection.php";
            string parameters = "cpuTemp=" + cpuTemp + "&cpuUse=" + cpuUsage + "&ramUse=" + ramUsage + "&hddUse=" + hddUsage + "&cpuName=" + cpuName + "&ramName=" + ramName;

            using (WebClient wc = new WebClient())
            {
                wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                wc.UploadString(url, parameters);
            }
        }

        /*
         *  If the temperature is above 60 degrees an email is sent using the Temboo and Gmail service.
         */
        private void SendEmail(string email)
        {
            using (BackgroundWorker bw = new BackgroundWorker())
            {
                bw.DoWork += new DoWorkEventHandler(delegate
                {
                    string url = "http://localhost/sendemail.php";
                    string parameters = "customerEmail=" + email + "&cpuTemp=" + cpuTemp;

                    using (WebClient wc = new WebClient())
                    {
                        {
                            wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                            wc.UploadString(url, parameters);
                        }
                    }
                });
                bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(delegate
                {
                    MessageBox.Show("Your CPU is Overheating! It is at " + cpuTemp + " degrees!\nAn email has been sent to quickly diagnose the problem!", "CPU Overheat!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                });
                bw.RunWorkerAsync();
            } 
        }
    }
}