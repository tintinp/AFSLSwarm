using SwarmLibrary;
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
using System.Net;
using System.Net.Sockets;
using System.Diagnostics;

namespace SwarmUI
{
    public partial class Swarm : Form
    {
        private COMPort Ports = new COMPort();
        BindingSource PortsBinding1 = new BindingSource();
        BindingSource PortsBinding2 = new BindingSource();
        private string IP = "";

        public Swarm()
        {
            InitializeComponent();
            SetupCOM();

            PortsBinding1.DataSource = Ports.PortList;
            COMPortSel1.DataSource = PortsBinding1;
            PortsBinding2.DataSource = Ports.PortList;
            COMPortSel2.DataSource = PortsBinding2;

            
        }

        private void SetupCOM()
        {
            string[] ports = SerialPort.GetPortNames();
            foreach (string port in ports)
            {
                Ports.PortList.Add(port);
            }
        }

        private void Browse_Click(object sender, EventArgs e)
        {
            OpenFileDialog OpenFile = new OpenFileDialog();
            DialogResult result = OpenFile.ShowDialog(); // Show the dialog.
            Console.WriteLine(OpenFile.FileName);
            fileName.Text = OpenFile.FileName;

        }

        // Run Python Script
        private void Run_Click(object sender, EventArgs e)
        {
            string Command = String.Format("/c python " + fileName.Text + " --connect1={0}:14550 --connect2={0}:14552", IP);
            Console.WriteLine(Command);
            Process process2 = new Process();
            process2.StartInfo.FileName = "cmd.exe";
            process2.StartInfo.Arguments = Command;
            process2.StartInfo.UseShellExecute = false;
            process2.StartInfo.CreateNoWindow = false;
            process2.Start();
        }

        private void COMPortSel1_IndexChanged(object sender, EventArgs e)
        {

        }

        private void COMPortSel2_IndexChanged(object sender, EventArgs e)
        {

        }

        // Run mavproxy to connect to COM port
        private void Connect_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            string whichButton = button.Name;
            string PortName = "";
            string Command = "";

            // Get IP address
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    IP = ip.ToString();
                }
            }

            // Choose which COM port
            switch (whichButton)
            {
                case "connect1":
                    PortName = (string)COMPortSel1.SelectedItem;
                    Command = String.Format("/c" + "mavproxy.exe --master=\"{0}\" --out=\"udp: {1}:14550\" --out=\"udp: {1}:14551\"", PortName, IP);
                    break;
                case "connect2":
                    PortName = (string)COMPortSel2.SelectedItem;
                    Command = String.Format("/c" + "mavproxy.exe --master=\"{0}\" --out=\"udp: {1}:14552\" --out=\"udp: {1}:14553\"", PortName, IP);
                    break;
                default:
                    break;
            }
            
            // Run Command Prompt
            Console.WriteLine(Command);
            Console.WriteLine(button.Name);
            Process process1 = new Process();
            process1.StartInfo.FileName = "cmd.exe";
            process1.StartInfo.Arguments = Command;
            process1.StartInfo.UseShellExecute = false;
            process1.StartInfo.CreateNoWindow = false;
            process1.Start();
        }
    }
}
