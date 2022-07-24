import { Component, OnInit } from '@angular/core';
import { LookupsService } from './features/shared/services/lookups.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent implements OnInit {
  title = 'staff-training';

  constructor(private lookupsService: LookupsService) {}
  ngOnInit(): void {
    this.lookupsService.getAttendees();
  }
}
