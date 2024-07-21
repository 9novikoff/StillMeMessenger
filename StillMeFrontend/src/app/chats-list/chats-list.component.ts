import { Component } from '@angular/core';
import { ChatItemComponent } from '../chat-item/chat-item.component';

@Component({
  selector: 'app-chats-list',
  standalone: true,
  imports: [ChatItemComponent],
  templateUrl: './chats-list.component.html',
  styleUrl: './chats-list.component.css'
})
export class ChatsListComponent {

}
