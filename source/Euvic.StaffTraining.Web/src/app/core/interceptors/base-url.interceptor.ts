import {
  HttpEvent,
  HttpHandler,
  HttpInterceptor,
  HttpRequest,
} from '@angular/common/http';
import { Inject, Injectable, Injector } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { AttendeeProfileService } from 'src/app/features/shared/services/profile.service';

@Injectable()
export class BaseUrlInterceptor implements HttpInterceptor {
  constructor(
    @Inject('BASE_API_URL') private baseUrl: string,
    private injector: Injector
  ) {}

  intercept(
    request: HttpRequest<any>,
    next: HttpHandler
  ): Observable<HttpEvent<any>> {
    const profileService = this.injector.get(AttendeeProfileService);
    let apiRequest = request.clone({
      url: `${this.baseUrl}/${request.url}`,
      setHeaders: {
        'X-Attendee-Id': profileService.selectedAttendeeId.value.toString(),
      },
    });

    return next.handle(apiRequest);
  }
}
