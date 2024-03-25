import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { ProductsComponent } from '../products/products.component';
import { ProductsService } from '../../services/products.service';
import { Product, Products } from '../../../types';
import { ApiService } from '../../services/api.service';
import { RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-landing-page',
  standalone: true,
  imports: [
    CommonModule,
    ProductsComponent,
    RouterOutlet,
  ],
  templateUrl: './landing-page.component.html',
  styleUrl: './landing-page.component.css'
})
export class LandingPageComponent {
constructor(
  private apiservice : ApiService
){}

// productlist:any[]=[];

// ngOnInit(): void {
//   this.getAllproducts();
// }
// getAllproducts(){
// this.apiservice.getProducts().subscribe((prod:any)=>{
// this.productlist=prod.data;
// console.log(prod)
// })}


 }

