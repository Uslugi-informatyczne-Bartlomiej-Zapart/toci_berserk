import { ProjectListService } from './project-list.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.scss']
})
export class ListComponent implements OnInit {
  projects = [];
  displayedColumns = ['number', 'name', 'deadline'];

  constructor(private listService: ProjectListService) { }

  ngOnInit(): void {
    this.listService.getAllProjects().subscribe(x => {
      this.projects = x;
    })
  }

}
