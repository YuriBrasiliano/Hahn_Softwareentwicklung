import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { LoginModel } from 'src/app/models/LoginModel';
import { SignUpModel } from 'src/app/models/SignUpMode';
import { SignUpService } from 'src/app/service/SignUp.service';
import { LoginService } from 'src/app/service/login.service';

@Component({
  selector: 'app-auth',
  templateUrl: './auth.component.html',
  styleUrls: ['./auth.component.scss']
})
export class AuthComponent implements OnInit {

  
  loginForm!: FormGroup;
  singupForm!: FormGroup;

  constructor(private formBuilder: FormBuilder, private router: Router, public loginService : LoginService, public signUpService : SignUpService){}

    ngOnInit(): void {
        this.loginForm = this.formBuilder.group(
          {
            email: ['', [Validators.required, Validators.email]],
            password: ['', [Validators.required]],
          }
        ),
        this.singupForm = this.formBuilder.group(
          {
            firstName: ['', [Validators.required]],
            lastName: ['', [Validators.required]],
            email: ['', [Validators.required, Validators.email]],
            password: ['', [Validators.required]],
          }
        )
    }

    submitLogin()
    {
      var dataLogin = this.loginForm.getRawValue() as LoginModel;
      this.loginService.LoginUser(dataLogin).subscribe(token => 
        {
        alert(token.getRawValue);
      })
    }
    submitSignUp()
    {
      var dataSignUp = this.singupForm.getRawValue() as SignUpModel;
      this.signUpService.SignUpUser(dataSignUp).subscribe(token => 
        {
        alert(token.getRawValue);
      })
    }
    }

