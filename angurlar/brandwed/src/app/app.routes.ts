import { Component } from '@angular/core';
import { Routes } from '@angular/router';
import { LandingPageComponent } from './pages/landing-page/landing-page.component';
import ProductsComponent from './pages/products/products.component';
import { UserHomeComponent } from './pages/user-home/user-home.component';
import { CartComponent } from './pages/cart/cart.component';
import { PaymentComponent } from './pages/payment/payment.component';
import { PayComponent } from './pages/pay/pay.component';
import { LoginComponent } from './pages/login/login.component';
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
  },
  {
    path:'cart',
    component:CartComponent
  },
  {
    path:'payment',
    component:PaymentComponent
  },
  {
    path:'pay',
    component:PayComponent
  },
  {
    path:'login',
    component:LoginComponent
  },
]
}];
