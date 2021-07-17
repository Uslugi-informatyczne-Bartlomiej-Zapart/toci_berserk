import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { NewOrdersService } from './new-order.service';

@Component({
  selector: 'app-new-order',
  templateUrl: './new-order.component.html',
  styleUrls: ['./new-order.component.scss']
})
export class NewOrderComponent implements OnInit {
  formOrder!: FormGroup;
  orders = [];
  displayedColumns = ['productId', 'productName', 'currentQuantity', 'expectedOrderQuantity', 'deliveryCompany', 'price'];

  constructor(private listService: NewOrdersService, private fb: FormBuilder) { }

  ngOnInit(): void {
    this.listService.getNewProductsOrder().subscribe(x => {
      //console.log(x);
      this.orders = x;
    });

    this.formOrder = this.fb.group({});
    //   productId: '',
    //   productName: '',
    //   currentQuantity: '',
    //   expectedOrderQuantity: '',
    //   deliveryCompany: ''
    // });
  }

  onSubmit() {
    console.log("asd");
    let value = this.formOrder.controls;
    console.log(value);
    // this.listService.getAllValuesFromOrderForm(value).subscribe(x => {
    //   this.orders = x;
    // });

  }
}
