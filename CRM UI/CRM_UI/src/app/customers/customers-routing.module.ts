import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CustomerCreateComponent } from './customer-create/customer-create.component';
import { CustomerUpdateComponent } from './customer-update/customer-update.component';
import { CustomersComponent } from './customers.component';

const routes: Routes = [
  { path: '', component: CustomersComponent },
  { path: 'create', component: CustomerCreateComponent },
  { path: 'update/:id', component: CustomerUpdateComponent },
  { path: 'address/:id', loadChildren: () => import('../customer-address/customer-address.module').then(m => m.CustomerAddressModule) },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CustomersRoutingModule { }
 