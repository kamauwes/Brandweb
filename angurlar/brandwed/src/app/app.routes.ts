import { Component } from '@angular/core';
import { Routes } from '@angular/router';
import { LandingPageComponent } from './pages/landing-page/landing-page.component';
import { ProductsComponent } from './pages/products/products.component';
import { UserHomeComponent } from './pages/user-home/user-home.component';

export const routes: Routes = [
{path: '',
component:LandingPageComponent,
children:[

{
  path:'products',
  component:ProductsComponent
},
  {
    path:'home',
    component:UserHomeComponent
  }
]
}];
