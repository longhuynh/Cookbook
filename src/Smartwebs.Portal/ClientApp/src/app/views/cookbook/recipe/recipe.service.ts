import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';

@Injectable()
export class RecipeService {
  api = '/api/cookbook/recipes';

  constructor(private http: HttpClient) { }

  getRecipes(): Observable<QueryResult<Recipe>> {
    return this.http.get<QueryResult<Recipe>>(this.api);
  }

  getRecipeVersions(id: number): Observable<QueryResult<Recipe>> {
    return this.http.get<QueryResult<Recipe>>(`${this.api}/${id}/versions`);
  }

  createRecipe(recipe: SaveRecipeRequest): Observable<any> {
    return this.http.post(this.api, recipe);
  }

  updateRecipe(id: number, recipe: SaveRecipeRequest): Observable<any> {
    return this.http.put(`${this.api}/${id}`, recipe);
  }
}

export interface QueryResult<TModel> {
  items: TModel[];
}

export interface Recipe {
  id: number;
  description: string;
}

export interface SaveRecipeRequest {
  description: string;
}
