export class OrdersHeader {
    
    constructor(public id:number, public status:string, public date:Date, public tax:number, public subTotal:number, 
        public grandTotal:number, public customerId:string, public billingAddressId:string, public shippingAddressId:string) {
        
    }
}
    //"salesOrderDetails": [],