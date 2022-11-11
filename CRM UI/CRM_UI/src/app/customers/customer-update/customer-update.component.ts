import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Customer } from 'src/app/_models/customer';
import { CustomerAddress } from 'src/app/_models/customer-address';
import { CustomersService } from 'src/app/_service/customers.service';

@Component({
  selector: 'app-customer-update',
  templateUrl: './customer-update.component.html',
  styleUrls: ['./customer-update.component.css']
})
export class CustomerUpdateComponent implements OnInit {

  constructor(public customerSer:CustomersService, public ar:ActivatedRoute, public router:Router) { }

  id:string = "";

  customerAddress:CustomerAddress[] = [];

  customer:Customer = new Customer(0, "00000000-0000-0000-0000-000000000000", "", "", "", "", this.customerAddress);

  ngOnInit(): void {
    this.ar.params.subscribe(i => {
      this.id = i['id'];
      this.customerSer.grtCustomerById(this.id).subscribe(a => {
        this.customer = a;
        //this.customer.addresses = this.customerAddress
        console.log("from init");
        console.log(a);
      })
    })
  }

  save(){
    this.customerSer.updateCustomer(this.customer).subscribe(a => {
      console.log("from save");
      console.log(a);
      this.router.navigateByUrl('/customers');
    });
  }
}