using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace groupProject
{
    internal class Customer
    {
        
        private string customerId;
        private string customerFirstName;
        private string customerLastName;
        private string customerPhone;
        private int numberOfBookings;

        public Customer(string customerFirstName, string customerLastName, string customerPhone) 
        {
            //this.customerId = customerId;
            this.customerId = GenerateRandomId();
            this.customerFirstName = customerFirstName;
            this.customerLastName = customerLastName;
            this.customerPhone = customerPhone;
        }
        

        public string getCustomerFirstName()
        {
            return customerFirstName;
        }
        public string getCustomerLastName()
        {
            return customerLastName;
        }
        public string getCustomerId()
        {
            return this.customerId;
        }

        public string getCustomerPhone()
        {
            return this.customerPhone;
        }
        public override string ToString()
        {
            string cusInfo = "Number" + "\t\t" + "Name\t\t\t" + "Phone\n";
            string cusInfo2 = customerId + "\t\t" + customerFirstName + "\t" + customerLastName + "\t\t" + customerPhone;
            return cusInfo + cusInfo2;
        }
        private static string GenerateRandomId()
        {           
            const string characters = "QWERTYUOPASDFGHJKLZXCVBNM";
            Random random = new Random();
            char[] idChars = new char[3];
            for (int i = 0; i < idChars.Length; i++)
            {
                idChars[i] =  characters[random.Next(characters.Length)];
            }
            return new string(idChars);
        }
    }
}
    