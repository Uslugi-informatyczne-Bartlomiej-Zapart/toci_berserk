import { Router } from '@angular/router';
import { NewProjectService } from './new-project.service';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-new-project',
  templateUrl: './new-project.component.html',
  styleUrls: ['./new-project.component.scss']
})
export class NewProjectComponent implements OnInit {
  form!: FormGroup;

  constructor(private fb: FormBuilder, private NewProjectService: NewProjectService, private router: Router) { }

  ngOnInit(): void {
    this.form = this.fb.group({
      name: '',
      description: '',
      deadline: ''
    })
  }

  onSubmit(data: any) {
    this.NewProjectService.createProject(data.name, data.description, data.deadline)
      .subscribe( x => {
        this.router.navigate(['project', x]);
      });
  }
}
