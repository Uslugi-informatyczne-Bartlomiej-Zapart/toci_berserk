import { GuardService } from './../Auth/guard.service';
import { Router } from '@angular/router';
import { RegisterService } from './register.service';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {

  form!: FormGroup;

  constructor(private fb: FormBuilder,
    private guardService: GuardService,
    private RegisterService: RegisterService,
    private router: Router) { }

  ngOnInit(): void {
    this.form = this.fb.group({
      companyName: '',
      ownerSurname: '',
      login: '',
      password: ''
    });
  }

  onSubmit(data:any) {
    this.RegisterService.register(data.companyName, data.ownerSurname, data.login, data.password).subscribe(() => {
      this.guardService.getUser().subscribe(x => {
        localStorage.setItem('user', x.name);
        console.log(x);
        this.router.navigate(['/login']);
        });
    });
  }

}
