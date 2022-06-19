using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace disease_tracker_api.Dtos.Response
{
    public class OrganizationDTO
    {
        public string Name { get; set; }

        public string Region { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }
    }

    public class OrganizationArchivedDTO : OrganizationDTO 
    {

        public string ArchiveReason { get; set; }

        public bool IsArchived { get; set; } = false;
    }
}