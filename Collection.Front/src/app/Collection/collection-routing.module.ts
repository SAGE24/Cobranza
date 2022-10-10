import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { HomeComponent } from './components/home/home.component';
import { HomePageComponent } from './components/home-page/home-page.component';
import { DebtorComponent } from './components/debtor/debtor.component';

const routes: Routes = [
  { 
    path:'', component: HomeComponent, children:[
      { path: '', component: HomePageComponent },
      { path: 'Debtor', component: DebtorComponent }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CollectionRoutingModule { }
