import { ActivatedRoute } from '@angular/router';
import { TaskListService } from './task-list.service';
import { Observable } from 'rxjs';
import { Component, OnInit } from '@angular/core';
import { TaskListItem } from './task-list-item';

@Component({
  selector: 'app-task-list',
  templateUrl: './task-list.component.html',
  styleUrls: ['./task-list.component.scss']
})
export class TaskListComponent implements OnInit {

  displayedColumns = ['number', 'title', 'date'];
  tasks!: TaskListItem[];

  constructor(private taskService: TaskListService, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.update();
  }

  update() {
    let id = this.route.snapshot.params['id'];
    this.taskService.getTasks(id).subscribe(list => {
      this.tasks = list;
    })
  }
}
