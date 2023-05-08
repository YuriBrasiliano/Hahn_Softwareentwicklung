import { Component } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { NgToastService } from 'ng-angular-popup';
import { TaskModel } from 'src/app/models/TaskModel';
import { AddTaskService } from 'src/app/services/add-task.service';

@Component({
  selector: 'app-add-task',
  templateUrl: './add-task.component.html',
  styleUrls: ['./add-task.component.scss']
})
export class AddTaskComponent {

  addTaskRequest: TaskModel;
  addTaskForm!: FormGroup;

  constructor(
    private formBuilder: FormBuilder,
    private toast: NgToastService,
    private router: Router,
    public addTaskService: AddTaskService
  ){
    this.addTaskRequest = {
      name: '',
      userId: localStorage.getItem("id") || '',
      description: '',
      taskLocation: '',
      taskLink: '',
      taskGroup: '',
      taskDateTime: '',
    };
  }

  ngOnInit(): void {
   
  }

  addTask() {
    this.addTaskService.AddTask(this.addTaskRequest).subscribe({
      next: (task) => {
        this.toast.success({detail:"SUCCESS", summary:"Task Created!", duration: 5000});
          this.router.navigate(['dashboard'])
      }
    });
  }
}
