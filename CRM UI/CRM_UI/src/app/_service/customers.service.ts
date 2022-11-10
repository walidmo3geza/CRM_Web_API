import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Customer } from '../_models/customer';

@Injectable({
  providedIn: 'root'
})
export class CustomersService {

  constructor(public http:HttpClient) { }
  baseUrl:string = "https://localhost:7246/api/Customers/";

  grtAllCustomers(){
    return this.http.get<Customer[]>(this.baseUrl);
  }

  grtCustomerById(id:number){
    return this.http.get<Customer>(this.baseUrl + id);
  }

  addCustomer(customer:Customer){
    return this.http.post(this.baseUrl, customer);
  }
  updateCustomer(customer:Customer){
    console.log("from service");
    console.log(customer);
    return this.http.put<Customer>(this.baseUrl + customer.id, customer);
  }
  
}
