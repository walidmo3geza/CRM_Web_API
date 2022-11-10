import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ProductsRoutingModule } from './products-routing.module';
import { ProductsComponent } from './products.component';
import { UpdateComponent } from './update/update.component';
import { CreateComponent } from './create/create.component';


@NgModule({
  declarations: [
    ProductsComponent,
    UpdateComponent,
    CreateComponent
  ],
  imports: [
    CommonModule,
    ProductsRoutingModule,
    FormsModule,
    
  ]
})
export class ProductsModule { }
