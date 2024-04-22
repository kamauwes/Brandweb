import { HttpClient } from '@angular/common/http';
import { Injectable, OnInit } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CartService  {
 
  public productList = new BehaviorSubject<any>([]);
  
  public cartItemList: any []= [];

  public cartItems:any[]=[];
  public cart = "https://localhost:7138/api/Orders"

  constructor(
    private httpClient: HttpClient
  ) { }

  
  // paycart(newItem: { product_Quantity: any; product_Name: any; customerId: number; }) {
  //   return this.httpClient.post(this.cart)
    
  // }

  getList(){
    return this.productList.asObservable();

  }
  setProd(prod:any){
    this.cartItemList.push(...prod);
    this.productList.next(prod);
  }

  addtocart(product:any){

    const existingProduct = this.cartItemList.find(p => p.product_Id == product.product_Id);
    if (existingProduct) {
      existingProduct.product_Quantity++; // Increment quantity if the product already exists in the cart
    } else
   {
    this.cartItemList.push(product);
    this.productList.next(this.cartItemList);
    this.getTotalPrice();
    console.log(this.cartItemList)
  }
 
  }


  increaseQuantity(product: any): void {
    const cartProduct = this.cartItemList.find(p => p.product_Id === product.product_Id);
    if (cartProduct) {
      cartProduct.product_Quantity++;
      cartProduct.total = cartProduct.product_Quantity * cartProduct.productPrice; // Recalculate total
    }
  }

  decreaseQuantity(product: any): void {
    const cartProduct = this.cartItemList.find(p => p.product_Id === product.product_Id);
    if (cartProduct && cartProduct.product_Quantity > 1) {
      cartProduct.product_Quantity--;
      cartProduct.total = cartProduct.product_Quantity * cartProduct.productPrice; // Recalculate total
    }
  }
  getTotalPrice():number{
    let grandTotal = 0;

    this.cartItemList.map((a:any)=>{

    grandTotal+=a.total;
  })
  return grandTotal;
  }


  removeCart(prod:any){
    this.cartItemList.map((a:any,index:any)=>{
      if(prod.product_Id==a.product_Id){
        this.cartItemList.splice(index,1);
      }
    })
    this.productList.next(this.cartItemList);
  }

  removeall(){
    this.cartItemList= []
    this.productList.next(this.cartItemList);
  }
}
