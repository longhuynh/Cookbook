import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { ButtonsModule } from 'ngx-bootstrap/buttons';
import { NgxDatatableModule } from '@swimlane/ngx-datatable';
import { ModalModule } from 'ngx-bootstrap/modal';
import { LaddaModule } from 'angular2-ladda';

import { SharedModule } from '../shared/shared.module';
import { CookbookRoutingModule } from './cookbook-routing.module';
import { RecipeService } from './recipe/recipe.service';

import { RecipeComponent } from './recipe/recipe.component';
import { RecipeModalComponent } from './recipe/recipe-modal.component';
import { RecipeVersionsComponent } from './recipe/recipe-version.component';


@NgModule({
  imports: [
    FormsModule,
    ReactiveFormsModule,
    CommonModule,
    SharedModule,
    CookbookRoutingModule,
    BsDropdownModule,
    NgxDatatableModule,
    ButtonsModule.forRoot(),
    ModalModule.forRoot(),
    LaddaModule
  ],
  providers: [
    RecipeService
  ],
  entryComponents: [
    RecipeModalComponent,
    RecipeVersionsComponent
  ],
  declarations: [
    RecipeComponent,
    RecipeModalComponent,
    RecipeVersionsComponent
  ]
})
export class CookbookModule { }
