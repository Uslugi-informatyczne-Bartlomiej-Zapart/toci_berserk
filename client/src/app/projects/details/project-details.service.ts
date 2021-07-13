import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ProjectDetailsService {

  constructor(private http: HttpClient) { }

  getDetails(id: number) {
    console.log(id);
    return this.http.get(`http://localhost:44391/api/project/${id}`);
  }
}
