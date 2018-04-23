Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports DevExpress.Data.Filtering
Imports DevExpress.Xpo

Namespace E5137
    Friend Class Program
        Shared Sub Main()
            XpoDefault.DataLayer = New SimpleDataLayer(EndPointHelper.GetDataStore("http://localhost:55777/Service1.svc"))
            XpoDefault.Session = Nothing
            Using uow As New UnitOfWork()
                If uow.FindObject(GetType(Customer), New BinaryOperator("ContactName", "Alex Smith", BinaryOperatorType.Equal)) Is Nothing Then
                    Dim custAlex As New Customer(uow) With {.ContactName = "Alex Smith", .CompanyName = "DevExpress"}
                    custAlex.Save()
                    Dim Tom As New Customer(uow) With {.ContactName = "Tom Jensen", .CompanyName = "ExpressIT"}
                    Tom.Save()
                    uow.CommitChanges()
                End If
                Using customers As New XPCollection(Of Customer)(uow)
                    For Each customer As Customer In customers

                        Console.WriteLine("Company Name = {0}; ContactName = {1}", customer.CompanyName, customer.ContactName)
                    Next customer
                End Using
            End Using
            Console.WriteLine("Press any key...")
            Console.ReadKey()
        End Sub
    End Class
End Namespace
