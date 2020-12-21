using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Buttplug.Client;
using Buttplug.Client.Connectors.WebsocketConnector;
using DeviceAddedEventArgs = Buttplug.Client.DeviceAddedEventArgs;
using Timer = System.Threading.Timer;

namespace ButtUdon
{
    public partial class Form1 : Form
    {
        readonly int _interval = 10000;
        private readonly String _appDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        private readonly String VRCFolder = "\\..\\LocalLow\\VRChat\\VRChat";
        private String FinalFolder;
        private Timer _processTimer;
        private Timer _logTimer;
        private ButtplugClient _plugClient;
        bool VRCStarted = false;
        private Task _processLookupTask;
        private StreamReader reader;
        private FileSystemWatcher fileWatcher;
        public Form1()
        {
            InitializeComponent();
            FinalFolder = Path.GetFullPath(_appDataFolder+VRCFolder);
            Console.WriteLine(FinalFolder);
            _processLookupTask = ProcessLookupTask();
            _processLookupTask.Start();
            _processLookupTask.Wait();
            Console.WriteLine("Process lookup complete");
            if (!VRCStarted)
            {
                _processTimer = new Timer(state =>
                {
                    if (ProcessLookup("VRChat"))
                    {
                        VRCStarted = true;
                        if (InvokeRequired)
                        {
                            this.Invoke(new Action(VRCStartedActions));
                        }
                    }
                    else
                    {
                        _processTimer.Change(_interval, Timeout.Infinite);
                    }
                }, null, _interval, Timeout.Infinite);
            }
            else
            {
                VRCStartedActions();
            }
            //TODO Test for bluetooth adapter and enable local button if found
        }

        private void connectLocal_Click(object sender, EventArgs e)
        {
            _plugClient = new ButtplugClient("VRCButtUdon", new ButtplugEmbeddedConnector("PlugServer"));
            _plugClient.ConnectAsync();
            _plugClient.DeviceAdded += HandleDeviceConnect;
            discover.Enabled = true;
        }

        private void serverConnect_Click(object sender, EventArgs e)
        {
            _plugClient = new ButtplugClient("VRCButtUdon", new ButtplugWebsocketConnector(new Uri(serverAddress.Text)));
            _plugClient.ConnectAsync();
            _plugClient.DeviceAdded += HandleDeviceConnect;
            discover.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _plugClient.StartScanningAsync();
        }

        void HandleDeviceConnect(object aObj, DeviceAddedEventArgs args)
        {
            Console.WriteLine("Device connected: "+args.Device.Name);
            
        }

        private Task ProcessLookupTask()
        {
            Task task = new Task(() =>
            {
                VRCStarted = ProcessLookup("VRChat");
                Console.WriteLine("VRCStatus:"+VRCStarted);
                if (VRCStarted)
                {
                    if (InvokeRequired)
                    {
                        this.Invoke(new Action(VRCStartedActions));
                    }
                }
            });
            return task;
        }

        private bool ProcessLookup(String processname)
        {
            foreach (var process in Process.GetProcesses())
            {
                if (process.ProcessName.Equals(processname))
                {
                    return true;
                }
            }

            return false;
        }

        private void VRCStartedActions()
        {
            VRCStatus.ForeColor = Color.Aqua;
            VRCStatus.Text = "Started. Looking for log file";
            StartLogReader();
        }

        private void StartLogReader()
        {
            String filez = Directory.GetFiles(FinalFolder, "*.txt").OrderByDescending(s => new FileInfo(s).LastWriteTime).First();
            Console.WriteLine("Log file: "+filez);
            FileStream fs = new FileStream(filez, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            reader = new StreamReader(fs);
            reader.ReadToEnd();
            VRCStatus.ForeColor = Color.GreenYellow;
            VRCStatus.Text = "Started. Log loaded";
            _logTimer = new Timer(ReadLogLine, null, 0, 10);
        }

        private void ReadLogLine(object obj)
        {
            string line = reader.ReadLine();
            if (line!=null && !line.Equals(""))
            {
                if (line.Contains("BUTT-"))
                {
                    string[] splitted = line.Split('-');
                    foreach (var command in splitted)
                    {
                        switch (command[0])
                        {
                            case 'I':
                                int intensity = Int32.Parse(command.Substring(1));
                                Console.WriteLine("Setting intensity to "+intensity);
                                if (_plugClient.Connected && _plugClient.Devices.Length>0)
                                {
                                    foreach (var buttplugClientDevice in _plugClient.Devices)
                                    {
                                        buttplugClientDevice.SendVibrateCmd(intensity).Start();
                                    }
                                }
                                break;
                            default: 
                                Console.WriteLine("Not yet implemented");
                                break;
                        }
                    }
                }
            }
        }

    }
}
