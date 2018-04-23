using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using DevExpress.Xpo.DB;


namespace E5137 {
    public class EndPointHelper {
        public static IDataStore GetDataStore(string connectionString) {
            EndpointAddress address = new EndpointAddress(connectionString);
            BasicHttpBinding binding = new BasicHttpBinding();
            binding.MaxReceivedMessageSize = Int32.MaxValue;
            binding.ReaderQuotas.MaxArrayLength = Int32.MaxValue;
            binding.ReaderQuotas.MaxDepth = Int32.MaxValue;
            binding.ReaderQuotas.MaxBytesPerRead = Int32.MaxValue;
            binding.ReaderQuotas.MaxStringContentLength = Int32.MaxValue;
            try {
                IDataStore store = new DataStoreClient(binding, address);
                store.AutoCreateOption.ToString();
                return store;
            }
            catch(Exception e) {
                throw new DevExpress.Xpo.DB.Exceptions.UnableToOpenDatabaseException(connectionString, e);
            }
        }
    }
}
