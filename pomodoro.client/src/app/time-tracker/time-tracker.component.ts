import { Component, OnInit, isDevMode } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Entry } from '../../models/Entry';
import { User } from '../../models/User';
import { Version } from '../../models/Version';



@Component({
  selector: 'app-time-tracker',
  templateUrl: './time-tracker.component.html',
  styleUrls: ['./time-tracker.component.css']
})
export class TimeTrackerComponent implements OnInit {
  public versionInfo: Version =
    {
      versionName: 'Version - 1.1',
      versionBranch: 'GitHub Branch: users/sc/20240411_Version_Info'
    };
  
  public userTimeLogs: Entry[] = []
  public existingUsers: User[] = []
  public record: Entry = {
    userId:0,
    userName: '',
    date: new Date(),
    startingtime: '',
    endingtime: '',
    comment: '',
    totaltime: '',
    id:0
  };
  
  timer: any;
  timerStarted: boolean = false;
  startTime!: Date;
  currentTime!: string;


  constructor(private http: HttpClient) { }
  getUsernameFromUserId() {
    if (this.existingUsers.length === 0) {
      this.getUser();
      return;
    }

    const selectedUser = this.existingUsers.find(existingUser => existingUser.userId === +this.record.userId);
    if (selectedUser) {
      this.record.userName = selectedUser.userName;
      console.log(`Username for id ${this.record.userId} is ${selectedUser.userName}`);
    } else {
      console.log(`Sorry did not find user for id ${this.record.userId}`);
    }
  }
  getUser() {
    this.http.get<User[]>('/api/user').subscribe(
      (result) => {
        this.existingUsers = result;
      
      },
      (error) => {
        console.error('Error fetching user:', error);
      }
    );
  }
 

  ngOnInit(): void {
    this.getAllEntries();
  }

  getAllEntries() {
    this.http.get<Entry[]>('/api/pomodoro').subscribe(
      (result) => {
        //this.record=
        //  {
        //    userId: 0,
        //    name: '',
        //    date: new Date(),
        //    startingtime: '',
        //    endingtime: '',
        //    comment: '',
        //    totaltime: ''
        //  };
        this.userTimeLogs = result;
        this.getUser();
      },
      (error) => {
        console.error('Error fetching entries:', error);
      }
    );
  }

  saveDevEntry() {
    this.http.post<Entry>('/api/pomodoro', this.record).subscribe(
      (result) => {
        console.log('saved successfully:', result);
        this.userTimeLogs.push(result);
        this.getAllEntries(); 
      },
      (error) => {
        console.error('Error saving dev-entry:', error);
      }
    );
  }

  deleteEntry(id: number): void {
    this.http.delete(`/api/pomodoro/${id}`).subscribe(
      () => {
        console.log('Deleted successfully');
        this.getAllEntries();
      },
      (error) => {
        console.error('Error deleting entry:', error);
      }
    );
  }

  startTimer() {
    this.record.startingtime = new Date().toTimeString().slice(0, 8);
    this.startTime = new Date();
    this.timerStarted = true;
    this.timer = setInterval(() => {
      const currentTime = new Date();
      this.currentTime = currentTime.toTimeString().slice(0, 8);
    }, 1000); 
  }
  stopTimer() {
    clearInterval(this.timer);
    this.timerStarted = false;
    const endTime = new Date();
    const totalTime = this.calculateTotalTime(this.startTime, endTime);
    this.record.endingtime = endTime.toTimeString().slice(0, 8);
    this.record.totaltime = totalTime;
    this.getUsernameFromUserId();
    this.saveDevEntry();
  }
  calculateTotalTime(startTime: Date, endTime: Date): string {
    const totalTimeInSeconds = Math.floor((endTime.getTime() - startTime.getTime()) / 1000);
    const hours = Math.floor(totalTimeInSeconds / 3600);
    const minutes = Math.floor((totalTimeInSeconds % 3600) / 60);
    const seconds = totalTimeInSeconds % 60;
    return `${hours}:${minutes}:${seconds}`;
  }

  title = 'entry.client';
}


