import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { OrderHistoryService } from './order-history.service';

@Component({
  selector: 'app-order-history',
  templateUrl: './order-history.component.html',
  styleUrls: ['./order-history.component.scss']
})

export class OrderHistoryComponent implements OnInit {
  // dateFrom!: Date;
  // dateTo!: Date;
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
