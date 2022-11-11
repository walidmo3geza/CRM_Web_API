import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Route, Router } from '@angular/router';
import { CustomerAddress } from 'src/app/_models/customer-address';
import { CustomerAddressesService } from 'src/app/_service/customer-addresses.service';
import { CustomersService } from 'src/app/_service/customers.service';


@Component({
  selector: 'app-address-create',
  templateUrl: './address-create.component.html',
  styleUrls: ['./address-create.component.css'],
})
export class AddressCreateComponent implements OnInit {

  constructor(public fb: FormBuilder, public ar:ActivatedRoute, public addressServ:CustomerAddressesService,public router:Router, public customerSer:CustomersService) { 
    
  }

  form!:FormGroup

  customerId:number = 0;
  newAddress:CustomerAddress = new CustomerAddress("", "", "", "", "", "", "", false, false,"");

  addressBilling:string = "true";

  ngOnInit(): void {
    this.ar.params.subscribe(i => {
      this.customerId = i['id'];
      //this.form.value.customerId = i['id'];
      //console.log(this.customerId);
    })
    this.form = this.fb.group({
      id:[0],
      addressLine_1:["",[Validators.required]], 
      addressLine_2:["",[Validators.required]],
      city:["",[Validators.required]],
      state:["",[Validators.required]],
      postalCode:["",[Validators.required]],
      country:["",[Validators.required]],
      shippingAddressFlag:[true],
      billingAddressFlag:[false],
      customerId:[0],
      addressType:["",[Validators.required]]
    })
  }

  save(){
    this.form.value.customerId = this.customerId;
    if (this.form.value.addressType == "billing") {
      this.form.value.billingAddressFlag = true;
      this.form.value.shippingAddressFlag = false;
    }
    else{
      this.form.value.billingAddressFlag = false;
      this.form.value.shippingAddressFlag = true;
    }
    this.addressServ.addAddress(this.form.value).subscribe(a => {
      //console.log(a);
      this.router.navigateByUrl("/customers/address/" + this.customerId);
    })
  }

}
