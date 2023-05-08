import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { LoginModel } from 'src/app/models/LoginModel';
import { SignUpModel } from 'src/app/models/SignUpMode';
import { NgToastService } from 'ng-angular-popup';
import { AuthService } from 'src/app/services/auth.service';


@Component({
  selector: 'app-auth',
  templateUrl: './auth.component.html',
  styleUrls: ['./auth.component.scss']
})
export class AuthComponent implements OnInit {

  
  loginForm!: FormGroup;
  singupForm!: FormGroup;

  constructor(private formBuilder: FormBuilder, private toast: NgToastService, private router: Router, public authService : AuthService){}

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
      this.authService.LoginUser(dataLogin).subscribe(res => 
        {
          this.singupForm.reset();
          this.authService.storeToken(res.token);
          this.authService.storeIdUser(res.id);
          this.toast.success({detail:"SUCCESS", summary:"Welcome " + res.firstName + " " + res.lastName, duration: 5000});
          this.router.navigate(['dashboard'])
      }, error => {
        this.toast.error({detail:"ERROR", summary:"Something when wrong!", duration: 5000});
      })
    }


    submitSignUp()
    {
      var dataSignUp = this.singupForm.getRawValue() as SignUpModel;
      this.authService.SignUpUser(dataSignUp).subscribe(res => 
        {
          this.singupForm.reset();
          this.authService.storeToken(res.token);
          this.authService.storeIdUser(res.id);
          this.toast.success({detail:"SUCCESS", summary:"Welcome "+ res.firstName + " " + res.lastName, duration: 5000});
          this.router.navigate(['dashboard'])
        
      }, error => {
        this.toast.error({detail:"ERROR", summary:"Something when wrong!", duration: 5000});
      });
    }
  }

