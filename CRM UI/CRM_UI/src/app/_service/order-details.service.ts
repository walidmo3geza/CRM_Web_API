import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { OrderDetails } from '../_models/order-details';

@Injectable({
  providedIn: 'root'
})
export class OrderDetailsService {

  constructor(public http:HttpClient) { }
  baseUrl:string = "https://localhost:7246/api/SalesOrderDetails/";

  grtAllOrderDetails(){
    return this.http.get<OrderDetails[]>(this.baseUrl);
  }

  grtOrderDetailsById(id:string){
    return this.http.get<OrderDetails>(this.baseUrl + id);
  }

  addOrderDetails(order:OrderDetails){
    return this.http.post(this.baseUrl, order);
  }
  updateOrderDetails(Order:OrderDetails){
    return this.http.put<OrderDetails>(this.baseUrl + Order.id, Order);
  }
}

 