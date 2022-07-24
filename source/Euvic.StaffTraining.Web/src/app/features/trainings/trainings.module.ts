import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TrainingsListComponent } from './components/trainings-list/trainings-list.component';
import { HttpClientModule } from '@angular/common/http';
import { TrainingService } from './services/training.service';
import { TableModule } from 'primeng/table';
import { ButtonModule } from 'primeng/button';
import { SharedModule } from '../shared/shared.module';
import { TrainingDetailsComponent } from './components/training-details/training-details.component';
import { InputTextModule } from 'primeng/inputtext';

@NgModule({
  imports: [
    CommonModule,
    SharedModule,
    HttpClientModule,
    TableModule,
    ButtonModule,
    InputTextModule,
  ],
  declarations: [TrainingsListComponent, TrainingDetailsComponent],
  providers: [TrainingService],
})
export class TrainingsModule {}
