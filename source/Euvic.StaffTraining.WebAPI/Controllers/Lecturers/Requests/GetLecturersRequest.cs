using Euvic.StaffTraining.Contracts.Technologies.Shared;

namespace Euvic.StaffTraining.WebAPI.Controllers.Lecturers.Requests
{
    public class GetLecturersRequest
    {
        public string SearchPhase { get; set; }
        public TechnologyScope? Scope { get; set; }
    }
}
