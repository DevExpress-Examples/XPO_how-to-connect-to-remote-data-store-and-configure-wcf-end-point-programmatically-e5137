Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.ServiceModel
Imports DevExpress.Xpo.DB


Namespace E5137
    Public Class EndPointHelper
        Public Shared Function GetDataStore(ByVal connectionString As String) As IDataStore
            Dim address As New EndpointAddress(connectionString)
            Dim binding As New BasicHttpBinding()
            binding.MaxReceivedMessageSize = Int32.MaxValue
            binding.ReaderQuotas.MaxArrayLength = Int32.MaxValue
            binding.ReaderQuotas.MaxDepth = Int32.MaxValue
            binding.ReaderQuotas.MaxBytesPerRead = Int32.MaxValue
            binding.ReaderQuotas.MaxStringContentLength = Int32.MaxValue
            Try
                Dim store As IDataStore = New DataStoreClient(binding, address)
                store.AutoCreateOption.ToString()
                Return store
            Catch e As Exception
                Throw New DevExpress.Xpo.DB.Exceptions.UnableToOpenDatabaseException(connectionString, e)
            End Try
        End Function
    End Class
End Namespace
