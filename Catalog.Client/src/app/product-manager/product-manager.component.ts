import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Product } from '../models/product.model';

@Component({
  selector: 'app-product-manager',
  templateUrl: './product-manager.component.html',
  styleUrls: ['./product-manager.component.scss']
})
export class ProductManagerComponent implements OnInit {

  products: Product[];
  selectedProduct?: Product;
  showForm: boolean;

  constructor(http: HttpClient,@Inject('BASE_URL') baseUrl: string) {

    this.products = [];
    http.get<Product[]>(baseUrl.replace("4200","5000").replace("http","https") + 'Product/Products')
      .subscribe(result => { this.products = result; }, error => console.error(error));
    console.log("===>"+baseUrl);
   
    this.showForm = false;
    this.selectedProduct = new Product();
  }

  ngOnInit(): void {
  }

  add() {
    this.showForm = true;
    this.selectedProduct = new Product();
  }

  showProduct(productId?: number): void {
    this.showForm = true;
    this.selectedProduct = this.products.filter(x => x.id == productId)[0];

  }
  saveForm() {
    this.showForm = false;

    this.selectedProduct = undefined;
  }

  cancelEditForm() {
    this.showForm = false;
    this.selectedProduct = undefined;
  }
}
