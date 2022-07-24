﻿using Euvic.StaffTraining.Infrastructure.EntityFramework.Abstractions;

namespace Euvic.StaffTraining.Domain
{
    internal class Training : IUpdateDate, ICreateDate
    {
        internal Training()
        {
        }

        public Training(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public DateTime TrainingDate { get; set; }
        public long LecturerId { get; set; }
        public long TechnologyId { get; set; }

        public Lecturer Lecturer { get; set; }
        public Technology Technology { get; set; }
        public ICollection<TrainingAttendee> Attendees { get; set; }
    }
}
