import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Customer } from '../_models/customer';
import { CustomerAddress } from '../_models/customer-address';
import { CustomerAddressesService } from '../_service/customer-addresses.service';
import { CustomersService } from '../_service/customers.service';

@Component({
  selector: 'app-customer-address',
  templateUrl: './customer-address.component.html',
  styleUrls: ['./customer-address.component.css']
})
export class CustomerAddressComponent implements OnInit {

  constructor(public customerAddressSer:CustomerAddressesService, public router:Router, public ar:ActivatedRoute, public customerSer:CustomersService) { 

  }

  customerAddress:CustomerAddress[] = [];

  customer:Customer = new Customer(0, "00000000-0000-0000-0000-000000000000", "", "", "", "", this.customerAddress);
  customerId:string = "";

  ngOnInit(): void {
    this.ar.params.subscribe(i => {
      this.customerId = i['id'];
      this.customerSer.grtCustomerById(this.customerId).subscribe(a => {
        this.customer = a;
      })
    })
    
  }

}
