import { GuardService } from './Auth/guard.service';
import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  constructor(private guardService: GuardService) {
    guardService.getUser().subscribe(x => {
      if( x != null) {
        localStorage.setItem('user', x.name);
      } else {
        localStorage.setItem('user', '');
      }
    });
  }
  title = 'client';
}
