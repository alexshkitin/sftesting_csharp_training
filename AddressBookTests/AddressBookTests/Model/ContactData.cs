using System;

namespace AddressBookTests
{
    public class ContactData  : IEquatable<ContactData>, IComparable<ContactData>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }


        public ContactData(string firstName)
        {
            FirstName = firstName;
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
    }
}
