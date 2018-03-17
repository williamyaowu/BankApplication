using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api.App.Common.Services.Interface
{
    public abstract class AbstractMapping<S, T> : IMapping
    {
        public string Key
        {
            get
            {
                return string.Format(@"{0}:{1}", typeof(S).FullName, typeof(T));
            }
        }

        public abstract object Convert(object obj);
    }
}