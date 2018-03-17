namespace Api.App.Common.Services.Interface
{
    public interface IConverterManager
    {
       T Convert<S, T>(S source);
    }
}
