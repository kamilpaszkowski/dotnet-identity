import { Component, OnInit } from '@angular/core';
import { MessageService } from 'primeng/api';
import { AttendeeProfileService } from 'src/app/features/shared/services/profile.service';
import { TrainingAttendeeStatuses } from 'src/app/models/api/trainingAttendanceStatuses';
import { TrainingListItem } from 'src/app/models/api/trainingListItem';
import { TrainingService } from '../../services/training.service';

@Component({
  selector: 'app-trainings-list',
  templateUrl: './trainings-list.component.html',
  styleUrls: ['./trainings-list.component.scss'],
})
export class TrainingsListComponent implements OnInit {
  public isCreateTrainingDialogVisible = false;
  public trainings: TrainingListItem[] = [];
  public trainingAttendeeStatuses: typeof TrainingAttendeeStatuses =
    TrainingAttendeeStatuses;

  constructor(
    private trainingService: TrainingService,
    private messageService: MessageService,
    private attendeeProfileService: AttendeeProfileService
  ) {}

  ngOnInit(): void {
    this.attendeeProfileService.profile.subscribe(() => {
      this.refreshTrainingList();
    });
  }

  joinToTraining(trainingId: string) {
    this.trainingService
      .joinToTraining(trainingId)
      .subscribe(() => this.refreshTrainingList());
  }

  confirmTraining(trainingId: string) {
    this.trainingService.confirmTraining(trainingId).subscribe(() => {
      this.attendeeProfileService.getProfile();
    });
  }

  unconfirmTraining(trainingId: string) {
    this.trainingService.unconfirmTraining(trainingId).subscribe(() => {
      this.attendeeProfileService.getProfile();
    });
  }

  declineTraining(trainingId: string) {
    this.trainingService.decline(trainingId).subscribe(() => {
      this.attendeeProfileService.getProfile();
    });
  }

  refreshTrainingList() {
    this.trainingService.getTrainingsList().subscribe((trainings) => {
      this.trainings = trainings;
    });
  }

  showCreateTrainigDialog() {
    this.isCreateTrainingDialogVisible = true;
  }

  hideCreateTrainigDialog() {
    this.isCreateTrainingDialogVisible = false;
  }
}
