import { CommonModule } from '@angular/common';
import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { MatCardModule } from '@angular/material/card';
import { Router, RouterLink } from '@angular/router';
import ProductsComponent from '../products/products.component';
import { ApiService } from '../../services/api.service';
import { CartService } from '../../services/cart.service';
import { PaymentService } from '../../services/payment.service';

@Component({
  selector: 'app-pay',
  standalone: true,
  imports: [
    FormsModule,
    CommonModule,
    ProductsComponent,
    MatCardModule,
    RouterLink,

  ],
  templateUrl: './pay.component.html',
  styleUrl: './pay.component.css'
})
export class PayComponent implements OnInit{
  
  @ViewChild('paymentRef',{static:true}) paymentRef!:ElementRef

  constructor(private apiService:ApiService, private router:Router, public cart:CartService,public payment:PaymentService){ }
  ngOnInit(): void {
    console.log(window.paypal);
    window.paypal.Buttons().render(this.paymentRef.nativeElement);
  }



  cancel(){
    this.router.navigate(['cart'])
  }

  grandTotal !:number;

}
