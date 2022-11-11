import { Component, OnInit, OnChanges } from '@angular/core';
import { Router } from '@angular/router';
import { Product } from '../_models/product';
import { ProductsService } from '../_service/products.service';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css']
})
export class ProductsComponent implements OnInit {

  constructor(public productServ:ProductsService, public router:Router) { 
    
  }

  products:Product[] = [];

  ngOnInit(): void {
    this.productServ.grtAllProducts().subscribe(a => {
      this.products = a;
    });
  }
  // ngOnChanges() {
  //   this.productServ.grtAllProducts().subscribe(a => {
  //     this.products = a;
  //   });
  // }
}
