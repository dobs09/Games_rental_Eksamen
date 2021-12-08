using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Games_rental_API.Classes
{
    public class QueryParameters
    {
        public string MemberName { get; set; }
        public int MemberID { get; set; }
        public string GameName { get; set; }
        public string SortBy { get; set; }

        public string _sortOrder { get; set; } = "asc";

        public string SortOrder
        {
            get
            {
                return _sortOrder;
            }

            set
            {
                if (value == "asc" || value == "desc")
                    _sortOrder = value;
            }
        }
    }
}
