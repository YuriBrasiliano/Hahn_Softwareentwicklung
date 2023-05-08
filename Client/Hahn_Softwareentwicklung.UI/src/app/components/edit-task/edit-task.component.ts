import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { TaskModel } from 'src/app/models/TaskModel';
import { ApiService } from 'src/app/services/api.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-edit-task',
  templateUrl: './edit-task.component.html',
  styleUrls: ['./edit-task.component.scss']
})
export class EditTaskComponent implements OnInit {

    TaskDetails: TaskModel;
    
  
  
  constructor(private route:ActivatedRoute, private router: Router, private apiService : ApiService){
    this.TaskDetails = {
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
    this.TaskDetails = {
      name: '',
      userId: localStorage.getItem("id") || '',
      description: '',
      taskLocation: '',
      taskLink: '',
      taskGroup: '',
      taskDateTime: '',
    };

    this.route.paramMap.subscribe({
      next: (params) => {
        const id = params.get('id');

        if (id) {
          this.apiService.getTask(id).subscribe({
            next: (response) => {
              this.TaskDetails = response;
              localStorage.setItem("idTask", id)
            }
          });
        }
      }
    });
  }

  DeleteTask(){
    const idTask = localStorage.getItem("idTask");
    const idTaskString = idTask ? idTask.toString() : '';
    this.apiService.DeleteTask(idTaskString)
    .subscribe({
      next:() => {

        this.router.navigate(['dashboard'])
  }})
}

  updateTask(){
    const idTask = localStorage.getItem("idTask");
    const idTaskString = idTask ? idTask.toString() : '';
    this.apiService.updateTask(idTaskString, this.TaskDetails)
    .subscribe({
      next:(response) => {
        this.router.navigate(['dashboard'])
      }
    });
}
  }
