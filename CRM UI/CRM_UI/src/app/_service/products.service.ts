import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { Product } from '../_models/product';

@Injectable({
  providedIn: 'root'
})
export class ProductsService {

  constructor(public http:HttpClient) { }
  baseUrl:string = "https://localhost:7246/api/Products/";

  grtAllProducts(){
    return this.http.get<Product[]>(this.baseUrl);
  }

  grtProductById(id:string){
    return this.http.get<Product>(this.baseUrl + id);
  }

  addProduct(prod:Product){
    return this.http.post(this.baseUrl, prod);
  }
  updateProduct(prod:Product){
    console.log("from service");
    console.log(prod);
    return this.http.put<Product>(this.baseUrl + prod.id, prod);
  }
}
