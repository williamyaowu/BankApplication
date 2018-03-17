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

        private string _fileLocation = @".\";
        private string _fileName;

        public string FilePath
        {
            get
            {
                return Path.Combine(this._fileLocation, this._fileName);
            }
        }

        public FileDBSession(string fileName)
        {
            this._fileName = fileName;

            if (!File.Exists(this.FilePath))
            {
                var connection= File.Create(this.FilePath);
                connection.Close();
            }
                
        }

        public FileDBSession(string location, string fileName)
            : this(fileName)
        {
            this._fileLocation = location;
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