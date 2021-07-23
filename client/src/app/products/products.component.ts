import { Component, OnInit } from '@angular/core';
import { ProductsListService } from './products-list-service';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.scss']
})
export class ProductsComponent implements OnInit {
  products = [];
  displayedColumns = ['idproduct', 'name', 'manufacturer', 'code', 'price', 'deliveryCompany'];

  constructor(private listService: ProductsListService) { }

  ngOnInit(): void {
    this.listService.getAllProjects().subscribe(x => {
      this.products = x;
    })
  }
}
