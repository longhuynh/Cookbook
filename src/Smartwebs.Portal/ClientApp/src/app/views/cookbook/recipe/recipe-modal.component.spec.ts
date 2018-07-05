import { async, ComponentFixture, TestBed, getTestBed } from '@angular/core/testing';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/observable/of';
import { RecipeModalComponent } from './recipe-modal.component';
import { RecipeService, QueryResult, Recipe } from './recipe.service';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { ButtonsModule } from 'ngx-bootstrap/buttons';
import { ModalModule, BsModalRef } from 'ngx-bootstrap/modal';
import { LaddaModule } from 'angular2-ladda';

const dummyRecipes = [
  {
    items: [
      { id: 1, description: 'description 1' },
      { id: 2, description: 'description 2' }
    ]
  }
];

class FakeRecipeSerivce {
  
}

class FakeBsModalRef{
  
}

describe('RecipeModalComponent', () => {
  let component: RecipeModalComponent;
  let fixture: ComponentFixture<RecipeModalComponent>;
  let injector;
  let recipeService: RecipeService;
  let bsModalRef: BsModalRef;

  beforeEach(async(() => {  
    TestBed.configureTestingModule({
      imports: [
        HttpClientTestingModule,
        ReactiveFormsModule,
        FormsModule,
        ReactiveFormsModule,
        CommonModule,
        ButtonsModule.forRoot(),
        ModalModule.forRoot(),
        LaddaModule
      ],
      declarations: [RecipeModalComponent],
      providers: [
        {
          provide: RecipeService,
          useClass: FakeRecipeSerivce
        },
        {
          provide: BsModalRef,
          useClass: FakeBsModalRef
        },
      ]
    }).compileComponents();

    injector = getTestBed();
    recipeService = injector.get(RecipeService);
    bsModalRef = injector.get(BsModalRef);
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RecipeModalComponent);
    component = fixture.componentInstance;    
    fixture.detectChanges();
  });

  describe('#ngOnInit', () => {
    it('should load the recipes', () => {
      component.ngOnInit();
    });

    it('should render title in a h4 tag', async(() => {

      let compiled = fixture.debugElement.nativeElement;
      expect(compiled.querySelector('h4').textContent).toContain(component.title);
    }));
  });
});
