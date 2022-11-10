import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddressCreateComponent } from './address-create/address-create.component';
import { CustomerAddressComponent } from './customer-address.component';

const routes: Routes = [
  { path: '', component: CustomerAddressComponent },
  { path: 'create', component: AddressCreateComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CustomerAddressRoutingModule { }
