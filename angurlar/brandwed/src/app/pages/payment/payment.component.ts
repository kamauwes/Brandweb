import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { MatCardModule } from '@angular/material/card';
import { Router, RouterLink } from '@angular/router';
import ProductsComponent from '../products/products.component';
import { ApiService } from '../../services/api.service';
import { CartService } from '../../services/cart.service';
import { PaymentService } from '../../services/payment.service';

@Component({
  selector: 'app-payment',
  standalone: true,
  imports: [

    FormsModule,
    CommonModule,
    ProductsComponent,
    MatCardModule,
    RouterLink
  ],
  templateUrl: './payment.component.html',
  styleUrl: './payment.component.css'
})
export class PaymentComponent {

  productsList: any[] = [];
  productArray:any[]=[];

  grandTotal !:number;
  products:any[]=[];

  constructor(private apiService:ApiService, private router:Router,public payment:PaymentService,public cart:CartService){ }
  ngOnInit(): void {

    this.productsList=this.payment.payItemList;
    this.products=this.cart.cartItemList;

    this.calculateTotal();

  }

  getcart(){
    this.payment.getpayList().subscribe(res=>{
      this.productsList=res;
      // console.log(res)
      // this.productsList.forEach(product =>
      //   {
      //       if (product.product_Image)
      //         {
      //          this.getImage(product.product_Image);
      //         }
      //   });

    })
  }

  getImage(cart: any): string {

    return `assets/products/${cart.product_Image}`;
  }
  calculateTotal(): void {
    this.grandTotal = this.cart.cartItemList.reduce((total, product) => total + (product.productPrice * product.product_Quantity), 0);
  }
  // increaseQuantity(product: any): void {
  //   this.payment.increaseQuantity(product);
  //   this.calculateTotal();
  // }

  // decreaseQuantity(product: any): void {
  //   this.payment.decreaseQuantity(product);
  //   this.calculateTotal();
  // }
  // removeCartitem(product:any){
  //   this.payment.removeCart(product);
  //   this.calculateTotal();
  // }
  emptyCart(){
    this.payment.removeall();
    this.cart.cartItemList = [];
    this.grandTotal = 0;
  }
}
