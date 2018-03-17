namespace Api.App.Common.Services.Interface
{
    public interface IMapping
    {
        string Key { get; }

        object Convert(object obj);
    }
}