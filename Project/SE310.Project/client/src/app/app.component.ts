import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { ShopComponent } from './features/shop/shop.component';
import { HeaderComponent } from './layout/header/header.component';
import { FooterComponent } from "./layout/footer/footer.component";
// import { ChatComponent } from './features/chat/chat.component';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, HeaderComponent, ShopComponent, FooterComponent, CommonModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss',
})
export class AppComponent {
  title = 'PMQ Pharmacy';
  isChatOpen = false;

  // openChat() {
  //   this.isChatOpen = !this.isChatOpen; // Mở hoặc đóng cửa sổ chat
  // }
}
