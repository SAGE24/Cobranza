import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';

import { CollectionRoutingModule } from './collection-routing.module';
import { HomeComponent } from './components/home/home.component';
import { HomePageComponent } from './components/home-page/home-page.component';
import { DebtorComponent } from './components/debtor/debtor.component';

import { ServicesModule } from './services/services.module';
import { DebtorRegisterComponent } from './components/debtor/debtor-register/debtor-register.component';

@NgModule({
  declarations: [
    HomeComponent,
    HomePageComponent,
    DebtorComponent,
    DebtorRegisterComponent
  ],
  imports: [
    CommonModule,
    CollectionRoutingModule,
    ServicesModule,
    ReactiveFormsModule, FormsModule
  ]
})
export class CollectionModule { }
