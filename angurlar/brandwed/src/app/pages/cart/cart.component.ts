import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import ProductsComponent from '../products/products.component';
import { Router, RouterLink } from '@angular/router';
import { MatCardModule } from '@angular/material/card';
import { ApiService } from '../../services/api.service';
import { CartService } from '../../services/cart.service';
import { PaymentService } from '../../services/payment.service';

@Component({
  selector: 'app-cart',
  standalone: true,
  imports: [
    FormsModule,
    CommonModule,
    ProductsComponent,
    RouterLink,

  ],
  templateUrl: './cart.component.html',
  styleUrl: './cart.component.css'
})
export class CartComponent implements OnInit {

  products: any[] = [];
  product: any []=[];

 productList: any [] = [];
 AddOrderDto:any[]=[];

  grandTotal !:number;




  constructor(private apiService:ApiService, private router:Router, public cart:CartService,public payment:PaymentService ){ }
  ngOnInit(): void {

    this.products=this.cart.cartItemList;

    this.calculateTotal();

  }
  calculateTotal(): void {
    this.grandTotal = this.products.reduce((total, product) => total + (product.productPrice * product.product_Quantity), 0);
  }
   getcart(){
    this.cart.getList().subscribe(res=>{
      this.products=res;
      // console.log(res)
      this.products.forEach(products =>
        {
            if (products.product_Image)
              {
               this.getImage(products.product_Image);
              }
        });

    })
  }
  getImage(cart: any): string {

    return `assets/products/${cart.product_Image}`;
  }
  increaseQuantity(product: any): void {
    this.cart.increaseQuantity(product);
    this.calculateTotal();
  }

  decreaseQuantity(product: any): void {
    this.cart.decreaseQuantity(product);
    this.calculateTotal();
  }


  removeCartitem(product:any){
    this.cart.removeCart(product);
    this.calculateTotal();
  }
   emptyCart(){
    this.cart.removeall();
    this.products = [];
    this.grandTotal = 0;
  }
  OnChecker(items: any[]): void {
    const addOrdersDtoList = items.map(item => ({
      product_Quantity: item.product_Quantity,
      product_Name: item.product_Name,
      CustomerId: 1, // Set the customerId to the appropriate value
      productId: item.product_Id,

    }));
    console.log(addOrdersDtoList);

    // Make a POST request to the server to add orders
    // Make a POST request to the server to add orders
    this.apiService.Cart(addOrdersDtoList).subscribe(
      response => {
        console.log('Orders added successfully:', response);
        // Handle the success response
      },
      error => {
        console.error('Error adding orders:', error);
        // Handle the error response
      }
    );

      }
    }
    //OnCheck(items: any) {
      //   this.payment.addtopay(items);
      // }
    //     OnCheckere (item: any): void {
    //   this.payment.addtopay(item);

    //   const newItem = {
    //     Product_Quantity: item.product_Quantity,
    //     Product_Name: item.product_Name,
    //     Product_Id:item.product_Id,
    //     CustomerId: 1 // Set the customerId to the appropriate value
    //   };

    //   // Add the new item to the cart
    //   this.apiService.Cart(newItem).subscribe({
    //         next: response => {
    //           // Handle the response here as text
    //           console.log('Product added to cart:', response);
    //         },
    //       });
    // }

//   OnChecker(items: any[]): void {
//     // Assuming addOrdersDtoList is an array of AddOrderDto objects
//     const addOrdersDtoList: AddOrderDto[] = items.map(item => ({
//         Order_Id: item.product_Id, // Assuming product_Id corresponds to Order_Id
//         CustomerId: 1, // Set the customerId to the appropriate value
//         ProductId: item.product_Id,
//         Product_Name: item.product_Name,
//         Product_Quantity: item.product_Quantity
//     }));

//     // Add the new item to the cart
//         this.apiService.Cart(addOrdersDtoList).subscribe({
//             next: response => {
//                 // Handle the response here as text
//                 console.log('Product added to cart:', response);
//             },
//             error: error => {
//                 // Handle any errors that occur during the API call
//                 console.error('Error adding product to cart:', error);
//             }
//     });

//     // Assuming this.payment.addtopay(item); is not needed for this functionality
// }
// Define the AddOrderDto type

  // OnChecker(item: any): void {
  //   // Create a new object with the provided data structure

  //   this.getcart();
  //   const newItem = {
    //     product_Quantity: item.product_Quantity,
  //     product_Name: item.product_Name,
  //     customerId: 1 // Set the customerId to the appropriate value
  //   };

  //   this.apiService.Cart(newItem).subscribe(res=>{
  //     this.products=res;
  //     console.log(res)
  //     this.products.forEach(products =>
  //       {
  //           if (products.product_Image)
  //             {
  //              this.getImage(products.product_Image);
  //             }
  //       });

  //   })
  // }
  // OnCheckered(item: any): void {
  //   // Create a new object with the provided data structure

  //   this.getcart();
  //   const newItem = {
  //     product_Quantity: item.product_Quantity,
  //     product_Name: item.product_Name,
  //     customerId: 1 // Set the customerId to the appropriate value
  //   };

  //   this.apiService.Cart(newItem).subscribe(res=>{
  //     this.productList=res;
  //     console.log(res)
  //     this.products.forEach(products =>
  //       {
  //           if (products.product_Image)
  //             {
  //              this.getImage(products.product_Image);
  //             }
  //       });

  //   })}


  // OnCheck(product:any){
  //   this.getcart();


  //   const requestData = {
  //     product_Id: product.product_Id,
  //     Product_Name: product.product_Name,
  //     Product_Quantity: product.product_Quantity,  // Assuming 1 quantity is added for each click
  //     CustomerId: 1,  // Set the customerId to 1
  //     // Add more properties if required
  //   };

  //   // Send a POST request to the OrdersController Insert endpoint
  //   this.cart.paycart(requestData).subscribe({
  //     next: response => {
  //       // Handle the response here as text
  //       console.log('Product added to cart:', response);
  //     },
  //   });

  // }
  // OnCheck(product: any): void {
  //   if (!product) {
  //     console.error('Product data is missing.');
  //     return;
  //   }
  //   const requestData = {
  //     ProductId: product.product_Id,
  //     Product_Name: product.product_Name,
  //     Product_Quantity: product.product_Quantity,
  //     CustomerId: 1, // Assuming the customerId is fixed or retrieved from somewhere
  //   };

  //   this.cart.paycart(requestData).subscribe(
  //     (response) => {
  //       console.log('Product added to cart:', response);
  //       // Handle the response here
  //     },
  //     (error) => {
  //       console.error('Error adding product to cart:', error);
  //       // Handle errors here
  //     }
  //   );
  // }

  // OnCheck(item:any){
  //   // this.cart.paycart(item).subscribe((res=>{
  //   //   this.products=res;
  //   //   res=item;

  //   //   console.log(res);

  //   // }))
  //   this.getcart();
  //   this.products=item;

  //   const requestData = {
  //     ProductId: item.product_Id,
  //     Product_Name: item.product_Name,
  //     Product_Quantity: item.product_Quantity,  // Assuming 1 quantity is added for each click
  //     CustomerId: 1,  // Set the customerId to 1
  //     // Add more properties if required
  //   };

  //   // Send a POST request to the OrdersController Insert endpoint
  //   this.cart.paycart(requestData).subscribe({
  //     next: response => {
  //       // Handle the response here as text
  //       console.log('Product added to cart:', response);
  //     },
  //   });

  // }

