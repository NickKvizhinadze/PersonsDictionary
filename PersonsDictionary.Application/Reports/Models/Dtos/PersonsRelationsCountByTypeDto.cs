using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonsDictionary.Application.Reports.Models.Dtos
{
    public class PersonsRelationsCountByTypeDto
    {
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PersonalId { get; set; }
        public string Type { get; set; }
        public int Count { get; set; }
    }
}
