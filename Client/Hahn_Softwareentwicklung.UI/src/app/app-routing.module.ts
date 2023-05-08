import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthComponent } from './components/auth/auth.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { AuthGuard } from './guards/auth.guard';

const routes: Routes = [
  {
    path: "",
    pathMatch: "full",
    redirectTo:"login"
  },
  {
    path: "login", component: AuthComponent
  },

  {
    path: "dashboard",
    pathMatch: "full",
    component: DashboardComponent,
    canActivate:[AuthGuard]
  }];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
