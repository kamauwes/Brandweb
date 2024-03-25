import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { HeaderComponent } from './page-layout/header/header.component';
import { FooterComponent } from './page-layout/footer/footer.component';
import { r3JitTypeSourceSpan } from '@angular/compiler';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [
    RouterOutlet,
    HeaderComponent,
    FooterComponent
    ],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'brandwed';
}
