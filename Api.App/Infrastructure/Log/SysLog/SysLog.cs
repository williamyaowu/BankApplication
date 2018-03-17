using Api.App.Infrastructure.Log.Interface;
using System;

namespace Api.App.Infrastructure.Log.SysLog
{
    public class SysLog : ILog
    {
        public void Error(string message, Exception ex = null)
        {
            Console.WriteLine(message + ex.Message);
        }

        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}