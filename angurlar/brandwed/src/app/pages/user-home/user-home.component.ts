import { Component, OnInit } from '@angular/core';
import { ApiService } from '../../services/api.service';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import ProductsComponent from '../products/products.component';
import { Router , RouterLink} from '@angular/router';
import { MatCardModule } from '@angular/material/card';
import { Observable } from 'rxjs';
import { HttpResponse } from '@angular/common/http';
import { CartComponent } from '../cart/cart.component';
import { CartService } from '../../services/cart.service';

@Component({
  selector: 'app-user-home',
  standalone: true,
  imports: [
    FormsModule,
    CommonModule,
    ProductsComponent,
    RouterLink,
    MatCardModule,

          ],
  templateUrl: './user-home.component.html',
  styleUrl: './user-home.component.css'
})
export class UserHomeComponent implements OnInit {

  productList: any [] = [];
  saleList: any []=[] ;
  productIdlist:any;

  constructor(private apiService:ApiService, private router:Router,private cart:CartService){ }


  ngOnInit(): void {

    // this.getAllInventory();
    this. getallsales();
    this. getallProducts();

    this.productList.forEach((a:any)=>{
      Object.assign(a,{Product_Quantity: 1,total:a.productPrice});
    });
    // this.apiService.getOnSale().subscribe((res)=>{
    //   this.saleList=res;
    // });


}




getallsales(){
      this.apiService.getOnSale().subscribe((res:any)=>{
        this.saleList= res;

                    this.productList.forEach(sale => {
                      if (sale.image) {
                        this.getImage(sale.image);
                      }
                    });

          })
        }
        getallProducts(){
          this.apiService.getProducts().subscribe((res:any)=>{
            this.productList= res;

               })
                     // Call getImage for each product in the list
              this.productList.forEach(product => {
                if (product.product_Image) {
                  this.getProdImage(product.product_Image);
                }
              });
        }

        getProdImage(product: any): string {
          return `assets/products/${product.product_Image}`;
        }


        getImage(sale: any): string {
          // Assuming product.product_Image contains only the filename of the image
          return `assets/products/${sale.image}`;
        }
        // goToCart(){

        // }
        addToCart(item: any){
            this.cart.addtocart(item);
        }


//  addToCart(product: any): void {
//           // Prepare the data to be sent in the request body
//           const requestData = {
//             ProductId: product.product_Id,
//             Product_Name: product.product_Name,
//             Product_Quantity: 1,  // Assuming 1 quantity is added for each click
//             CustomerId: 1,  // Set the customerId to 1
//             // Add more properties if required
//           };

//           // Send a POST request to the OrdersController Insert endpoint
//           this.apiService.addToCart(requestData).subscribe({
//             next: response => {
//               // Handle the response here as text
//               console.log('Product added to cart:', response);
//             },
//           });
//         }


}
