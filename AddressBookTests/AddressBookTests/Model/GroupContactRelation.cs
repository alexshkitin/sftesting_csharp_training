using System;
using LinqToDB.Mapping;
using System.Collections.Generic;
using System.Linq;

namespace AddressBookTests
{
    [Table(Name ="address_in_groups")]
    public class GroupContactRelation
    {
        [Column(Name ="group_id")]
        public string GroupId { get; }
        [Column(Name ="id")]
        public string ContactId { get; }

    }
}
