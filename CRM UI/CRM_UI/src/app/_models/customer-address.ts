export class CustomerAddress {
    constructor(public id:number, public addressLine_1:string, public addressLine_2:string, 
        public city:string, public state:string, public postalCode:string, public country:string, 
        public shippingAddressFlag:boolean, public billingAddressFlag:boolean,public customerId:number) {
         
    }
}
