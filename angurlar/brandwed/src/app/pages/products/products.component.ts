import { Component, Input, OnInit } from '@angular/core';

import { CommonModule } from '@angular/common';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { ApiService } from '../../services/api.service';
import { HttpResponse } from '@angular/common/http';
import { Observable, switchMap, tap } from 'rxjs';

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
export default class ProductsComponent implements OnInit{
form!:FormGroup
currentFile?: File;
message = '';

preview = '';
imageInfos?: Observable<any>;

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
productIdlist:any;

file:any;


constructor(private apiService:ApiService,private fb:FormBuilder){

}
ngOnInit(): void {
    this.form=this.fb.group({
    product_Id:[''],
    ImageName: [''],
    productPrice: [''],
    product_Quantity: [''],
    product_Image: [''],
    product_Description: [''],
    product_Category: [''],
    inventoryId: ['0'],
    file:['']
    })
    ;


    // this.getAllInventory();
    this.getallProducts();
}
getallProducts(){
  this.apiService.getProducts().subscribe((res:any)=>{
    this.productList= res;
    console.log(res)
       })
             // Call getImage for each product in the list
      this.productList.forEach(product => {
        if (product.product_Image) {
          this.getImage(product.product_Image);
        }
      });
}


getImage(product: any): string {
  // Assuming product.product_Image contains only the filename of the image
  return `assets/products/${product.product_Image}`;
}

// updateproducts(){
//   this.apiService.updateProductById().subscribe((res:any)=>{
//     this.productList= res;
//     console.log(res)

//       })
// }
// getAllInventory(){
//   this.apiService.getInventory().subscribe((res:any)=>{
//   this.inventoryList= res;

//   })

//  }

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
// update(){
//   this.apiService.updateProductById(this.form.value,this.productObj.product_Id).subscribe((res:any)=>{
//     this.getallProducts();
//   })

// }
update(): void {
  const saveProduct = (res: any) => {

    if (res.result) {
      alert("Product created");
      this.getallProducts();
    }
    //  else {
    //   alert(res.message || 'Error occurred while saving the product!');
    // }
  };

  const handleError = (err: any) => {
    console.log(err);
    this.message = err.error && err.error.message ? err.error.message : 'Error occurred while saving the product!';
  };

  const formData = new FormData();
  if (this.currentFile) {
    formData.append('file', this.currentFile);
    formData.append('ImageName', this.form.get('ImageName')?.value);
    formData.append('productPrice', this.form.get('productPrice')?.value);
    formData.append('product_Quantity', this.form.get('product_Quantity')?.value);
    formData.append('product_Description', this.form.get('product_Description')?.value);
    formData.append('product_Category', this.form.get('product_Category')?.value);
    formData.append('inventoryId', this.form.get('inventoryId')?.value);

    this.apiService.updateProductById(formData,this.productObj.product_Id).subscribe(saveProduct, handleError);
  } else {
    alert("Please select a file");
  }
  this.getallProducts();
}
onDelete(id:any)
{
  this.apiService.deleteProductById(id).subscribe((res:any)=>{
    this.getallProducts();
  })
}

selectFile(event: any): void {
  const selectedFiles = event.target.files;
  if (selectedFiles) {
    const file: File | null = selectedFiles.item(0);
    if (file) {
      this.form.patchValue({ file: file });
      this.currentFile = file;
      const reader = new FileReader();

      reader.onload = (e: any) => {
        this.preview = e.target.result;
      };
      reader.readAsDataURL(this.currentFile);
    }
  }
}
save(){
  let formValue=this.form.value
  this.apiService.createProducts(formValue).subscribe((res:any)=>{
    if(res.result){
    alert ("product created");

     this.getallProducts();
    }else{
    alert(res.message)
    }
  })
}

saveAndUpload(): void {
  const saveProduct = (res: any) => {

    if (res.result) {
      alert("Product created");
    }

  };

  const handleError = (err: any) => {
    console.log(err);
    this.message = err.error && err.error.message ? err.error.message : 'Error occurred while saving the product!';
  };

  const formData = new FormData();
  if (this.currentFile) {
    formData.append('file', this.currentFile);
    formData.append('ImageName', this.form.get('ImageName')?.value);
    formData.append('productPrice', this.form.get('productPrice')?.value);
    formData.append('product_Quantity', this.form.get('product_Quantity')?.value);
    formData.append('product_Description', this.form.get('product_Description')?.value);
    formData.append('product_Category', this.form.get('product_Category')?.value);
    formData.append('inventoryId', this.form.get('inventoryId')?.value);

    this.apiService.createProducts(formData).subscribe(saveProduct, handleError);
  } else {
    alert("Please select a file");
  }
  this.getallProducts();
}



    openSidePanel(){
      this.isSidePanelvisible=true;
    }
    closeSidePanel(){
      this.isSidePanelvisible=false;
    }

}
