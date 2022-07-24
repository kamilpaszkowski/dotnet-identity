using System.Collections.Generic;

namespace Euvic.StaffTraining.Common
{
    public class ValidationErrorResponse
    {
        public IEnumerable<PropertyValidationResult> ValidationResults { get; set; }
        public string Message { get; set; }
    }
}
