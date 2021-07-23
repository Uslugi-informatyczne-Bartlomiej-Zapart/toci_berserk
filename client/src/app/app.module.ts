import { HttpClient, HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatListModule } from '@angular/material/list';
import { MatGridListModule } from '@angular/material/grid-list';
import { MatTableModule } from '@angular/material/table';
import { MatCheckboxModule } from '@angular/material/checkbox';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { SidenavComponent } from './sidenav/sidenav.component';
import { RegisterComponent } from './register/register.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { OrdersComponent } from './order/orders/orders.component';
import { ProductsComponent } from './products/products.component';
import { MatExpansionModule } from '@angular/material/expansion';
import { MatSelectModule } from '@angular/material/select';
import { OrderHistoryComponent } from './order/order-history/order-history.component';
import { NewOrderComponent } from './order/new-order/new-order.component';
import { NewOrderByCompanyComponent } from './order/new-order-by-company/new-order-by-company.component';
import { AddNewProductComponent } from './products/add-new-product/add-new-product.component';


@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    SidenavComponent,
    RegisterComponent,
    OrdersComponent,
    ProductsComponent,
    OrderHistoryComponent,
    NewOrderComponent,
    NewOrderByCompanyComponent,
    AddNewProductComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatCardModule,
    MatButtonModule,
    MatListModule,
    MatFormFieldModule,
    MatInputModule,
    MatSidenavModule,
    MatListModule,
    MatGridListModule,
    MatTableModule,
    MatExpansionModule,
    MatSelectModule,
    MatCheckboxModule
  ],
  exports: [
    MatButtonModule,
    MatFormFieldModule,
    MatInputModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
