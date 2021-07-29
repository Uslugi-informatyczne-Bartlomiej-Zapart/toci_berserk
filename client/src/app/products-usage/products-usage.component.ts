import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ProductsUsageService } from './products-usage.service';

@Component({
  selector: 'app-products-usage',
  templateUrl: './products-usage.component.html',
  styleUrls: ['./products-usage.component.scss']
})
export class ProductsUsageComponent implements OnInit {
  form!: FormGroup;
  products = [];
  constructor(private listService: ProductsUsageService, private fb: FormBuilder) { }

  ngOnInit(): void {
    this.form = this.fb.group({
      idproducts: '',
      quantity: '',
      idusers: ''
    });
  }

  onSubmit(data:any) {
    this.listService.setProductUsage(data.idproducts, data.quantity, data.idusers).subscribe(x => {

    });
  }
}
