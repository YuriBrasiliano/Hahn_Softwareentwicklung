import {Injectable } from "@angular/core";
import { HttpClient } from '@angular/common/http';


@Injectable(
    {
        providedIn: "root"
    }
)

export class SignUpService
{

    constructor(private http: HttpClient){}

    SignUpUser(obj:any)
    {
        return this.http.post<any>("https://localhost:7174/auth/register", obj);
        
    }
}