using Api.App.Infrastructure.Api.Dependency;
using Castle.MicroKernel.Lifestyle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Api.App
{
    public class WindsorScopeMiddleware
    {
        private readonly Func<IDictionary<string, object>, Task> _next;

        public WindsorScopeMiddleware(Func<IDictionary<string, object>, Task> next)
        {
            _next = next;
        }

        public async Task Invoke(IDictionary<string, object> environment)
        {
            using (IoC.Container.BeginScope())
            {
                await _next(environment);
            }
        }
    }
}