import { ErrorHandler, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { TechnologiesModule } from './features/technologies/technologies.module';
import { LecturersModule } from './features/lecturers/lectuers.module';
import { TrainingsModule } from './features/trainings/trainings.module';
import { AttendeesModule } from './features/attendees/attendees.module';
import { SharedModule } from './features/shared/shared.module';
import { TopBarComponent } from './features/shared/components/top-bar/top-bar.component';
import { environment } from 'src/environments/environment';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { BaseUrlInterceptor } from './core/interceptors/base-url.interceptor';
import { GlobalErrorHandler } from './core/interceptors/exception.interceptor';
import { ToastModule } from 'primeng/toast';
import { MessageService } from 'primeng/api';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AttendeeProfileService } from './features/shared/services/profile.service';

@NgModule({
  declarations: [AppComponent],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    AttendeesModule,
    TechnologiesModule,
    LecturersModule,
    TrainingsModule,
    SharedModule,
    ToastModule,
  ],
  providers: [
    { provide: 'BASE_API_URL', useValue: environment.apiUrl },
    {
      provide: HTTP_INTERCEPTORS,
      useClass: BaseUrlInterceptor,
      multi: true,
    },
    {
      provide: ErrorHandler,
      useClass: GlobalErrorHandler,
    },
    MessageService,
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
