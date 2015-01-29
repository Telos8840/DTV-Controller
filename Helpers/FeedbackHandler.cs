using System;
using NLog;
using RCS.DTV.RZC.Models;
using RCS.DTV.RZC.Properties;
using RCS.DTV.RZC.Services;
using RCS.DTV.RZC.ViewModels;

namespace RCS.DTV.RZC.Helpers
{
    class FeedbackHandler
    {
        private readonly Logger log = LogManager.GetLogger("FEEDBACK HANDLER");

        #region Private Fields
        RouterControl rc = new RouterControl(Settings.Default.BlackMagicIP);
        private FantasyServiceAgent fantasy;
        #endregion

        #region public Properties

        #endregion
        //public FeedbackHandler(FantasyServiceAgent fan)
        //{
        //    fantasy = fan;
        //}
        #region ICommands Members

        public void Execute(object param = null)
        {
            
            try
            {
                if (param != null && param is TcpMessageReceivedEventArgs)
                {
                    TcpMessageReceivedEventArgs arg = param as TcpMessageReceivedEventArgs;
                    log.Trace("\nHANDLING EVENT MESSAGE {0}", arg.Message);
                    Console.WriteLine("*** ROUTING TO {0}  ***", arg.Message);
                    int route;
                    if (arg.Message.Contains("game"))
                    {
                        route = int.Parse(arg.Message.Substring(4));
                        route--;
                        //rc.SetRoute("274", route.ToString());
                        rc.SetRoute("8", route.ToString());
                    }
                    else if (arg.Message.Contains("fantasy"))
                    {
                        //CurrentSession.Fantasy.ReloadTopPlayers();
                        //CurrentSession.Fantasy.SetTopPlayers();
                    }

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                log.Error("ERROR HANDING THE FEEDBACK");
            }
        }
        #endregion

    }
}
