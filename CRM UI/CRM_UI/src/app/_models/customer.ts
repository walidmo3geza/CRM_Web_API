import { CustomerAddress } from "./customer-address";

export class Customer {
    
    constructor(public id:number, public code:string, public firstName:string, 
        public lastName:string, public email:string, public phone:string, public addresses:CustomerAddress[]) {
         
    }
    
}