using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using RCS.DTV.RZC.Models;

namespace RCS.DTV.RZC.Helpers
{
    public class RouterControl
    {
        readonly TcpClient _client;
        string _buffer = String.Empty;

        public ObservableCollection<Route> Inputs { get; private set; }
        public ObservableCollection<Route> Outputs { get; private set; }

        public RouterControl(string ipString)
        {
            Inputs = new ObservableCollection<Route>();
            Outputs = new ObservableCollection<Route>();
            _client = new TcpClient();
            var ip = IPAddress.Parse(ipString);
            var ep = new IPEndPoint(ip, 9990);
            _client.Connect(ep);
            _client.ReceiveTimeout = 1000;

            ReadResponse();
        }

        private void ReadResponse()
        {
            var bytes = new byte[4096];
            _client.Client.BeginReceive(bytes, 0, 4096, SocketFlags.None, Callback, bytes);
        }

        private void Callback(IAsyncResult ar)
        {
            try
            {
                var bytes = (byte[])ar.AsyncState;
                _client.Client.EndReceive(ar);
                var resp = Encoding.ASCII.GetString(bytes).Replace("\0", "");

                _buffer += resp;
                if (resp.EndsWith("\n\n"))
                {
                    ProcessBlock(_buffer);
                    _buffer = String.Empty;
                }

                ReadResponse();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private void ProcessBlock(string buffer)
        {
            var list = buffer.Split(new[] { "\n" }, StringSplitOptions.None);

            var strList = list.ToList();
            var cmd = strList[0];
            strList.RemoveAt(0);
            if (cmd.Contains("INPUT LABELS:"))
            {
                InputLabels(strList);
            }
            if (cmd.Contains("OUTPUT LABELS:"))
            {
                OutputLabels(strList);
            }
        }

        private void InputLabels(IEnumerable<string> list)
        {
            Inputs.Clear();
            foreach (var input in list)
            {
                if (String.IsNullOrWhiteSpace(input)) continue;
                var split = input.Split(new[] { " " }, 2, StringSplitOptions.None);
                Inputs.Add(new Route
                {
                    Id = split[0],
                    Description = split[1]
                });
            }
        }

        private void OutputLabels(IEnumerable<string> list)
        {
            Outputs.Clear();
            foreach (var output in list)
            {
                if (String.IsNullOrWhiteSpace(output)) continue;
                var split = output.Split(new[] { " " }, 2, StringSplitOptions.None);
                Outputs.Add(new Route
                {
                    Id = split[0],
                    Description = split[1]
                });
            }
        }

        public void SetRoute(string dest, string src)
        {
            var cmd = "VIDEO OUTPUT ROUTING:\n" +
                         dest + " " + src + "\n" +
                         "\n";
            _client.Client.Send(Encoding.ASCII.GetBytes(cmd));
        }
    }
}
