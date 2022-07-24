import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FooterComponent } from './components/footer/footer.component';
import { MegaMenuModule } from 'primeng/megamenu';
import { TopBarComponent } from './components/top-bar/top-bar.component';
import { ToastModule } from 'primeng/toast';
import { AttendeeProfileService } from './services/profile.service';
import { LookupsService } from './services/lookups.service';
import { DropdownModule } from 'primeng/dropdown';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { DialogModule } from 'primeng/dialog';
import { InputTextModule } from 'primeng/inputtext';
import { CalendarModule } from 'primeng/calendar';
import { InputNumberModule } from 'primeng/inputnumber';

@NgModule({
  imports: [
    CommonModule,
    MegaMenuModule,
    DropdownModule,
    FormsModule,
    DialogModule,
    InputTextModule,
    ReactiveFormsModule,
    CalendarModule,
    InputNumberModule,
  ],
  exports: [
    TopBarComponent,
    ToastModule,
    DropdownModule,
    FormsModule,
    DialogModule,
    ReactiveFormsModule,
    CalendarModule,
    InputNumberModule,
  ],
  declarations: [TopBarComponent, FooterComponent],
  providers: [AttendeeProfileService, LookupsService],
})
export class SharedModule {}
