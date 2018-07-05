import { async, ComponentFixture, TestBed, getTestBed } from '@angular/core/testing';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/observable/of';
import { RecipeComponent } from './recipe.component';
import { RecipeService, QueryResult, Recipe } from './recipe.service';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ButtonsModule } from 'ngx-bootstrap/buttons';
import { NgxDatatableModule } from '@swimlane/ngx-datatable';
import { ModalModule } from 'ngx-bootstrap/modal';
import { LaddaModule } from 'angular2-ladda';
import { SharedModule } from '../../shared/shared.module';

import { ToastrService } from 'ngx-toastr';

const dummyRecipes = [
  {
    items: [
      { id: 1, description: 'description 1' },
      { id: 2, description: 'description 2' }
    ]
  }
];

class FakeRecipeSerivce {
  getRecipes() {
    return Observable.of(dummyRecipes);
  }
}

class FakeToastrService {
  
}

describe('RecipeComponent', () => {
  let component: RecipeComponent;
  let fixture: ComponentFixture<RecipeComponent>;
  let injector;
  let recipeService: RecipeService;
  let toastrService: ToastrService;

  beforeEach(async(() => {  
    TestBed.configureTestingModule({
      imports: [
        HttpClientTestingModule,
        ReactiveFormsModule,
        FormsModule,
        ReactiveFormsModule,
        CommonModule,
        SharedModule,
        NgxDatatableModule,
        ButtonsModule.forRoot(),
        ModalModule.forRoot(),
        LaddaModule
      ],
      declarations: [RecipeComponent],
      providers: [
        {
          provide: RecipeService,
          useClass: FakeRecipeSerivce
        },
        {
          provide: ToastrService,
          useClass: FakeToastrService
        },
        
      ]
    }).compileComponents();

    injector = getTestBed();
    recipeService = injector.get(RecipeService);
    toastrService = injector.get(ToastrService);
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RecipeComponent);
    component = fixture.componentInstance;    
    fixture.detectChanges();
  });

  describe('#ngOnInit', () => {
    it('should load the recipes', () => {
      component.ngOnInit();
    });

    it('should render title in a h3 tag', async(() => {
      let compiled = fixture.debugElement.nativeElement;
      expect(compiled.querySelector('h3').textContent).toContain('Recipes');
    }));
  });
});
