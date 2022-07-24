import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {
  CreateTrainingRequest,
  TrainingListItem,
} from 'src/app/models/api/models';

@Injectable()
export class TrainingService {
  url: string = 'trainings';

  constructor(private http: HttpClient) {}

  getTrainingsList() {
    return this.http.get<TrainingListItem[]>(this.url);
  }

  joinToTraining(trainingId: string) {
    return this.http.put<TrainingListItem[]>(
      `${this.url}/${trainingId}/attendees/me`,
      null
    );
  }

  confirmTraining(trainingId: string) {
    return this.http.put(
      `${this.url}/${trainingId}/attendees/me/confirm`,
      null
    );
  }

  unconfirmTraining(trainingId: string) {
    return this.http.put(
      `${this.url}/${trainingId}/attendees/me/unconfirm`,
      null
    );
  }

  decline(trainingId: string) {
    return this.http.put(
      `${this.url}/${trainingId}/attendees/me/decline`,
      null
    );
  }

  create(data: CreateTrainingRequest) {
    return this.http.post(`${this.url}`, data);
  }
}
