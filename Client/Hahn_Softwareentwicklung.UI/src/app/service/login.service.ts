import {Injectable } from "@angular/core";
import { HttpClient } from '@angular/common/http';


@Injectable(
    {
        providedIn: "root"
    }
)

export class LoginService
{

    constructor(private http: HttpClient){}

    LoginUser(obj:any)
    {
        return this.http.post<any>("https://localhost:7174/auth/login", obj);
        
    }
}