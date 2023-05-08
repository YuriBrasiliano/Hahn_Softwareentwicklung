import {Injectable } from "@angular/core";
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { TokenApiModel } from "../models/token-api.model";


@Injectable(
    {
        providedIn: "root"
    }
)

export class AuthService
{
    
  private baseUrl: string = 'https://localhost:7174/users';

    constructor(private http: HttpClient, private router: Router){}

    SignUpUser(obj:any)
    {
        return this.http.post<any>("https://localhost:7174/auth/register", obj);
        
    }

    LoginUser(obj:any)
    {
        return this.http.post<any>("https://localhost:7174/auth/login", obj);
        
    }
      signOut(){
        localStorage.clear();
        this.router.navigate(['login'])
      }
    
      storeToken(tokenValue: string){
        localStorage.setItem('token', tokenValue)
      }
      storeIdUser(idValue: string){
        localStorage.setItem('id', idValue)
      }
      storeRefreshToken(tokenValue: string){
        localStorage.setItem('refreshToken', tokenValue)
      }
    
      getToken(){
        return localStorage.getItem('token')
      }
      getRefreshToken(){
        return localStorage.getItem('refreshToken')
      }
    
      isLoggedIn(): boolean{
        return !!localStorage.getItem('token')
      }
      renewToken(tokenApi : TokenApiModel){
        return this.http.post<any>(`${this.baseUrl}refresh`, tokenApi)
      }
}