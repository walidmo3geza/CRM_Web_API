import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { OrdersHeader } from '../_models/orders-header';
import { OrdersServiceService } from '../_service/orders-service.service';

@Component({
  selector: 'app-orders',
  templateUrl: './orders.component.html',
  styleUrls: ['./orders.component.css']
})
export class OrdersComponent implements OnInit {

  constructor(public ordersSer:OrdersServiceService, public router:Router) { }

  orders:OrdersHeader[] = [];

  ngOnInit(): void {
    this.ordersSer.grtAllOrders().subscribe(a => {
      this.orders = a;
    });
  }

  canserOrder(id:number){
    this.ordersSer.grtOrderById(id).subscribe(a => {
      a.status = "Canceled"
      console.log(a.status);
      this.ordersSer.updateOrder(a).subscribe(or => {
        console.log(or)
      })
    })
    this.router.navigateByUrl("/orders")
  }

}
