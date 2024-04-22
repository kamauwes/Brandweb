import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { HeaderComponent } from './page-layout/header/header.component';
import { FooterComponent } from './page-layout/footer/footer.component';
import { r3JitTypeSourceSpan } from '@angular/compiler';
import { CartComponent } from "./pages/cart/cart.component";

@Component({
    selector: 'app-root',
    standalone: true,
    templateUrl: './app.component.html',
    styleUrl: './app.component.css',
    imports: [
        RouterOutlet,
        HeaderComponent,
        FooterComponent,
        CartComponent
    ]
})
export class AppComponent {
  title = 'brandwed';
}
