import { OrdersComponent } from './order/orders/orders.component';
//import { ProductsListService } from './products/products-list-service';

import { RegisterGuardGuard } from './Auth/register-guard.guard';
import LoginGuardGuard from './Auth/login-guard.guard';
import { RegisterComponent } from './register/register.component';
import { SidenavComponent } from './sidenav/sidenav.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { ProductsComponent } from './products/products.component';
import { OrderHistoryComponent } from './order/order-history/order-history.component';
import { NewOrderComponent } from './order/new-order/new-order.component';
import { NewOrderByCompanyComponent } from './order/new-order-by-company/new-order-by-company.component';


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
      { path: 'orders', component: OrdersComponent },
      { path: 'orders-history', component: OrderHistoryComponent },
      { path: 'new-order', component: NewOrderComponent },
      { path: 'new-order-by-company', component: NewOrderByCompanyComponent }
    ]
  },

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
