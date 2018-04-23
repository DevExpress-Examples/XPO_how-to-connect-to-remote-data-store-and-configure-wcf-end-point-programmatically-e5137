using System;
using System.Collections.Generic;
using System.Linq;
using DevExpress.Data.Filtering;
using DevExpress.Xpo;

namespace E5137 {
    class Program {
        static void Main() {
            XpoDefault.DataLayer = new SimpleDataLayer(EndPointHelper.GetDataStore("http://localhost:55777/Service1.svc"));
            XpoDefault.Session = null;
            using(UnitOfWork uow = new UnitOfWork()) {
                if(uow.FindObject(typeof(Customer), new BinaryOperator("ContactName", "Alex Smith", BinaryOperatorType.Equal)) == null) {
                    Customer custAlex = new Customer(uow) { ContactName = "Alex Smith", CompanyName = "DevExpress" };
                    custAlex.Save();
                    Customer Tom = new Customer(uow) { ContactName = "Tom Jensen", CompanyName = "ExpressIT" };
                    Tom.Save();
                    uow.CommitChanges();
                }
                using(XPCollection<Customer> customers = new XPCollection<Customer>(uow)) {
                    foreach(Customer customer in customers) {

                        Console.WriteLine("Company Name = {0}; ContactName = {1}", customer.CompanyName, customer.ContactName);
                    }
                }
            }
            Console.WriteLine("Press any key...");
            Console.ReadKey();
        }
    }
}
