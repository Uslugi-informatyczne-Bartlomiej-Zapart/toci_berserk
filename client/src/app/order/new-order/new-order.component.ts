import { Component, OnInit } from '@angular/core';
import { NewOrdersService } from './new-order.service';

@Component({
  selector: 'app-new-order',
  templateUrl: './new-order.component.html',
  styleUrls: ['./new-order.component.scss']
})
export class NewOrderComponent implements OnInit {
  orders = [];
  displayedColumns = ['productId', 'productName', 'currentQuantity', 'expectedOrderQuantity', 'deliveryCompany', 'price'];

  constructor(private listService: NewOrdersService) { }

  ngOnInit(): void {
    this.listService.getNewProductsOrder().subscribe(x => {
      console.log(x);
      this.orders = x;
    })
  }
}
