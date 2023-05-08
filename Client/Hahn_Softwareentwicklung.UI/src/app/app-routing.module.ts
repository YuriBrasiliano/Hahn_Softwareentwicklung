import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthComponent } from './components/auth/auth.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { AuthGuard } from './guards/auth.guard';
import { AddTaskComponent } from './components/add-task/add-task.component';
import { EditTaskComponent } from './components/edit-task/edit-task.component';

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
  },
  {
    path: "dashboard/addtask",
    pathMatch: "full",
    component: AddTaskComponent,
    canActivate:[AuthGuard]
  },
  {
    path: "dashboard/edittask/:id",
    pathMatch: "full",
    component: EditTaskComponent,
    canActivate:[AuthGuard]
  }


];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
