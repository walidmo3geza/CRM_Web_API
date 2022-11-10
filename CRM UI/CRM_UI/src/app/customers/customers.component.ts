import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Customer } from '../_models/customer';
import { CustomersService } from '../_service/customers.service';

@Component({
  selector: 'app-customers',
  templateUrl: './customers.component.html',
  styleUrls: ['./customers.component.css']
})
export class CustomersComponent implements OnInit {

  constructor(public customerSer:CustomersService, public router:Router) { }

  customers:Customer[] = [];

  ngOnInit(): void {
    this.customerSer.grtAllCustomers().subscribe(a => {
      this.customers = a;
    });
  }

}
