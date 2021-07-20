import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { MatTableDataSource } from '@angular/material/table';
import { NewOrdersService } from './new-order.service';

interface LooseObject {
  [key: string]: any
}

export interface OrderData {
  productId: Number;
  productName: string;
  currentQuantity: Number;
  expectedOrderQuantity: Number;
  deliveryCompany: string;
  price: Number;
}

export interface SearchData {
  idproducts: Number;
  productName: string;
  currentQuantity: Number;
  expectedOrderQuantity: Number;
  deliveryCompany: string;
  price: Number;
}

@Component({
  selector: 'app-new-order',
  templateUrl: './new-order.component.html',
  styleUrls: ['./new-order.component.scss']
})
export class NewOrderComponent implements OnInit {

  orders: OrderData[] = [];
  products: SearchData[] = [];
  arr: any = [];
  dict:any = [];
  dictSearch:any = [];
  formOrder!: FormGroup;
  formSearch!: FormGroup;
  dataSource: MatTableDataSource<OrderData>;
  displayedOrderColumns = ['productId', 'productName', 'currentQuantity', 'expectedOrderQuantity', 'deliveryCompany', 'price', 'delete'];
  displayedProductColumns = ['add', 'name', 'reference', 'manufacturer', 'code', 'companyName', 'price'];
  jsonOrders: LooseObject = {};
  jsonSearch: LooseObject = {};

  constructor(private listService: NewOrdersService, private fb: FormBuilder) {
    this.dataSource = new MatTableDataSource(this.orders);
  }

  ngOnInit(): void {
    this.listService.getNewProductsOrder().subscribe(orderList => {
      for (let i = 0; i < orderList.length; i++) {
        this.orders.push(this.createNewOrder(orderList[i]));
      }

      this.dataSource = new MatTableDataSource(this.orders);

      for (let i = 0; i < this.orders.length; i++) {
        this.dict.push(this.orders[i]['productId']);
        this.jsonOrders['expectedQuantity' + this.orders[i]['productId']] = new FormControl(this.orders[i]['expectedOrderQuantity']);
      }

      this.formOrder = this.fb.group(this.jsonOrders);
    });
    this.formSearch = this.fb.group({searchQuery: new FormControl()});
  }

  onSearchInput() {
    let values = this.formSearch.value;

    this.listService.searchProduct(values.searchQuery).subscribe(x => {

      this.products = x;
      if (this.products != null) {
        for (let i = 0; i < this.products.length; i++) {
          this.dictSearch.push(this.products[i]['idproducts']);
          this.jsonSearch['expectedQuantity' + this.products[i]['idproducts']] = new FormControl(this.products[i]['expectedOrderQuantity']);
        }
      }

      this.jsonSearch['searchQuery'] = new FormControl(values.searchQuery);
      this.formSearch = this.fb.group(this.jsonSearch);
    });
  }

  onSubmit() {
    let values = this.formOrder.value;

    for (let key in this.dict) {
      let value = this.dict[key];

      let q = {productId: value, expectedOrderQuantity: values['expectedQuantity'+value]};
      this.arr.push(q);
    }

    this.listService.getAllValuesFromOrderForm(this.arr).subscribe(x => {
      this.orders = x;
    });
    console.log(this.orders);
  }

  createNewOrder(json: LooseObject): OrderData {
    return {
      productId: json['productid'],
      productName: json['productname'],
      currentQuantity: json['currentquantity'],
      expectedOrderQuantity: json['expectedOrderQuantity'],
      deliveryCompany: json['deliverycompany'],
      price: json['price']
    };
  }

  addProductToOrder(el: LooseObject) {
    let values = this.formSearch.value;
    el.expectedOrderQuantity = values['expectedQuantity'+el.idproducts];
    this.dataSource.data.push(this.addNewOrderFromSearch(el));
    this.dataSource.filter = "";
  }

  addNewOrderFromSearch(json: LooseObject): OrderData {
    return {
      productId: json['idproducts'],
      productName: json['name'],
      currentQuantity: json['currentQuantity'],
      expectedOrderQuantity: json['expectedOrderQuantity'],
      deliveryCompany: json['companyname'],
      price: json['price']
    };
  }

  deleteProduct(element: LooseObject) {
    let data: OrderData[] = [];

    for(let item in this.dataSource.data) {
      if (element.productId != this.dataSource.data[item].productId) {
        data.push(this.dataSource.data[item]);
      }
    }

    this.dataSource.data = data;
    this.dataSource.filter = "";
  }
}
