using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.App.Infrastructure.Log.Interface
{
    public interface ILog
    {
        void Log(string message);

        void Error(string message, Exception ex = null);
    }
}
