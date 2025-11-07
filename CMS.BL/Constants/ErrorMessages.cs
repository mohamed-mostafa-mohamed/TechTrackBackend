using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.BL.Constants
{
    public static class ErrorMessages
    {
    

        public const string GetAllFailed = "Failed to retrieve {0}.";
        public const string GetByIdFailed = "Failed to retrieve {0} with ID {1}.";
        public const string NotFound = "{0} with ID {1} not found.";
        public const string CreateFailed = "Failed to create {0}.";
        public const string UpdateFailed = "Failed to update {0} with ID {1}.";
        public const string DeleteFailed = "Failed to delete {0} with ID {1}.";

    }
}

