import { ListComponent } from './projects/list/list.component';
import { DetailsComponent } from './projects/details/details.component';
import { ProjectDetailsService } from './projects/details/project-details.service';
import { NewProjectComponent } from './projects/new-project/new-project.component';
import { RegisterGuardGuard } from './Auth/register-guard.guard';
import { RegisterComponent } from './register/register.component';
import { SidenavComponent } from './sidenav/sidenav.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes, CanActivate } from '@angular/router';
import { DashboardComponent } from './dashboard/dashboard.component';
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
      // { path: 'dashboard', component: DashboardComponent },
      // { path: 'new-project', component: NewProjectComponent },
      // { path: 'projects', component: ListComponent },
      // { path: 'project/:id', component: DetailsComponent}
    ]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
