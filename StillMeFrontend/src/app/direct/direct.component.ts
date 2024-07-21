import { Component } from '@angular/core';
import { NavbarComponent } from '../navbar/navbar.component';
import { ContentComponent } from '../content/content.component';
import { ChatsListComponent } from '../chats-list/chats-list.component';

@Component({
  selector: 'app-direct',
  standalone: true,
  imports: [NavbarComponent, ContentComponent, ChatsListComponent],
  templateUrl: './direct.component.html',
  styleUrl: './direct.component.css'
})
export class DirectComponent {

}
