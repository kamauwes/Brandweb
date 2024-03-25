import { Component, Input, OnInit } from '@angular/core';
import { Product } from '../../../types';
import { CommonModule } from '@angular/common';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ApiService } from '../../services/api.service';

@Component({
  selector: 'app-products',
  standalone: true,
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
  ],
  templateUrl: './products.component.html',
  styleUrl: './products.component.css'
})
export class ProductsComponent implements OnInit{
form!:FormGroup

  isSidePanelvisible:boolean=false;

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
inventoryList: any [] = [];
productList: any [] = [];


constructor(private apiService:ApiService,private fb:FormBuilder){

}
ngOnInit(): void {
    this.form=this.fb.group({
    product_Id:[''],
    product_Name: [''] ,
    productPrice: [''],
    product_Quantity: [''],
    product_Image: [''],
    product_Description: [''],
    product_Category: [''],
    inventoryId: ['0']
    });

    this.getAllInventory();
    this.getallProducts();
}
getallProducts(){
  this.apiService.getProducts().subscribe((res:any)=>{
    this.productList= res;
    console.log(res)

      })
}
// updateproducts(){
//   this.apiService.updateProductById().subscribe((res:any)=>{
//     this.productList= res;
//     console.log(res)

//       })
// }
getAllInventory(){
  this.apiService.getInventory().subscribe((res:any)=>{
  this.inventoryList= res;

  })

}
save(){
  this.apiService.createProducts(this.form.value).subscribe((res:any)=>{
    if(res.result){
    alert ("product created");

     this.getallProducts();
    }else{
    alert(res.message)
    }
  })
}

onNew(item:any){
this.form=item;
this.form.patchValue(item)
this.openSidePanel();
}
onEdit(item:any){
  this.productObj = item;
  this.form.patchValue(item)
  this.openSidePanel();
}
update(){
  this.apiService.updateProductById(this.form.value,this.productObj.product_Id).subscribe((res:any)=>{
    this.getallProducts();
  })

}
onDelete(id:any)
{
  this.apiService.deleteProductById(id).subscribe((res:any)=>{
    this.getallProducts();
  })
}



  openSidePanel(){
    this.isSidePanelvisible=true;
  }
  closeSidePanel(){
    this.isSidePanelvisible=false;
  }

}
