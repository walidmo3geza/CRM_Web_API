import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Product } from 'src/app/_models/product';
import { ProductsService } from 'src/app/_service/products.service';

@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.css']
})
export class CreateComponent implements OnInit {

  product:Product = new Product(0, "", "", 0);

  constructor(public productSer:ProductsService,public router:Router) { }

  ngOnInit(): void {
  }

  save(){
    // console.log(this.product);
    this.productSer.addProduct(this.product).subscribe(a => {
      console.log(a);
    })
    this.router.navigateByUrl('/products');
  }

}
