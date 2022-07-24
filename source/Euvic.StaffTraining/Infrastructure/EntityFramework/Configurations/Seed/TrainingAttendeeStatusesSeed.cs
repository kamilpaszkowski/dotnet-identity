using Euvic.StaffTraining.Domain;

namespace Euvic.StaffTraining.Infrastructure.EntityFramework.Configurations.Seed
{
    internal static class TrainingAttendeeStatusesSeed
    {
        public static IEnumerable<TrainingAttendeeStatus> GetSeed() =>
            new List<TrainingAttendeeStatus>()
            {
                new TrainingAttendeeStatus()
                {
                    Id = (int)TrainingAttendeeStatuses.Interested,
                    Name = TrainingAttendeeStatuses.Interested.ToString()
                },
                new TrainingAttendeeStatus()
                {
                    Id = (int)TrainingAttendeeStatuses.Confirmed,
                    Name = TrainingAttendeeStatuses.Confirmed.ToString()
                },
            };
    }
}
