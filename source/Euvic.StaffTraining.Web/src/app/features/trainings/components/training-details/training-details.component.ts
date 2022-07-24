import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { TrainingService } from '../../services/training.service';

@Component({
  selector: 'app-training-details',
  templateUrl: './training-details.component.html',
  styleUrls: ['./training-details.component.scss'],
})
export class TrainingDetailsComponent implements OnInit {
  trainingDetailsForm: FormGroup;

  constructor(
    private formBuilder: FormBuilder,
    private trainingService: TrainingService
  ) {
    this.trainingDetailsForm = this.formBuilder.group({
      title: [''],
      description: [''],
      duration: [60],
      startDate: [new Date(Date.now())],
    });
  }

  ngOnInit(): void {}
}
