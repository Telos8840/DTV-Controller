using System;
using System.IO;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using Elysium.Notifications;
using RCS.DTV.RZC.Models;
using RCS.DTV.RZC.Properties;
using SimpleMvvmToolkit;

namespace RCS.DTV.RZC.Helpers
{
    public class iPad : ModelBase<iPad>
    {
        private TcpClient tcp = new TcpClient();
        private NetworkStream stream;
        private StreamWriter sw;

        public iPad(string ip, string port)
        {
            IP = ip;
            Port = port;
        }

        private string _iP;

        public string IP
        {
            get { return _iP; }
            set
            {
                if (_iP == value)
                    return;
                _iP = value;
                NotifyPropertyChanged(m => m.IP);
            }
        }

        private string _port;

        public string Port
        {
            get { return _port; }
            set
            {
                if (_port == value)
                    return;
                _port = value;
                NotifyPropertyChanged(m => m.Port);
            }
        }

        private Boolean _isConnected;

        public Boolean IsConnected
        {
            get { return _isConnected; }
            set
            {
                if (_isConnected == value)
                    return;
                _isConnected = value;
                NotifyPropertyChanged(m => m.IsConnected);
            }
        }

        public void ConnectToiPad()
        {
            var task = new Thread(Connecting);
            task.Start();
        }

        private void Connecting()
        {
            Boolean done = false;
            try
            {
                while (!done)
                {
                    tcp.Connect(IP, Convert.ToInt16(Port));
                    stream = tcp.GetStream();
                    Console.WriteLine("Trying to connect to iPad...");
                    if (tcp.Connected)
                    {
                        done = true;
                        IsConnected = tcp.Connected;
                        Console.WriteLine("\n*** iPad Connected ***\n");
                        //PassIpAndPort();
                    }
                }
            }
            catch (Exception e)
            {
                //NotificationManager.Push("iPad Connection", "Unable to establish a connection to the iPad");
                Console.WriteLine(e);
            }
        }

        private void PassIpAndPort()
        {
            //string vizIP = String.Format("0 {0}:{1}{2}", CurrentSession.Config.EngineIp, CurrentSession.Config.EnginePort, "\r\n");
            //string backendIP = String.Format("1 {0}:{1}{2}", NetHelper.GetLocalIP(), "8787", "\r\n");

            //Invoke(vizIP);
            //Invoke(backendIP);
        }

        public void DisconnectFromiPad()
        {
            try
            {
                tcp.Close();
                stream.Close();
                IsConnected = false;
                Console.WriteLine("\n*** iPad Disconnected ***\n");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public void Invoke(string command)
        {
            if (IsConnected)
            {
                
                sw = new StreamWriter(stream);
                sw.Write(command);
                sw.Flush();
                Console.WriteLine("COMMAND SENT TO iPad {0}", command);
            }
            //else
                //NotificationManager.Push("iPad Connection", "iPad is currently not connected");
        }
    }
}
