using System;
using RCS.DTV.RZC.Models;

namespace RCS.DTV.RZC.Helpers
{
    public class FeedbackCoordinator
    {
        private TcpClients Client;
        private FeedbackHandler FeedbackHandler;

        public FeedbackCoordinator(Config theConfig)
        {
            Client = new TcpClients(theConfig.FeedbackPort);
            FeedbackHandler = new FeedbackHandler();
            Client.StartListening();
            Client.TcpMessageReceived += (o, a) => Console.WriteLine(@"\nTCP MESSAGE RECEIVED\n");
            Client.TcpMessageReceived += HandleFeedback;
        }

        private void CreateCommands()
        {
            //FeedbackHandler = new FeedbackHandler(Cs);
        }

        public void StopListening()
        {
            Client.Dispose();
        }

        private void HandleFeedback(object sender, TcpMessageReceivedEventArgs args)
        {
            FeedbackHandler.Execute(args);
        }
    }
}
