import { createComponent, NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddToCartComponent } from './add-to-cart/add-to-cart.component';
import { CreateComponent } from './create/create.component';
import { ProductsComponent } from './products.component';
import { UpdateComponent } from './update/update.component';

const routes: Routes = [
  { path: '', component: ProductsComponent },
  { path: 'update/:id', component: UpdateComponent },
  { path: 'create', component: CreateComponent },
  { path: 'addToCart/:id', component: AddToCartComponent },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ProductsRoutingModule { }
