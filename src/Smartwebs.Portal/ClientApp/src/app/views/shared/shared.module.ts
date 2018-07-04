import { NgModule } from '@angular/core';

import { ConfirmationDialogService } from './confirmation-dialog/confirmation-dialog.service';
import { ConfirmationDialogComponent } from './confirmation-dialog/confirmation-dialog.component';

@NgModule({
  imports: [

  ],
  providers: [
    ConfirmationDialogService,
  ],
  entryComponents: [
    ConfirmationDialogComponent
  ],
  declarations: [
    ConfirmationDialogComponent
  ]
})
export class SharedModule { }
