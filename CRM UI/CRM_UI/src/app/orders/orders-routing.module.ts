import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { OrderAddProductComponent } from './order-add-product/order-add-product.component';
import { OrderCreateComponent } from './order-create/order-create.component';
import { OrdersComponent } from './orders.component';

const routes: Routes = [
  { path: '', component: OrdersComponent },
  { path: 'create', component: OrderCreateComponent },
  { path: 'addProduct/:id', component: OrderAddProductComponent },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class OrdersRoutingModule { }
