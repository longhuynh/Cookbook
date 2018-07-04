import { Component, OnInit, ViewChild } from '@angular/core';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';

import { RecipeService, Recipe } from './recipe.service';
import { ConfirmationDialogService } from '../../shared/confirmation-dialog/confirmation-dialog.service';
import { ToastrService } from 'ngx-toastr';
import { RecipeModalComponent } from './recipe-modal.component';
import { RecipeVersionsComponent } from './recipe-version.component';

@Component({
  templateUrl: 'recipe.component.html'
})
export class RecipeComponent implements OnInit {

  reorderable = true;
  rows = [];

  bsModalRef: BsModalRef;

  constructor(private modalService: BsModalService,
    private service: RecipeService,
    private confirmation: ConfirmationDialogService,
    private toastr: ToastrService) {
  }

  ngOnInit() {
    this.refresh();
  }

  add() {
    this.bsModalRef = this.modalService.show(RecipeModalComponent);

    this.bsModalRef.content.saved$.subscribe(d => {
      this.toastr.success('Add new success.');
      this.refresh();
    });
  }

  edit(recipe) {
    const initialState = { existingRecipe: recipe };

    this.bsModalRef = this.modalService.show(RecipeModalComponent, { initialState });

    this.bsModalRef.content.saved$.subscribe(d => {
      this.toastr.success('Update success.');
      this.refresh();
    });
  }

  viewVersion(recipe) {
    this.service.getRecipeVersions(recipe.id).subscribe(resp => {
      const initialState = { rows: resp.items };
      this.bsModalRef = this.modalService.show(RecipeVersionsComponent, { initialState });
    });  
  }

  delete(recipe: Recipe) {
    const message = `Do you want to delete recipe "${recipe.description}"?`;

    this.confirmation.confirm('Are you sure?', message).subscribe(confirmed => {
      if (confirmed) {
        this.toastr.error('Not implement ...');
      }
    });
  }

  refresh() {
    this.service.getRecipes().subscribe(resp => {
      this.rows = resp.items;
    });
  }
}
