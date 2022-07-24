using Euvic.StaffTraining.Contracts.Technologies.Shared;

namespace Euvic.StaffTraining.WebAPI.Controllers.Technologies.Requests
{
    public class UpdateTechnologyRequest
    {
        public string Name { get; set; }
        public TechnologyScope Scope { get; set; }
    }
}
