import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AddTaskService {

  constructor(private http: HttpClient, private router: Router){}

  AddTask(obj:any)
  {
      return this.http.post<any>("https://localhost:7174/jobs", obj);
      
  }
}
