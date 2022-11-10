import { Component, OnInit } from '@angular/core';
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

  constructor(public ar:ActivatedRoute, public addressServ:CustomerAddressesService,public router:Router, public customerSer:CustomersService) { 
    
  }

  customerId:number = 0;
  newAddress:CustomerAddress = new CustomerAddress(0, "", "", "", "", "", "", false, false,0);

  addressBilling:string = "true";

  ngOnInit(): void {
    this.ar.params.subscribe(i => {
      this.customerId = i['id'];
      //console.log(this.customerId);
    })
  }

  save(){
    this.newAddress.customerId = this.customerId;
    if (this.addressBilling == "true") {
      this.newAddress.billingAddressFlag = true;
      this.newAddress.shippingAddressFlag = false;
    }
    else{
      this.newAddress.billingAddressFlag = false;
      this.newAddress.shippingAddressFlag = true;
    }
    console.log(this.newAddress);
    console.log(this.customerId + "customerId");
    console.log(this.newAddress.customerId);
    this.addressServ.addAddress(this.newAddress).subscribe(a => {
      //console.log(a);
      this.router.navigateByUrl("/customers/address/" + this.customerId);
    })
  }

}
