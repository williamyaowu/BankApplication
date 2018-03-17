using System;

namespace Api.App.Infrastructure.Persistance.Interface
{
    //represent session to persistance media
    public interface IPersistancSession
        :IDisposable
    {

        void Write(object obj);
    }
}
