import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

interface Entry {
  id: number;
  devname: string;
  date: Date;
  startingtime: string;
  endingtime: string;
  comment: string;
}

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
    comment: ''
  };

  constructor(private http: HttpClient) { }

  saveDevEntry() {
    this.http.post<Entry>('/pomodoro', this.record).subscribe(
      (result) => {
        console.log('saved successfully:', result);
        this.record = {
          id: 0,
          devname: '',
          date: new Date(),
          startingtime: '',
          endingtime: '',
          comment: ''
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
    this.http.get<Entry[]>('/pomodoro').subscribe(
      (result) => {
        this.userentry = result;
      },
      (error) => {
        console.error('Error fetching entries:', error);
      }
    );
  }

  deleteEntry(id: number): void {
    this.http.delete(`/pomodoro/${id}`).subscribe(
      () => {
        console.log('Deleted successfully');
        this.getAllEntries(); 
      },
      (error) => {
        console.error('Error deleting entry:', error);
      }
    );
  }

  title = 'entry.client';
}


