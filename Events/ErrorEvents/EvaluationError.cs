using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientLib.Events.ErrorEvents
{
    public class EvaluationError
    {
        public static event EventHandler.ErrorEventHandler EvaluationErrorEvent;
        public static void OnAppear(Args.EventArgs.ErrorEventArgs args)
        {
            if(EvaluationErrorEvent != null)
            {
                EvaluationErrorEvent(args);
            }
        }
    }
}
