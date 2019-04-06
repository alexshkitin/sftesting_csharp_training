using System;
using System.Collections.Generic;
using System.Linq;
using LinqToDB.Mapping;

namespace AddressBookTests
{
    [Table(Name ="group_list")]
    public class GroupData : IEquatable<GroupData>, IComparable<GroupData>
    {
        [Column(Name="group_name")]
        public string Name { get; set; }
        [Column(Name = "group_header"), NotNull]
        public string Header { get; set; }
        [Column(Name = "group_footer"), NotNull]
        public string Footer { get; set; }
        [Column(Name = "group_id"), PrimaryKey, Identity]
        public string Id { get; set; }

        public GroupData()
        { }

        public GroupData(string name)
        {
            Name = name;
        }

        public bool Equals(GroupData other)
        {
            if(Object.ReferenceEquals(other, null))
            {
                return false;
            }

            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }

            return Name == other.Name;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        public override string ToString()
        {
            return "name = " + Name
                + "/nheader = " + Header
                + "/nfooter = " + Footer;
        }

        public int CompareTo(GroupData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }

            return Name.CompareTo(other.Name);
        }

        public static List<GroupData> GetAll()
        {
            using (AddressbookDB db = new AddressbookDB())
            {
                return (from g in db.Groups select g).ToList();
            }
        }

        public static List<GroupData> GetGroupsWithContacts()
        {
            using (AddressbookDB db = new AddressbookDB())
            {
                return (from gcr in db.GCR
                        join g in db.Groups on gcr.GroupId equals g.Id
                        join c in db.Contacts on gcr.ContactId equals c.Id
                        where (c.Deprecated == "0000 - 00 - 00 00:00:00")
                        select g
                    ).Distinct().ToList();
            }
        }


        public List<ContactData> GetContacts()
        {
            using (AddressbookDB db = new AddressbookDB())
            {
                return (from c in db.Contacts
                        from gcr in db.GCR.Where(p=>p.GroupId==Id && 
                                                p.ContactId == c.Id && 
                                                c.Deprecated == "0000 - 00 - 00 00:00:00") 
                                                select c).Distinct().ToList();
            }
        }
    }
}
