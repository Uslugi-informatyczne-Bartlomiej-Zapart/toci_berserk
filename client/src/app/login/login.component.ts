import { Router } from '@angular/router';
import { LoginService } from './login.service';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  form!: FormGroup;

  constructor(private fb: FormBuilder, private LoginService: LoginService, private router: Router) { }

  ngOnInit(): void {
    this.form = this.fb.group({
      login: '',
      password: ''
    });
  }

  onSubmit() {
    let value = this.form.value;
    this.LoginService.login(value).subscribe(x => {
      console.log(x);
      if(x === true) {
        this.router.navigate(['/']);
      } else {
        this.form.get('password')?.setValue('');
      }
    })
  }
}
