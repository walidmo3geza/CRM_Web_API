import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
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

  form!:FormGroup

  customerAddress:CustomerAddress[] = [];

  constructor(public customerSer:CustomersService,public router:Router, public fb: FormBuilder) { }

  save(){
    this.customerSer.addCustomer(this.form.value).subscribe(a => {
      console.log(a);
    })
    this.router.navigateByUrl('/customers');
  }

  ngOnInit(): void {
    this.form = this.fb.group({
      id:[0],
      code:["00000000-0000-0000-0000-000000000000"], 
      lastName:["",[Validators.required, Validators.minLength(3), Validators.maxLength(20)]],
      firstName:["",[Validators.required, Validators.minLength(3), Validators.maxLength(20)]],
      email:["",[Validators.required, Validators.email]],
      phone:[""],
      addresses:[this.customerAddress] 
    }) 
  }
}
 