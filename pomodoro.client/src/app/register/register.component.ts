import { Component, OnInit } from '@angular/core';
import { User } from '../../models/User';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css'] // corrected styleUrl to styleUrls
})
export class RegisterComponent implements OnInit {
  public uservalue: User[] = [];
  public newUser: User = {
    id: 0,
    username: '',
    password: ''
  };

  constructor(private http: HttpClient, private router: Router) { } // Inject Router here

  SaveUser() {
    this.http.post<User>('/api/user', this.newUser).subscribe(
      (result) => {
        console.log('saved successfully:', result);
        this.newUser.username = '';
        this.newUser.password = '';
        this.router.navigate(['/app-time-tracker']);
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
