import { HttpErrorResponse } from '@angular/common/http';
import { Message } from '@angular/compiler/src/i18n/i18n_ast';
import { ErrorHandler, Injectable, NgZone } from '@angular/core';
import { MessageService } from 'primeng/api';

@Injectable()
export class GlobalErrorHandler implements ErrorHandler {
  constructor(private messageService: MessageService, private zone: NgZone) {}

  handleError(error: any) {
    if (!(error instanceof HttpErrorResponse)) {
      error = error.rejection;
    }
    if (error?.status === 400 && error?.error) {
      this.zone.run(() =>
        this.messageService.add({
          severity: 'warn',
          summary: 'Validation error',
          detail: error?.error.message,
        })
      );
    } else if (error?.status === 500) {
      this.zone.run(() =>
        this.messageService.add({
          severity: 'error',
          summary: 'Unexpected error',
          detail: 'Unexpected error occured',
        })
      );
    }
  }
}
