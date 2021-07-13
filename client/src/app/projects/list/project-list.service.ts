import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ProjectListService {

  constructor(private http: HttpClient) { }

  getAllProjects(): Observable<any> {
    return this.http.get('http://localhost:44391/api/project');
  }
}
