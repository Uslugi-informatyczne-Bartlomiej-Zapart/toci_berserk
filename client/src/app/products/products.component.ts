import { ProductsListItem } from './products-list-item';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.scss']
})
export class ProductsComponent implements OnInit {

  displayedColumns = ['number', 'title', 'date'];
  products!: ProductsListItem[];

  constructor(private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.update();
  }

  update() {
    let id = this.route.snapshot.params['id'];

  }

}
