using System;
using LinqToDB.Mapping;
using System.Collections.Generic;
using System.Linq;

namespace AddressBookTests
{
    [Table(Name = "addressbook")]
    public class ContactData  : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string allPhones;
        private string allEmails;

        [Column(Name = "Id"), PrimaryKey, Identity]
        public string Id { get; set; }

        [Column(Name = "firstname")]
        public string FirstName { get; set; }

        [Column(Name = "lastname")]
        public string LastName { get; set; }

        [Column(Name = "address")]
        public string Address { get; set; }

        [Column(Name = "home")]
        public string HomePhone { get; set; }

        [Column(Name = "work")]
        public string MobilePhone { get; set; }

        [Column(Name = "mobile")]
        public string WorkPhone { get; set; }

        [Column(Name = "email")]
        public string Email { get; set; }

        [Column(Name = "email2")]
        public string Email2 { get; set; }

        [Column(Name = "email3")]
        public string Email3 { get; set; }

        [Column(Name = "deprecated")]
        public string Deprecated { get; set; }

        public ContactData()
        { }

        public ContactData(string firstName)
        {
            FirstName = firstName;
        }

        public ContactData(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public ContactData(string firstName, string lastName, string id)
        {
            FirstName = firstName;
            LastName = lastName;
            Id = id;
        }

        public string AllEmails
        {
            get
            {
                if (allEmails != null)
                {
                    return allEmails;
                }
                else
                {
                    return (Cleanup(Email) + Cleanup(Email2) + Cleanup(Email3)).Trim();
                }
            }

            set
            {
                allEmails = value;
            }
        }

        public string AllPhones
        {
            get
            {
                if (allPhones!=null)
                {
                    return allPhones;
                }
                else
                {
                    return (Cleanup(HomePhone) + Cleanup(MobilePhone) + Cleanup(WorkPhone)).Trim();
                }
            }
            set
            {
                allPhones = value;
            }
        }

        public string Cleanup(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }
            else
            {
                return phone.Replace(" ", "").Replace("-", "").Replace("(", "").Replace(")", "")+"\r\n";
            }
        }


        public bool Equals(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }

            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return (FirstName.CompareTo(other.FirstName) == 0 && LastName.CompareTo(other.LastName)==0);
        }

        public override int GetHashCode()
        {
            return FirstName.GetHashCode()+LastName.GetHashCode();
        }

        public override string ToString()
        {
            return "First name = " + FirstName + "" +
                ", last name = " + LastName;
        }

        public string AsSingleString()
        {
            string lastName = Wrap(LastName, " ", "");

            string workPhone = Wrap(WorkPhone, "W: ", "\r\n");
            string homePhone = Wrap(HomePhone, "H: ", "\r\n");
            string mobilePhone = Wrap(MobilePhone, "M: ", "\r\n");
            string allPhones = Wrap((homePhone + mobilePhone + workPhone).Trim(), "\r\n", "\r\n");
            
            string allEmails =  Wrap(AllEmails, "\r\n", "");

            string contactDataAsString = (FirstName +
                LastName +"\r\n" + allPhones + allEmails).Trim();
            return contactDataAsString;
        }

        public string Wrap(string phone, string prefix, string postfix)
        {
            if (phone == null || phone == "")
            {
                return "";
            }
            else
            {
                return prefix+phone+postfix;
            }
        }

        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }

            return (FirstName + LastName).CompareTo(other.FirstName + other.LastName);
        }

        public static List<ContactData> GetAll()
        {
            using (AddressbookDB db = new AddressbookDB())
            {
                return (from g in 
                            db.Contacts.Where(x=>x.Deprecated=="0000-00-00 00:00:00")
                        select g).ToList();

            }           
        }
    }
}
