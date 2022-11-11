import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { OrdersRoutingModule } from './orders-routing.module';
import { OrdersComponent } from './orders.component';
import { OrderCreateComponent } from './order-create/order-create.component';
import { ReactiveFormsModule } from '@angular/forms';
import { OrderAddProductComponent } from './order-add-product/order-add-product.component';


@NgModule({
  declarations: [
    OrdersComponent,
    OrderCreateComponent,
    OrderAddProductComponent
  ],
  imports: [
    CommonModule,
    OrdersRoutingModule,
    ReactiveFormsModule
  ]
})
export class OrdersModule { }
