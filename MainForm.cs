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



namespace ReceiptManager
{
    public partial class MainForm : Form
    {

        private MainListView _mainView;

        private AddReceiptView _addReceiptsView;

        private LogView _logView;

        private ServerSocket _serverSocket;


        private BroadCastClientSocket _broadCastClientSocket;

        private ClientSocket _commandImageSenderSocket;





        public MainForm()
        {
            InitializeComponent();

            Settings.Instance.UCSize = new Size(ClientSize.Width, ClientSize.Height - ReceiptsTabButton.Size.Height);

            SetFormText("Receipt Manager");

        }

        private void CreateViews()
        {
            _mainView = new MainListView(Settings.Instance.TabHeight, this);
            _addReceiptsView = new AddReceiptView(Settings.Instance.TabHeight, this, AddReceiptView.Mode.Add);
            _logView = new LogView(Settings.Instance.TabHeight);
            
        }

        private void SetAddReceiptsView()
        {
            _addReceiptsView.RegisterOnConnectionRequestedListener(CreateClientAndStartIPBroadcast);
            _addReceiptsView.RegisterOpenPhoneCameraViewListener(OpenCameraOnPhone);

            _mainView.LinkConnectionRequestedListenerToEditView(CreateClientAndStartIPBroadcast);
            _mainView.LinkOpenPhoneCameraEditViewEvent(OpenCameraOnPhone);
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

        private void CreateClient()
        {
            _broadCastClientSocket = new BroadCastClientSocket(23499, SocketType.Dgram, ProtocolType.Udp, ";;;");
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
            if (_broadCastClientSocket != null)
            {
                _broadCastClientSocket.ShutDown();
            }
            
        }

        private void ReceiptsTabButton_Click(object sender, EventArgs e)
        {
            _mainView.BringToFront();
            _addReceiptsView.Hide();
        }

        private void AddReceiptTabButton_Click(object sender, EventArgs e)
        {
            _addReceiptsView.BringToFront();
            _addReceiptsView.Show();
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

   
            _serverSocket.RegisterImageListener(_addReceiptsView.OnImageReceived);
            _mainView.LinkImageListener(_serverSocket.RegisterImageListener);
            _serverSocket.RegisterOnConnectionFoundListener(OnConnectionFound);
            _serverSocket.RegisterOnConnectionFoundListener(_addReceiptsView.OnAppConnectionChange);
            _mainView.LinkOnConnectionMadeToEditView(_serverSocket.RegisterOnConnectionFoundListener);
            _serverSocket.RegisterOnIPAddressReceivedListener(OnIPAddressReceived);

            _serverSocket.StartListening();
        }

        private void CreateClientAndStartIPBroadcast()
        {
            CreateClient();
            _broadCastClientSocket.StartPollingMessage("_IP");
        }


        public void AddMessageToLog(byte[] array)
        {
            _logView.AddMessage(Encoding.UTF8.GetString(array));
        }

        

        private void OnConnectionFound(object? sender, ServerSocket.ConnectionChangedEventArgs args)
        {
            if (args.State == ServerSocket.ConnectionChangedEventArgs.ConnectionState.Connected)
            {
                CloseClient();
                UpdateConnectionStateLabel("Connected");

                if (SearchForPhoneAppButton.InvokeRequired)
                {
                    SearchForPhoneAppButton.Invoke(DisableSearchForPhoneAppButton);
                    
                }
                else
                {
                    DisableSearchForPhoneAppButton();
                }
                
            }
            else
            {
                UpdateConnectionStateLabel("Disconnected");
                if (SearchForPhoneAppButton.InvokeRequired)
                {
                    SearchForPhoneAppButton.Invoke(EnableSearchForPhoneAppButton);
                }
                else
                {
                    EnableSearchForPhoneAppButton();
                }
            }
            

        }

        private void CloseClient()
        {
            _broadCastClientSocket.ShutDown();
            
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

        private void UpdateConnectionStateLabel(string text)
        {
            if (ConnectionStateLabel.InvokeRequired)
            {
                ConnectionStateLabel.Invoke(() => { UpdateConnectionStateLabel(text); });
                return;
            }
            else
            {
                ConnectionStateLabel.Text = text;
            }
        }

        private void SetFormText(string text)
        {
            this.Text = text;
        }

        public void OnIPAddressReceived(object? sender, ServerSocket.IPReceivedEventArgs e)
        {
            _commandImageSenderSocket = new ClientSocket(e.Address.Address, 33666, SocketType.Stream, ProtocolType.Tcp, "ACK");
            _commandImageSenderSocket.Start();
        }

        public void OpenCameraOnPhone()
        {
            _commandImageSenderSocket.AddMessage(new byte[1] {Convert.ToByte(true)});
        }
    }






}
