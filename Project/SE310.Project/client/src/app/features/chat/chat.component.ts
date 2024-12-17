// import { Component } from '@angular/core';
// import { CommonModule } from '@angular/common';  // Đảm bảo CommonModule được nhập vào
// import { FormsModule } from '@angular/forms';    // Đảm bảo FormsModule được nhập vào
// import { ChatService } from '../../core/services/chat.service';

// @Component({
//   selector: 'app-chat',
//   standalone: true,
//   imports: [CommonModule, FormsModule],  // Thêm các module này vào imports
//   templateUrl: './chat.component.html',
// })
// export class ChatComponent {
//   userMessage = '';
//   messages: { sender: string, text: string }[] = [];

//   sendMessage() {
//     if (this.userMessage.trim()) {
//       // Thêm tin nhắn người dùng vào danh sách tin nhắn
//       this.messages.push({ sender: 'user', text: this.userMessage });
//       // Gửi tin nhắn và nhận phản hồi từ API (ví dụ OpenAI hoặc API khác)
//       // Giả sử bạn có service để gọi API
//       this.chatService.sendMessage(this.userMessage).subscribe(response => {
//         // Thêm tin nhắn của trợ lý vào danh sách
//         this.messages.push({ sender: 'assistant', text: response });
//         this.userMessage = '';  // Làm trống ô nhập liệu
//       });
//     }
//   }
// }
