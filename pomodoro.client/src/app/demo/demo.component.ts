import { Component } from '@angular/core';
import { UserInfo } from '../../models/UserInfo';

@Component({
  selector: 'app-demo',
  templateUrl: './demo.component.html',
  styleUrl: './demo.component.css'
})

export class DemoComponent {

  userInfo: UserInfo = {
    userName: 'praveen',
    userPassword: 'Nothing',
    userLevel: 0
  };

  SaveForm() {
    console.log("SaveForm button clicked.");
    console.log(`userName value is : ${this.userInfo.userName}`)
    console.log(`userPassword value is : ${this.userInfo.userPassword}`)
    console.log(`userLevel value is : ${this.userInfo.userLevel}`)
  }
  OnDemoChangeClick($event: Event) {
    console.log("OnDemoChangeClick button clicked.");
    console.log($event);

  }
  OnDemoClick() {
    console.log("DemoClicked button clicked.");
    //console.log($event);

  }
}
