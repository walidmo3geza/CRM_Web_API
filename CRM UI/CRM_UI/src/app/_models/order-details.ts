export class OrderDetails {
    
    constructor(public id:number, public lineNo:number, public price:number, public productId:number, public qty:number,
         public tax:number, public total:number, public salesOrderHeaderId:number) {
        
    }
}
