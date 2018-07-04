import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { ButtonsModule } from 'ngx-bootstrap/buttons';
import { NgxDatatableModule } from '@swimlane/ngx-datatable';
import { ModalModule } from 'ngx-bootstrap/modal';
import { NgSelectModule } from '@ng-select/ng-select';
import { LaddaModule } from 'angular2-ladda';

import { SharedModule } from '../shared/shared.module';
import { CookbookRoutingModule } from './recipe-routing.module';


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
    NgSelectModule,
    LaddaModule
  ],
  providers: [
    
  ],
  entryComponents: [],
  declarations: [
   
  ]
})
export class CompanyModule { }
