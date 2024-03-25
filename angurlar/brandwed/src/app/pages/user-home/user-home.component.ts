import { Component } from '@angular/core';
import { ApiService } from '../../services/api.service';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { ProductsComponent } from '../products/products.component';

@Component({
  selector: 'app-user-home',
  standalone: true,
  imports: [
    FormsModule,
    CommonModule,
    ProductsComponent

          ],
  templateUrl: './user-home.component.html',
  styleUrl: './user-home.component.css'
})
export class UserHomeComponent {
  productObj: any= {
    "product_Id": 0,
    "product_Name": "",
    "productPrice": 0,
    "product_Quantity": 0,
    "product_Image": "",
    "product_Description": "",
    "product_Category": "",
    "inventoryId": 0
  }
  productList: any [] = [];

  constructor(private apiService:ApiService,){ }


  ngOnInit(): void {
    // this.getAllInventory();
    this.getProduct();
}
getProduct(){
  this.apiService.getProductById(this.productObj).subscribe((res:any)=>{
    this.productList= res;
    console.log(res)

      })
    }
    onAdd(item:any){
      this.productObj = item;
    }

}
