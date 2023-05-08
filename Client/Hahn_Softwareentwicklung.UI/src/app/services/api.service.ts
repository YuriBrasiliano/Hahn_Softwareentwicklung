import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { TaskModel } from '../models/TaskModel';

@Injectable({
  providedIn: 'root',
})
export class ApiService {
  private baseUrl: string = 'https://localhost:7174/jobs/usertasks/';
  private baseUrlGetTask: string = 'https://localhost:7174/jobs/';
  constructor(private http: HttpClient) {}
  
  getUserTasks(UserId: string) {
    return this.http.get<any>(this.baseUrl + UserId);
  }

  getTask(id : string): Observable<TaskModel>{
    return this.http.get<TaskModel>(this.baseUrlGetTask + id);
  }

  updateTask(id : string, updateTaskRequest : TaskModel): Observable<TaskModel>{

    return this.http.put<TaskModel>(this.baseUrlGetTask + id, updateTaskRequest);
    
  }
  DeleteTask(id : string): Observable<TaskModel>{

    return this.http.delete<TaskModel>(this.baseUrlGetTask + id);
    
  }
  
}