import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Product } from 'src/app/_models/product';
import { ProductsService } from 'src/app/_service/products.service';

@Component({
  selector: 'app-update',
  templateUrl: './update.component.html',
  styleUrls: ['./update.component.css']
})
export class UpdateComponent implements OnInit {

  constructor(public productSer:ProductsService, public ar:ActivatedRoute, public router:Router) { }

  id:string = "";

  product:Product = new Product(0,"","",0);

  ngOnInit(): void {
    this.ar.params.subscribe(i => {
      this.id = i['id'];
      this.productSer.grtProductById(this.id).subscribe(a => {
        this.product = a;
        console.log("from init");
        console.log(a);
      })
    })
  }

  save(){
    this.productSer.updateProduct(this.product).subscribe(a => {
      console.log("from save");
      console.log(a);
      this.router.navigateByUrl('/products');
    });
  }


}
