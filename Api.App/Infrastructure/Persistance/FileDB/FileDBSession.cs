using Api.App.Infrastructure.Log.Interface;
using Api.App.Infrastructure.Persistance.Interface;
using Newtonsoft.Json;
using System;
using System.IO;

namespace Api.App.Infrastructure.Persistance.FileDB
{
    public class FileDBSession
        : IPersistancSession
    {

        private ILog _log;


        public string FilePath;

        public FileDBSession(string filePath)
        {
            this.FilePath = filePath;

            if (!File.Exists(this.FilePath))
            {
                var connection= File.Create(this.FilePath);
                connection.Close();
            }
                
        }

        public void Dispose()
        {
           
        }

        public void Write(object obj)
        {
            try
            {
                var record = this.Serialize(obj);

                var writeStream = File.AppendText(this.FilePath);

                writeStream.WriteLine(record);

                writeStream.Flush();
                writeStream.Close();
            }
            catch (Exception ex)
            {
                _log.Error("Error when trying to write to target file", ex);
                throw;
            }
        }

        protected virtual string Serialize(object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
    }
}