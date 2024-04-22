import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PaymentService {
  [x: string]: any;

  public payList = new BehaviorSubject<any>([]);

  public payItemList: any []= [];
  
  public payItems:any[]=[];

  constructor() { }

  getpayList(){
  
    return this.payList.asObservable();
  
  }
  
  setProdd(prod:any){
  
    this.payItemList.push(...prod);
  
    this.payList.next(prod);
  
  }

  addtopay(product:any)
   {
    this.payItemList.push(product);
    this.payList.next(this.payItemList);
    this.getTotalPrice();
    console.log(this.payItemList)
  }

  
  getTotalPrice():number{
    let grandTotal = 0;

    this.payItemList.map((a:any)=>{

    grandTotal+=a.total;
  })
  return grandTotal;
  }
  // increaseQuantity(product: any): void {
  //   const cartProduct = this.payItemList.find(p => p.product_Id === product.product_Id);
  //   if (cartProduct) {
  //     cartProduct.product_Quantity++;
  //     cartProduct.total = cartProduct.product_Quantity * cartProduct.productPrice; // Recalculate total
  //   }
  // }

  // decreaseQuantity(product: any): void {
  //   const cartProduct = this.payItemList.find(p => p.product_Id === product.product_Id);
  //   if (cartProduct && cartProduct.product_Quantity > 1) {
  //     cartProduct.product_Quantity--;
  //     cartProduct.total = cartProduct.product_Quantity * cartProduct.productPrice; // Recalculate total
  //   }
  // }



  // removeCart(prod:any){
  //   this.payItemList.map((a:any,index:any)=>{
  //     if(prod.product_Id==a.product_Id){
  //       this.payItemList.splice(index,1);
  //     }
  //   })
  //   this.payItemList.next(this.payItemList);
  // }

  removeall(){
    this.payItemList= []
    this.payList.next(this.payItemList);
  }
}
