import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { OrderHistoryService } from '../order-history/order-history.service';

@Component({
  selector: 'app-new-order',
  templateUrl: './new-order.component.html',
  styleUrls: ['./new-order.component.scss']
})
export class NewOrderComponent implements OnInit {
  formOrder!: FormGroup;
  orders = [];
  displayedColumns = ['id', 'date', 'iddeliverycompany'];

  constructor(private listService: OrderHistoryService, private fb: FormBuilder) { }

  ngOnInit(): void {
    this.formOrder = this.fb.group({
      dateFrom: '',
      dateTo: ''
    });

  }

  onSubmit() {
    let value = this.formOrder.value;

    this.listService.getAllHistoryOrders(value.dateFrom, value.dateTo).subscribe(x => {
      this.orders = x;
    })
  }
}
