import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { NewOrdersService } from './new-order.service';

interface LooseObject {
  [key: string]: any
}

@Component({
  selector: 'app-new-order',
  templateUrl: './new-order.component.html',
  styleUrls: ['./new-order.component.scss']
})
export class NewOrderComponent implements OnInit {
  
  arr: any = [];
  dict = [];
  formOrder!: FormGroup;
  orders = [];
  displayedColumns = ['productId', 'productName', 'currentQuantity', 'expectedOrderQuantity', 'deliveryCompany', 'price'];
  json: LooseObject = {};
  constructor(private listService: NewOrdersService, private fb: FormBuilder) { }

  ngOnInit(): void {
    this.listService.getNewProductsOrder().subscribe(x => {

      this.orders = x;

      for (let i = 0; i < this.orders.length; i++)
      {
        this.dict.push(this.orders[i]['productId']);
        this.json['expectedQuantity' + this.orders[i]['productId']] = new FormControl(this.orders[i]['expectedOrderQuantity']);
      }

      this.formOrder = this.fb.group(this.json);
    });
  }

  onSubmit() {
    let controls = this.formOrder.value;

    for (let key in this.dict) {
      let value = this.dict[key];

      let q = {productId: value, expectedOrderQuantity: controls['expectedQuantity'+value]};
      this.arr.push(q);
    }

    this.listService.getAllValuesFromOrderForm(this.arr).subscribe(x => {
      this.orders = x;
    });

  }
}
