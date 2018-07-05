import { TestBed, getTestBed, inject } from '@angular/core/testing';
import { HttpClientTestingModule, HttpTestingController} from '@angular/common/http/testing';
import { HttpParams } from '@angular/common/http';
import { RecipeService, Recipe, QueryResult, SaveRecipeRequest } from './recipe.service';

describe('RecipeService', () => {
  let injector;
  let service: RecipeService;
  let httpMock: HttpTestingController;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      providers: [RecipeService]
    });

    injector = getTestBed();
    service = injector.get(RecipeService);
    httpMock = injector.get(HttpTestingController);
  });

  describe('#getRecipes', () => {
    it('should return recipes', () => {
      const dummyRecipes: QueryResult<Recipe> = {
        items: [
          { id: 1, description: 'description 1' },
          { id: 2, description: 'description 2' }
        ]
      };

      service.getRecipes().subscribe(recipes => {
        expect(recipes.items.length).toBe(2);
        expect(recipes).toEqual(dummyRecipes);
      });

      const req = httpMock.expectOne(`${service.api}`);
      expect(req.request.method).toBe('GET');
      req.flush(dummyRecipes);
    });
  });

  describe('#getRecipeVersions', () => {
    it('should return recipe versions', () => {
      const dummyRecipes: QueryResult<Recipe> = {
        items: [
          { id: 1, description: 'description 1' },
          { id: 2, description: 'description 2' }
        ]
      };

      service.getRecipeVersions(1).subscribe(recipes => {
        expect(recipes.items.length).toBe(2);
        expect(recipes).toEqual(dummyRecipes);
      });

      const req = httpMock.expectOne(`${service.api}/1/versions`);
      expect(req.request.method).toBe('GET');
      req.flush(dummyRecipes);
    });
  });

  describe('#createRecipe', () => {
    it('should create recipe', () => {
      const dummyRecipe: SaveRecipeRequest = {
        description: 'description'
      };

      service.createRecipe(dummyRecipe).subscribe(recipe => {
        expect(recipe.description).toBe('description');
      });

      const req = httpMock.expectOne(`${service.api}`);
      expect(req.request.method).toBe('POST');
      req.flush(dummyRecipe);
    });
  });

  describe('#createRecipe', () => {
    it('should create recipe', () => {
      const dummyRecipe: SaveRecipeRequest = {
        description: 'description'
      };

      service.updateRecipe(1, dummyRecipe).subscribe(recipe => {
        expect(recipe.description).toBe('description');
      });

      const req = httpMock.expectOne(`${service.api}/1`);
      expect(req.request.method).toBe('PUT');
      req.flush(dummyRecipe);
    });
  });

});
