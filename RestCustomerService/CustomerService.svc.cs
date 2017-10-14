using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.AccessControl;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web;

namespace RestCustomerService
{
    
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CustomerService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select CustomerService.svc or CustomerService.svc.cs at the Solution Explorer and start debugging.
    public class CustomerService : ICustomerService
    {

        
        private static List<Customer> customerListe = new List<Customer>()
        {
            new Customer(1,"Hans","Hansen",23),
            new Customer(2,"Peter","Jensen",45),
            new Customer(3,"Jeppe","Jørgensen",33),
            new Customer(4,"Niels","Nielsen",65)
        };

        private static int nextId = customerListe.Count;

        public IList<Customer> GetCustomers()
        {
            return customerListe;
        }
       
        public Customer GetCustomersFromId(string id)
        {
            try
            {
                int idet = int.Parse(id);
                return customerListe.FirstOrDefault(kunde => kunde.Id == idet);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                
            }
            System.Diagnostics.Debug.WriteLine("Ingen kunde fundet! "); 
            return null;

        }

        public Customer DeleteCustomer(string id)
        {
            Customer kunde = GetCustomersFromId(id);
            if (kunde == null) return null;
            bool removed = customerListe.Remove(kunde);
            if (removed) return kunde;
            return null;
        }

        public Customer PostCustomer(Customer c)
        {
            c.Id = nextId++;
            customerListe.Add(c);
            return c;

        }

        public Customer PutCustomer(string id, Customer c)
        {
            int idnummer = int.Parse(id);
            Customer findeskunde = customerListe.FirstOrDefault(cu => cu.Id == idnummer);
            if (findeskunde == null) return null;
            findeskunde.FirstName = c.FirstName;
            findeskunde.LastName = c.LastName;
            return findeskunde;
        }
    }
}
