import { RegisterGuardGuard } from './Auth/register-guard.guard';
import { RegisterComponent } from './register/register.component';
import { SidenavComponent } from './sidenav/sidenav.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes, CanActivate } from '@angular/router';
import { LoginComponent } from './login/login.component';
import LoginGuardGuard from './Auth/login-guard.guard';

const routes: Routes = [
  {
    path: 'login', component: LoginComponent, canActivate: [LoginGuardGuard]
  },
  {
    path: 'register', component: RegisterComponent, canActivate: [RegisterGuardGuard]
  },
  {
    path: '', component: SidenavComponent,
    children: [
    ]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
