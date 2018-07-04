import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';


const routes: Routes = [
  { path: '', redirectTo: 'cookbook', pathMatch: 'full' },
  //{ path: 'cookbook', component: CookbookComponent, data: { title: 'Cookbook' } },
  {
    path: 'users',
    //component: ,
    data: {
      title: 'Recipe'
    }
  }

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CookbookRoutingModule {}
