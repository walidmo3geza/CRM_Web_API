import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { OrdersHeader } from '../_models/orders-header';

@Injectable({
  providedIn: 'root'
})
export class OrdersServiceService {

  constructor(public http:HttpClient) { }
  baseUrl:string = "https://localhost:7246/api/SalesOrderHeaders/";

  grtAllOrders(){
    return this.http.get<OrdersHeader[]>(this.baseUrl);
  }

  grtOrderById(id:number){
    return this.http.get<OrdersHeader>(this.baseUrl + id);
  }

  addOrder(order:OrdersHeader){
    return this.http.post(this.baseUrl, order);
  }
  updateOrder(Order:OrdersHeader){
    console.log("from service");
    console.log(Order);
    return this.http.put<OrdersHeader>(this.baseUrl + Order.id, Order);
  }
}
