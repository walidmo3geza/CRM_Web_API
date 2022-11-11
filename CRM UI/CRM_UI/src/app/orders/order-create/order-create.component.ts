import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Customer } from 'src/app/_models/customer';
import { CustomerAddress } from 'src/app/_models/customer-address';
import { OrdersHeader } from 'src/app/_models/orders-header';
import { CustomerAddressesService } from 'src/app/_service/customer-addresses.service';
import { CustomersService } from 'src/app/_service/customers.service';
import { OrdersServiceService } from 'src/app/_service/orders-service.service';

@Component({
  selector: 'app-order-create',
  templateUrl: './order-create.component.html',
  styleUrls: ['./order-create.component.css']
})
export class OrderCreateComponent implements OnInit {

  order:OrdersHeader = new OrdersHeader(0,"Active", new Date(), 0, 0, 0, "", "", "");

  isSubmitted = false;
  billingAddressSubmited = false;
  shapingAddressSubmited = false;

  customers: Customer[] = [];
  billingAddress: CustomerAddress[] = [];
  shapingAddress: CustomerAddress[] = [];

  constructor(public fb: FormBuilder, public customerSer: CustomersService, public addressService:CustomerAddressesService,
    public orderService:OrdersServiceService, public router:Router) { }
  form = this.fb.group({
    customerId: ['', [Validators.required]],
  });
  billingForm = this.fb.group({
    billingAddressId: ['', [Validators.required]],
  });
  shapingForm = this.fb.group({
    shapingAddressId: ['', [Validators.required]],
  });
  
  changeCustomer(e: any) {
    this.customerId?.setValue(e.target.value, {
      onlySelf: true,
    });
  }
  changeBilling(e: any) {
    this.billingAddressId?.setValue(e.target.value, {
      onlySelf: true,
    });
  }
  changeshaping(e: any) {
    this.shapingAddressId?.setValue(e.target.value, {
      onlySelf: true,
    });
  }
  
  get shapingAddressId() {
    return this.shapingForm.get('shapingAddressId');
  }
  get billingAddressId() {
    return this.billingForm.get('billingAddressId');
  }
  get customerId() {
    return this.form.get('customerId');
  }

  save(): void {
    this.isSubmitted = true;
    console.log(this.form.value.customerId);
    console.log(this.isSubmitted);
    this.shapingAddress = [];
    this.billingAddress = [];
    this.addressService.grtAllAddress().subscribe(a => {
      for (let i = 0; i < a.length; i++) {
        // console.log("i = " + i)
        // console.log("a[i].id = " + a[i].id)
        // console.log("this.form.value.customerId = " + this.form.value.customerId)
        if (a[i].customerId == this.form.value.customerId) {
          
          if (a[i].shippingAddressFlag == true) {
            this.shapingAddress.push(a[i]);
            //console.log("shipping")
          }
          if(a[i].billingAddressFlag == true){
            this.billingAddress.push(a[i]);
            //console.log("billing")
          }
        }
      }
    })
    this.order.customerId = String(this.form.value.customerId);
  }
  saveBilling(): void {
    this.billingAddressSubmited = true;
    // console.log(this.billingForm.value.billingAddressId);
    // console.log(this.billingAddressSubmited);
    this.order.billingAddressId = String(this.billingForm.value.billingAddressId)
  }
  saveshaping(): void {
    this.shapingAddressSubmited = true;
    // console.log(this.shapingForm.value.shapingAddressId);
    // console.log(this.shapingAddressSubmited);
    this.order.shippingAddressId = String(this.shapingForm.value.shapingAddressId)
  }


  ngOnInit(): void {
    this.customerSer.grtAllCustomers().subscribe(c => {
      this.customers = c;
    })
  }

  addOrder(){
    this.orderService.addOrder(this.order).subscribe(a => {

    });
    this.router.navigateByUrl("/orders");
  }

}
