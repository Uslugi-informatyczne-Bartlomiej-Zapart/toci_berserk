import { TaskListComponent } from './task-list/task-list.component';
import { TaskListService } from './task-list/task-list.service';
import { NewProjectService } from './../new-project/new-project.service';
import { ProjectDetailsService } from './project-details.service';
import { Component, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { FormBuilder, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-details',
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.scss']
})
export class DetailsComponent implements OnInit {
  form!: FormGroup;
  @ViewChild('taskList', {static: true}) taskList!: TaskListComponent;

  constructor(private route: ActivatedRoute, private projectService: ProjectDetailsService, private taskService: TaskListService, private fb: FormBuilder) { }

  project: any;

  ngOnInit(): void {
    this.form = this.fb.group({
      title: '',
      description: '',
      date: ''
    })
    let id = this.route.snapshot.params['id'];
    console.log(this.route.snapshot.params);
    this.projectService.getDetails(id).subscribe(x => {
      this.project = x;
    });
  }

  onSubmit(data: { title: any; description: any; date: any; }) {
    let id = this.route.snapshot.params['id'];
    this.taskService.newTask(data.title, data.description, data.date, id)
      .subscribe(() => {
        this.taskList?.update();
    });
  }
}
