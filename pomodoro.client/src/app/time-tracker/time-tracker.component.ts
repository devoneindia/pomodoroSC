import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Entry } from '../../models/Entry';


@Component({
  selector: 'app-time-tracker',
  templateUrl: './time-tracker.component.html',
  styleUrls: ['./time-tracker.component.css']
})
export class TimeTrackerComponent implements OnInit {
  public userentry : Entry[]=[] 
  public record: Entry = {
    id: 0,
    devname: '',
    date: new Date(),
    startingtime: '',
    endingtime: '',
    comment: '',
    totaltime: ''
  };

  timer: any;
  timerStarted: boolean = false;
  startTime!: Date;
  currentTime!: string;

  constructor(private http: HttpClient) { }

  saveDevEntry() {
    this.http.post<Entry>('/api/pomodoro', this.record).subscribe(
      (result) => {
        console.log('saved successfully:', result);
        this.record = {
          id: 0,
          devname: '',
          date: new Date(),
          startingtime: '',
          endingtime: '',
          comment: '',
          totaltime: ''
        };
        this.getAllEntries(); 
      },
      (error) => {
        console.error('Error saving dev-entry:', error);
      }
    );
  }

    ngOnInit(): void {
    this.getAllEntries();
  }

  getAllEntries() {
    this.http.get<Entry[]>('/api/pomodoro').subscribe(
      (result) => {
        this.userentry = result;
      },
      (error) => {
        console.error('Error fetching entries:', error);
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
    }, 1000); // Update every second
  }
  stopTimer() {
    clearInterval(this.timer);
    this.timerStarted = false;
    const endTime = new Date();
    const totalTime = this.calculateTotalTime(this.startTime, endTime);
    this.record.endingtime = endTime.toTimeString().slice(0, 8);
    this.record.totaltime = totalTime;
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


