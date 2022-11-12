import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { OrdersHeader } from 'src/app/_models/orders-header';
import { Product } from 'src/app/_models/product';
import { OrdersServiceService } from 'src/app/_service/orders-service.service';
import { ProductsService } from 'src/app/_service/products.service';

@Component({
  selector: 'app-add-to-cart',
  templateUrl: './add-to-cart.component.html',
  styleUrls: ['./add-to-cart.component.css']
})
export class AddToCartComponent implements OnInit {

  isSubmitted = false;
  ordersHeaders: OrdersHeader[] = [];
  productId:string = "";
  
  constructor(public fb: FormBuilder, public ar:ActivatedRoute, public orderSer:OrdersServiceService, public productSer:ProductsService) { }
  form = this.fb.group({
    OrderHeaderId: ['', [Validators.required]],
  });
  changeOrder(e: any) {
    this.OrderHeaderId?.setValue(e.target.value, {
      onlySelf: true,
    });
  }
  // Access formcontrols getter
  get OrderHeaderId() {
    return this.form.get('OrderHeaderId');
  }
  save(): void {
    this.isSubmitted = true;
  }

  product:Product = new Product(0,"","",0);

  ngOnInit(): void {
    this.orderSer.grtAllOrders().subscribe(c => {
      this.ordersHeaders = c;
    })
    this.ar.params.subscribe(a => {
      this.productId = a['id'];
      this.productSer.grtProductById(this.productId).subscribe(a => {
        this.product = a;
      })
    })
  }

  qtyValue:number =0;
  qtyForm = this.fb.group({
    id:[0],
    lineNo:[0],
    price:[0],
    productId:[0],
    qty:[this.qtyValue,[Validators.required]],
    tax:[0],
    total:[0],
    salesOrderHeaderId:[this.form.value.OrderHeaderId]
  }) 

  

  decQty(){
    if (this.qtyValue > 0) {
      this.qtyValue -= 1;
    }
    
  }

  incQty(){
    this.qtyValue += 1;
  }
}
