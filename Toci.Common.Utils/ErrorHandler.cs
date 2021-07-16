using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toci.Common.Utils
{
    public class ErrorHandler
    {
        public static void ExceptionHandler(object source, UnhandledExceptionEventArgs ev)
        {
            ExceptionAnalyzer(((Exception)ev.ExceptionObject));
        }

        protected static void ExceptionAnalyzer(Exception exception)
        {
            if (exception.InnerException != null)
            {
                ExceptionAnalyzer(exception.InnerException);
            }

            // read message and log
        }
    }
}
