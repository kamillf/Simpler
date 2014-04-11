using System;
using System.Collections.Generic;
using System.Data;
using Simpler.Data.Tasks;

namespace Simpler.Data
{
    public class Results : IDisposable
    {
        public Results(IDataReader reader)
        {
            Reader = reader;
        }

        public IDataReader Reader { get; set; }

        public T[] Read<T>()
        {
            Check.That(Reader != null, "There are no more results.");

            var buildObject = Task.New<BuildObject<T>>();
            var objectList = new List<T>();
            while (Reader.Read())
            {
                buildObject.In.DataRecord = Reader;
                buildObject.Execute();
                objectList.Add(buildObject.Out.Object);
            }

            if (!Reader.NextResult())
            {
                Reader.Dispose();
                Reader = null;
            }

            return objectList.ToArray();
        }

        public void Dispose()
        {
            if (Reader != null)
            {
                Reader.Dispose();
                Reader = null;
            }
        }
    }
}