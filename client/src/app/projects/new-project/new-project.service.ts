import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class NewProjectService {

  constructor(private http: HttpClient) { }

  createProject(name: string, description: string, deadline: string): Observable<number> {
    return this.http.post<number>('http://localhost:44391/api/project',
    {name: name, description: description, deadline: deadline});
  }
}
