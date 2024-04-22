import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { Router, RouterLink } from '@angular/router';
import { CartComponent } from '../../pages/cart/cart.component';
import { ApiService } from '../../services/api.service';
import { CartService } from '../../services/cart.service';
import { PaymentComponent } from '../../pages/payment/payment.component';
import { PaymentService } from '../../services/payment.service';

@Component({
  selector: 'app-header',
  standalone: true,
  imports: [
    RouterLink,
    CommonModule,
    CartComponent,
    PaymentComponent
  ],
  templateUrl: './header.component.html',
  styleUrl: './header.component.css'
})
export class HeaderComponent implements OnInit {
  public totalItem: number=0;
  public Item: number=0;

  constructor(private cart:CartService , private payment:PaymentService){ }

  ngOnInit(): void {
      // Fetch total items from cart list
  this.cart.getList().subscribe(res => {
    this.totalItem = res.length;
  });
   // Fetch total items from payment list
   this.payment.getpayList().subscribe(data => {
    this.Item = data.length;
  });

  }

}
