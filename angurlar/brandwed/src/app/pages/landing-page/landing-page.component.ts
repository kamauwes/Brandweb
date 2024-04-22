import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import ProductsComponent from '../products/products.component';
import { ApiService } from '../../services/api.service';
import { RouterOutlet } from '@angular/router';
import { UserHomeComponent } from "../user-home/user-home.component";

@Component({
    selector: 'app-landing-page',
    standalone: true,
    templateUrl: './landing-page.component.html',
    styleUrl: './landing-page.component.css',
    imports: [
        CommonModule,
        ProductsComponent,
        RouterOutlet,
        UserHomeComponent
    ]
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

