import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { OrdersRoutingModule } from './orders-routing.module';
import { OrdersComponent } from './orders.component';
import { OrderCreateComponent } from './order-create/order-create.component';
import { ReactiveFormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    OrdersComponent,
    OrderCreateComponent,
    
  ],
  imports: [
    CommonModule,
    OrdersRoutingModule,
    ReactiveFormsModule
  ]
})
export class OrdersModule { }
