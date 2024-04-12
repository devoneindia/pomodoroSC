import { Component, OnInit } from '@angular/core';
import { User } from '../../models/User';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { Entry } from '../../models/Entry';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css'] // corrected styleUrl to styleUrls
})
export class RegisterComponent implements OnInit {
  public uservalue: User[] = [];
  public existingEntry: Entry[]=[];
  public newUser: User = {
      userId: 0,
      userName: '',
      password: '',
      entries: this.existingEntry
  };

  constructor(private http: HttpClient, private router : Router) { }

  SaveUser() {
    this.http.post<User>('/api/user', this.newUser).subscribe(
      (result) => {
        console.log('saved successfully:', result);
        this.newUser.userName = '';
        this.newUser.password = '';
        this.GetUser();
        this.router.navigate(['/track-time']);
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
