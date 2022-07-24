import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TrainingsListComponent } from './features/trainings/components/trainings-list/trainings-list.component';

const routes: Routes = [{ path: '', component: TrainingsListComponent }];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
