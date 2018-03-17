using Api.App.Common.Services.Interface;
using System.Collections.Generic;

namespace Api.App.Common.Services.Impl
{
    public class ConverterManger : IConverterManager
    {
        IDictionary<string, IMapping> _mappings;

        public ConverterManger(IMapping[] mappings)
        {
            _mappings = new Dictionary<string, IMapping>();
            if (mappings != null)
            {
                foreach (var ma in mappings)
                {
                    _mappings.Add(new KeyValuePair<string, IMapping>(ma.Key, ma));
                }
            }
        }

        private IMapping GetMapping<S, T>()
        {
            var key = string.Format(@"{0}:{1}", typeof(S).FullName, typeof(T));

            return _mappings[key];
        }

        public T Convert<S, T>(S source)
        {
            var mapping = this.GetMapping<S, T>();

            return (T)mapping.Convert(source);
        }


    }
}