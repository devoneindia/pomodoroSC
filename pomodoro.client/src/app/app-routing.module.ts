import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RegisterComponent } from './register/register.component';
import { TimeTrackerComponent } from './time-tracker/time-tracker.component';
import { DemoComponent } from './demo/demo.component';


const routes: Routes = [
  { path: '', redirectTo: '/register', pathMatch: 'full' },
  { path: 'demo', component: DemoComponent},
  { path: 'register', component: RegisterComponent },
  { path: 'track-time', component: TimeTrackerComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
