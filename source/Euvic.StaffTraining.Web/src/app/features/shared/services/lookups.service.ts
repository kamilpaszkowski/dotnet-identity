import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { AttendeeSelectItem } from 'src/app/models/api/attendeeSelectItem';
import { BehaviorSubject, Subject } from 'rxjs';

@Injectable()
export class LookupsService {
  private url: string = 'lookups';
  attendees = new BehaviorSubject<AttendeeSelectItem[]>([]);

  constructor(private http: HttpClient) {}

  getAttendees() {
    this.http
      .get<AttendeeSelectItem[]>(`${this.url}/attendees`)
      .subscribe((a) => {
        this.attendees.next(a);
      });
  }
}
