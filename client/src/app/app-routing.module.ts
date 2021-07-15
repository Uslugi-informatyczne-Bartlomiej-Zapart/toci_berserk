import { OrdersComponent } from './orders/orders.component';
//import { ProductsListService } from './products/products-list-service';

import { RegisterGuardGuard } from './Auth/register-guard.guard';
import LoginGuardGuard from './Auth/login-guard.guard';
import { RegisterComponent } from './register/register.component';
import { SidenavComponent } from './sidenav/sidenav.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { ProductsComponent } from './products/products.component';


const routes: Routes = [
  {
    path: 'login', component: LoginComponent//, canActivate: [LoginGuardGuard]
  },
  {
    path: 'register', component: RegisterComponent//, canActivate: [RegisterGuardGuard]
  },
  {
    path: '', component: SidenavComponent,
    children: [
      { path: 'products', component: ProductsComponent },
      { path: 'orders', component: OrdersComponent }
    ]
  },

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
