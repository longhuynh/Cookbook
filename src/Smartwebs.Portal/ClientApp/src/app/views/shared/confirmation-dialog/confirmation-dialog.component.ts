import { Component, Input, OnInit } from '@angular/core';
import { BsModalRef } from 'ngx-bootstrap';

@Component({
  templateUrl: './confirmation-dialog.component.html'
})
export class ConfirmationDialogComponent implements OnInit {

  @Input() title: string;
  @Input() message: string;
  @Input() btnOkText: string;
  @Input() btnCancelText: string;

  confirmed = false;

  constructor(public bsModalRef: BsModalRef) { }

  ngOnInit() {
  }

  cancel() {
    this.confirmed = false;
    this.close();
  }

  ok() {
    this.confirmed = true;
    this.close();
  }

  close() {
    this.bsModalRef.hide();
  }
}
