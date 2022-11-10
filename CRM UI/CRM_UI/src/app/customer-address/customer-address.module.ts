import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { CustomerAddressRoutingModule } from './customer-address-routing.module';
import { CustomerAddressComponent } from './customer-address.component';


@NgModule({
  declarations: [
    CustomerAddressComponent
  ],
  imports: [
    CommonModule,
    CustomerAddressRoutingModule,
    FormsModule
  ]
})
export class CustomerAddressModule { }
