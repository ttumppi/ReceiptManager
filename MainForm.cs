using System.ComponentModel.DataAnnotations;
using System;
using System.Xml.Serialization;
using System.Diagnostics;
using System.Xml;
using System.Reflection;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using TestConsole;
using System.Net.NetworkInformation;



namespace Kuittisovellus
{
    public partial class MainForm : Form
    {

        private MainListView _mainView;

        private AddReceiptView _addReceiptsView;

        private LogView _logView;

        private ServerSocket _serverSocket;


        private ClientSocket _clientSocket;







        public MainForm()
        {
            InitializeComponent();

            Settings.Instance.UCSize = new Size(ClientSize.Width, ClientSize.Height - ReceiptsTabButton.Size.Height);


        }

        private void CreateViews()
        {
            _mainView = new MainListView(Settings.Instance.TabHeight);
            _addReceiptsView = new AddReceiptView(Settings.Instance.TabHeight, this);
            _logView = new LogView(Settings.Instance.TabHeight);
            
        }

        private void SetAddReceiptsView()
        {
            _addReceiptsView.RegisterOnConnectionRequestedListener(CreateClientAndStartIPBroadcast);
        }

        private void SetSettings()
        {
            Settings.Instance.TabHeight = ReceiptsTabButton.Size.Height;
        }

        private void TabInitialization()
        {
            CreateTab(_mainView);
            CreateTab(_addReceiptsView);
            CreateTab(_logView);

            
        }

        private void CreateTab(TabUC tab)
        {
            this.Controls.Add(tab);

        }

        private void LinkSaveFunctions()
        {

            _addReceiptsView.RegisterForSave(OnSave);
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            SetSettings();
            CreateViews();
            SetAddReceiptsView();
            TabInitialization();
            Read();
            LinkSaveFunctions();
            CreateAndRunServer();
            IPLabel.Text = GetLocalIP();
        }



        private void Read()
        {
            _mainView.Read();
            _mainView.UpdateListView();

        }



        private void Write()
        {
            _mainView.Write();
            _addReceiptsView.Write();
        }



        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Write();
            _serverSocket.ShutDown();
            if (_clientSocket != null)
            {
                _clientSocket.ShutDown();
            }
            
        }

        private void ReceiptsTabButton_Click(object sender, EventArgs e)
        {
            _mainView.BringToFront();
        }

        private void AddReceiptTabButton_Click(object sender, EventArgs e)
        {
            _addReceiptsView.BringToFront();
        }



        private void OnSave(object sender, Info info)
        {

            _mainView.UpdateListView(info);
            _mainView.BringToFront();
        }

        private void ViewLogTabButton_Click(object sender, EventArgs e)
        {
            _logView.BringToFront();
        }

        private void CreateAndRunServer()
        {
            _serverSocket = new ServerSocket(
                23399, SocketType.Stream, ProtocolType.Tcp, ServerSocket.ServerNotificationMode.OnCompleteMessage, ";;;");

   
            _serverSocket.RegisterImageListener(_addReceiptsView.GetImageViewerOnImage());
            _serverSocket.RegisterOnConnectionFoundListener(OnConnectionFound);
            _serverSocket.RegisterOnConnectionFoundListener(_addReceiptsView.OnAppConnectionChange);

            _serverSocket.StartListening();
        }

        private void CreateClientAndStartIPBroadcast()
        {

            _clientSocket = new ClientSocket(IPAddress.Parse("192.168.1.255"), 23499, SocketType.Dgram, ProtocolType.Udp, ";;;");
            _clientSocket.StartPollingMessage("_IP");
        }


        public void AddMessageToLog(byte[] array)
        {
            _logView.AddMessage(Encoding.UTF8.GetString(array));
        }

        

        private void OnConnectionFound(object? sender, ServerSocket.ConnectionChangedEventArgs args)
        {
            if (args.State == ServerSocket.ConnectionChangedEventArgs.ConnectionState.Connected)
            {
                _clientSocket.ShutDown();
                if (SearchForPhoneAppButton.InvokeRequired)
                {
                    SearchForPhoneAppButton.Invoke(DisableSearchForPhoneAppButton);
                }
                
            }
            else
            {
                if (SearchForPhoneAppButton.InvokeRequired)
                {
                    SearchForPhoneAppButton.Invoke(EnableSearchForPhoneAppButton);
                }
            }
            

        }

        private void EnableSearchForPhoneAppButton()
        {
            SearchForPhoneAppButton.Enabled = true;
        }

        private void DisableSearchForPhoneAppButton()
        {
            SearchForPhoneAppButton.Enabled = false;
        }

        private void SearchForPhoneAppButton_Click(object sender, EventArgs e)
        {
            CreateClientAndStartIPBroadcast();
            DisableSearchForPhoneAppButton();
        }

        private string GetLocalIP()
        {
            try
            {
                Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                socket.Connect("192.168.1.1", 80);
                IPEndPoint endpoint = socket.LocalEndPoint as IPEndPoint;
                return endpoint.Address.ToString();
            }
            catch(Exception e)
            {
                _logView.AddMessage(e.Message);
            }

            
            return "No network found";
            
        }
    }






}
