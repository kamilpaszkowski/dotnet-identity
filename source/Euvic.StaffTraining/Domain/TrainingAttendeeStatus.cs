namespace Euvic.StaffTraining.Domain
{
    internal class TrainingAttendeeStatus
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    internal enum TrainingAttendeeStatuses
    {
        NotAttended = 0,
        Interested = 1,
        Confirmed = 2,
    }
}
