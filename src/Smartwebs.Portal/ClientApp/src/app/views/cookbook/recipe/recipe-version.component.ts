import { Component, OnInit, ViewChild } from '@angular/core';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';

import { RecipeService } from './recipe.service';
import { ConfirmationDialogService } from '../../shared/confirmation-dialog/confirmation-dialog.service';
import { ToastrService } from 'ngx-toastr';
import { RecipeModalComponent } from './recipe-modal.component';

@Component({
  templateUrl: 'recipe-version.component.html'
})
export class RecipeVersionsComponent implements OnInit {

  reorderable = true;
  rows;

  constructor(public bsModalRef: BsModalRef) {
  }

  ngOnInit() {

  } 
}
