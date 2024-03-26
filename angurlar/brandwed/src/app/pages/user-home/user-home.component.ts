import { Component } from '@angular/core';
import { ApiService } from '../../services/api.service';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { ProductsComponent } from '../products/products.component';
import { Router } from '@angular/router';
import { MatCardModule } from '@angular/material/card';

@Component({
  selector: 'app-user-home',
  standalone: true,
  imports: [
    FormsModule,
    CommonModule,
    ProductsComponent,
    MatCardModule,

          ],
  templateUrl: './user-home.component.html',
  styleUrl: './user-home.component.css'
})
export class UserHomeComponent {

  productList: any ;
  saleList: any ;
  productIdlist:any;

  constructor(private apiService:ApiService, private router:Router){ }


  ngOnInit(): void {
    // this.getAllInventory();
    this. getallsales();
    this.apiService.getOnSale().subscribe((res)=>{
      this.saleList=res;
    });
    this.getProductbyId();
    this.apiService.getProducts().subscribe((data)=>{
      this.productList=data;
    });
}
productDetails(id:number){
  this.apiService.getProductById(id).subscribe((data)=>{
    this.productIdlist=data;
  });
}
getProductbyId(){
  // this.apiService.getProductById(this.apiService.id).subscribe((data:any)=>{
  //   this.productList= data;


  //     })
    }
    
getallsales(){
      this.apiService.getOnSale().subscribe((res:any)=>{
        this.saleList= res;
        console.log(res)
    
          })
        }
    // onAdd(item:any){
    //   this.productObj = item;
    // }

}
