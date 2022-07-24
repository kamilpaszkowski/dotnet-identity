export type TrainingAttendeeStatuses = 0 | 1 | 2 | 3;

export const TrainingAttendeeStatuses = {
  NotAttended: 0 as TrainingAttendeeStatuses,
  Interested: 1 as TrainingAttendeeStatuses,
  Confirmed: 2 as TrainingAttendeeStatuses,
  Declined: 3 as TrainingAttendeeStatuses,
};
