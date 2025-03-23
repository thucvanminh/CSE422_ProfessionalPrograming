using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Common.Utilities
{
    public class ErrorHandler
    {
        public string FormatError(Exception ex)
        {
            return $"Error: {ex.Message} | StackTrace: {ex.StackTrace}";
        }
    }
}