using Euvic.StaffTraining.Infrastructure.EntityFramework.Abstractions;

namespace Euvic.StaffTraining.Domain
{
    internal class Technology : IUpdateDate, ICreateDate
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public TechnologyScope Scope { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
