import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { TaskListItem } from './task-list-item';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TaskListService {

  constructor(private http: HttpClient) { }

  getTasks(id: number): Observable<TaskListItem[]> {
    return this.http.get<TaskListItem[]>(`http://localhost:44391/api/project/${id}/task`);
  }

  newTask(title: any, description: any, date: any, id: undefined): Observable<any> {
    return this.http.post<any>(`http://localhost:44391/api/project/${id}/task`, {title: title, description: description, date: date});
  }
}
