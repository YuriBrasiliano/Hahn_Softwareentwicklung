import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class ApiService {
  private baseUrl: string = 'https://localhost:7174/jobs/usertasks';
  constructor(private http: HttpClient) {}
  
  getUserTasks(UserId: string) {
    const url = `${this.baseUrl}/${UserId}`;
    return this.http.get<any>(url);
  }
}