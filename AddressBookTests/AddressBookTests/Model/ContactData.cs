using System;

namespace AddressBookTests
{
    public class ContactData  : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string allPhones;
        private string allEmails;

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string HomePhone { get; set; }
        public string MobilePhone { get; set; }
        public string WorkPhone { get; set; }
        public string Email { get; set; }
        public string Email2 { get; set; }
        public string Email3 { get; set; }

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


        public ContactData(string firstName)
        {
            FirstName = firstName;
        }

        public ContactData(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
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
            string contactDataAsString = (Cleanup(FirstName)+
                Cleanup(LastName) + allPhones + AllEmails)
                .Replace("\r","")
                .Replace("\n", "");
            return contactDataAsString;
        }

        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }

            return (FirstName + LastName).CompareTo(other.FirstName + other.LastName);
        }
    }
}
