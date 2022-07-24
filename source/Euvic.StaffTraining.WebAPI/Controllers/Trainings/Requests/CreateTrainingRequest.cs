using System;

namespace Euvic.StaffTraining.WebAPI.Controllers.Requests
{
    public class CreateTrainingRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public DateTime StartDate { get; set; }
        public long LecturerId { get; set; }
        public long TechnologyId { get; set; }
    }
}
