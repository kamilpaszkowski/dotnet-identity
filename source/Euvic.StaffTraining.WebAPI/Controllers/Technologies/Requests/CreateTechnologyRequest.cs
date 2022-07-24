
using Euvic.StaffTraining.Contracts.Technologies.Shared;

namespace Euvic.StaffTraining.WebAPI.Controllers.Technologies.Requests
{
    public class CreateTechnologyRequest
    {
        public string Name { get; set; }
        public TechnologyScope Scope { get; set; }
    }
}
