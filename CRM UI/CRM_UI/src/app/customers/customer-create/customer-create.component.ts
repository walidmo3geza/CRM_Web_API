import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Customer } from 'src/app/_models/customer';
import { CustomerAddress } from 'src/app/_models/customer-address';
import { CustomersService } from 'src/app/_service/customers.service';

@Component({
  selector: 'app-customer-create',
  templateUrl: './customer-create.component.html',
  styleUrls: ['./customer-create.component.css']
})
export class CustomerCreateComponent implements OnInit {

  customerAddress:CustomerAddress[] = [];

  customer:Customer = new Customer(0, "00000000-0000-0000-0000-000000000000", "", "", "", "", this.customerAddress);

  constructor(public customerSer:CustomersService,public router:Router) { }

  ngOnInit(): void {
  }

  save(){
    // console.log(this.Customer);
    this.customerSer.addCustomer(this.customer).subscribe(a => {
      console.log(a);
    })
    this.router.navigateByUrl('/customers');
  }

}
 