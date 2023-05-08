import { Component } from '@angular/core';
import { ApiService } from 'src/app/services/api.service';
import { AuthService } from 'src/app/services/auth.service';


@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent {

  public userJobs:any = [];
  constructor(private auth: AuthService, private api : ApiService) { }

  ngOnInit(){
    const UserId = localStorage.getItem("id");
    if (UserId != null) {
    this.api.getUserTasks(UserId).subscribe(res => {this.userJobs = res;})
  }}
  
  logout(){
    this.auth.signOut();
  }
 
}
