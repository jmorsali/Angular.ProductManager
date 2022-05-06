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
  showForm: boolean = false;
  _http: HttpClient;
  _baseUrl: string;


  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {

    this._http = http;
    this._baseUrl = baseUrl;
    this.products = [];

  }

  ngOnInit(): void {
    this.fillDataGrid();

  }

  fillDataGrid(): void {

    this._http.get<Product[]>(this._baseUrl + 'Product/Products')
      .subscribe(result => { this.products = result; }, error => console.error(error));

    this.showForm = false;
    this.selectedProduct = undefined;
  }

  add() {
    this.showForm = true;
    this.selectedProduct = new Product();
  }

  showProduct(productId?: number): void {
    this.showForm = true;
    this.selectedProduct = this.products.filter(x => x.id === productId)[0];

  }



  saveForm(name: string, price: string) {

    var actinUtl: string;
    var isNew:boolean;
    if (this.selectedProduct?.id == undefined) {
      actinUtl = 'Product/AddProduct';
      isNew = true;
    } else {
      actinUtl = 'Product/UpdateProduct';
      isNew = false;
    }

    this._http.post<Product>(this._baseUrl + actinUtl,
      { id: this.selectedProduct?.id, name: name, price: price })
      .subscribe(result => {
        this.showForm = false;
        this.selectedProduct = undefined;
        if (isNew) {
          this.products.push(result);
        } else {
          let index: number = this.products.findIndex(x => x.id === result.id);
          this.products[index] = result;
        }
      },
        error => console.error(error));
  }

  cancelEditForm() {
    this.showForm = false;
    this.selectedProduct = undefined;
  }
}
