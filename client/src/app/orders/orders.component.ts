import { Component, OnInit } from '@angular/core';
import { OrdersListService } from './orders-list-service';

@Component({
  selector: 'app-orders',
  templateUrl: './orders.component.html',
  styleUrls: ['./orders.component.scss']
})
export class OrdersComponent implements OnInit {
  orders = [];
  displayedColumns = ['number', 'name', 'date'];

  constructor(private listService: OrdersListService) { }

  ngOnInit(): void {
    this.listService.getAllProjects().subscribe(x => {
      this.orders = x;
    })
  }
}
