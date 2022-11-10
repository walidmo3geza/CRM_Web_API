import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { CustomerAddress } from '../_models/customer-address';

@Injectable({
  providedIn: 'root'
})
export class CustomerAddressesService {

  constructor(public http:HttpClient) { }
  baseUrl:string = "https://localhost:7246/api/CustomerAddresses/";

  grtAllAddress(){
    return this.http.get<CustomerAddress[]>(this.baseUrl);
  }

  grtAddressById(id:number){
    return this.http.get<CustomerAddress>(this.baseUrl + id);
  }

  addAddress(address:CustomerAddress){
    return this.http.post(this.baseUrl, address);
  }
}
