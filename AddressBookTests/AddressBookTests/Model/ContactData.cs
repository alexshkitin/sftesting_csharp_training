using System;

namespace AddressBookTests
{
    public class ContactData  : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string firstName;
        private string lastName;

        public ContactData(string firstName)
        {
            this.firstName = firstName;
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

        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }

            return (FirstName + LastName).CompareTo(other.FirstName + other.LastName);
        }

        public string FirstName
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
