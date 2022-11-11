import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
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

  form!:FormGroup

  constructor(public productSer:ProductsService,public router:Router, public fb: FormBuilder) { 
    //form = this.fb.group
  }

  ngOnInit(): void {
    this.form = this.fb.group({
      id:[0],
      name:["",[Validators.required,Validators.minLength(3)]],
      price:[0,[Validators.required]],
      description:["",[Validators.required]]
    })
  }

  save(){
    this.productSer.addProduct(this.form.value).subscribe(a => {
      console.log(a);
    })
    //this.router.navigateByUrl('/products');
  }

}
