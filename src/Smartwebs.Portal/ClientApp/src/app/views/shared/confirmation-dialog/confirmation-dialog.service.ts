import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { Subscriber } from 'rxjs/Subscriber';
import { Subscription } from 'rxjs/Subscription';

import { BsModalService } from 'ngx-bootstrap/modal';
import { BsModalRef } from 'ngx-bootstrap/modal/bs-modal-ref.service';
import { ConfirmationDialogComponent } from './confirmation-dialog.component';


@Injectable()
export class ConfirmationDialogService {
  constructor(private modalService: BsModalService) { }

  confirm(
    title: string,
    message: string,
    btnOkText: string = 'OK',
    btnCancelText: string = 'Cancel'): Observable<boolean> {

    const config = {
      backdrop: false,
      ignoreBackdropClick: true
    };

    return new Observable<boolean>((subscriber: Subscriber<boolean>) => {
      const modalRef = this.modalService.show(ConfirmationDialogComponent, config);

      modalRef.content.title = title;
      modalRef.content.message = message;
      modalRef.content.btnOkText = btnOkText;
      modalRef.content.btnCancelText = btnCancelText;

      const subscription = this.modalService.onHide.subscribe(() => {
        return subscriber.next(modalRef.content.confirmed);
      });

      this.modalService.onHidden.subscribe(() => {
        subscription.unsubscribe();
      });
    });
  }
}
