import { Component, OnInit } from '@angular/core';
import { OrdersListService } from './orders-list-service';

@Component({
  selector: 'app-orders',
  templateUrl: './orders.component.html',
  styleUrls: ['./orders.component.scss']
})
export class OrdersComponent implements OnInit {
  orders = [];
  displayedColumns = ['id', 'date', 'status'];

  constructor(private listService: OrdersListService) { }

  ngOnInit(): void {
    this.listService.getAllOrders().subscribe(x => {
      console.log(x);
      this.orders = x;
    })
  }
}
