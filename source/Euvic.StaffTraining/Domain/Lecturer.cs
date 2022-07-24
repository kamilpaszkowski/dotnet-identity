using Euvic.StaffTraining.Infrastructure.EntityFramework.Abstractions;

namespace Euvic.StaffTraining.Domain
{
    internal class Lecturer : IUpdateDate, ICreateDate
    {
        public long Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public bool IsDeleted { get; set; }

        public ICollection<Training> Trainings { get; set; }
        public int TrainingsCount => Trainings?.Count ?? 0;
    }
}
