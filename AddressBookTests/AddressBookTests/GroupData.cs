using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookTests
{
    class GroupData
    {
        private string name;
        private string header;
        private string footer;

        public GroupData(string name)
        {
            this.name = name;
        }

         public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                name = value;
            }
        }

        public string Header
        {
            get
            {
                return this.header;
            }
            set
            {
                header = value;
            }
        }

        public string Footer
        {
            get
            {
                return this.footer;
            }
            set
            {
                footer = value;
            }
        }
    }
}
