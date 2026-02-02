Imports System
Imports System.ServiceModel
Imports DevExpress.Xpo.DB

Namespace E5137

    Public Class EndPointHelper

        Public Shared Function GetDataStore(ByVal connectionString As String) As IDataStore
            Dim address As EndpointAddress = New EndpointAddress(connectionString)
            Dim binding As BasicHttpBinding = New BasicHttpBinding()
            binding.MaxReceivedMessageSize = Integer.MaxValue
            binding.ReaderQuotas.MaxArrayLength = Integer.MaxValue
            binding.ReaderQuotas.MaxDepth = Integer.MaxValue
            binding.ReaderQuotas.MaxBytesPerRead = Integer.MaxValue
            binding.ReaderQuotas.MaxStringContentLength = Integer.MaxValue
            Try
                Dim store As IDataStore = New DataStoreClient(binding, address)
                store.AutoCreateOption.ToString()
                Return store
            Catch e As Exception
                Throw New Exceptions.UnableToOpenDatabaseException(connectionString, e)
            End Try
        End Function
    End Class
End Namespace
