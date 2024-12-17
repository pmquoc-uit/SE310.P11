import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ChatService {
  baseUrl = environment.apiUrl;
  private apiUrl = `${this.baseUrl}/chat`;  // Thay URL này bằng URL backend của bạn

  constructor(private http: HttpClient) {}

  // Gửi tin nhắn đến API backend và nhận phản hồi
  sendMessage(message: string): Observable<string> {
    return this.http.post<string>(this.apiUrl, message);
  }
}
