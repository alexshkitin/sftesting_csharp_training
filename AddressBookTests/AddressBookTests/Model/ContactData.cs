using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookTests
{
    public class ContactData 
    {
        private string firstName;
        private string lastName;

        public ContactData(string firstName)
        {
            this.firstName = firstName;
        }

        public string FistName
        {
            get
            {
                return this.firstName;
            }
            set
            {
                firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }
            set
            {
                lastName = value;
            }
        }
    }
}
