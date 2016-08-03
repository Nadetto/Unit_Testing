using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.Logics
{
    public class FileLogger : ILogger
    {
        public void Log(string message)
        {
            File.AppendAllText("log.txt", string.Format( "[{0}] {1}. {2}",
                DateTime.Now, message, Environment.NewLine));
        }
    }
}
