import { Component, ViewChild, Output, OnInit, ElementRef, Input } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { Subject } from 'rxjs/Subject';

import * as _ from 'lodash';
import { Recipe, SaveRecipeRequest, RecipeService} from './recipe.service';

@Component({
  selector: 'recipe-modal',
  templateUrl: 'recipe-modal.component.html'
})
export class RecipeModalComponent implements OnInit {
  saved$ = new Subject<Recipe>();
  isSaving = false;
  title = 'Add new recipe';
  form: FormGroup;

  existingRecipe: Recipe;

  constructor(
    public bsModalRef: BsModalRef,
    private recipeService: RecipeService,
    private fb: FormBuilder) {

  }

  ngOnInit() {
    let description = '';

    if (this.existingRecipe) {
      this.title = 'Edit recipe';
      description = this.existingRecipe.description;
    }

    this.form = this.fb.group({
      description: [description, [Validators.required, Validators.maxLength(250)]]
    });
  }

  save() {
    if (!this.form.valid) {
      return;
    }

    this.isSaving = true;

    const request: SaveRecipeRequest = {
      description: this.form.value.description
    };

    if (this.existingRecipe) {
      this.recipeService.updateRecipe(this.existingRecipe.id, request).subscribe(r => {
        this.saved$.next();
        this.isSaving = false;
        this.bsModalRef.hide();
      });
    } else {
      this.recipeService.createRecipe(request).subscribe(r => {
        this.saved$.next();
        this.isSaving = false;
        this.bsModalRef.hide();
      });
    }
  }
}
