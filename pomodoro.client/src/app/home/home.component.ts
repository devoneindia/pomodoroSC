import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

interface User {
  id: string;
  username: string;
  password: string;
}

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  public uservalue: User[] = [];
  public newUser: User = {
    id: '',
    username: '',
    password: ''
  };

  constructor(private http: HttpClient) { }

  SaveUser() {
    this.http.post<User>('/api/user', this.newUser).subscribe(
      (result) => {
        console.log('saved successfully:', result);
        // Clear the form fields after successful submission
        this.newUser.username = '';
        this.newUser.password = '';
      },
      (error) => {
        console.error('Error saving user-entry:', error);
      }
    );
  }

  ngOnInit(): void {
    this.GetUser();
  }

  GetUser() {
    this.http.get<User[]>('/api/user').subscribe(
      (result) => {
        this.uservalue = result;
      },
      (error) => {
        console.error('Error fetching entries:', error);
      }
    );
  }
}
