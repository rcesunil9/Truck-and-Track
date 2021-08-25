export class UserLogin {
    
    constructor()
    {
        this.firstName= "";
        this.middleName= "";
        this.lastName= "";
        this.credential1= "";
        this.credential2= "";
        this.credential3= "";
        this.credential4= ""
        this.website= ""
        this.practiceName= "";
        this.isUsePracticeName= false;
        this.isAcceptNewPatients= false
        this.credentialDetailId= 0;
        this.isPaymentSkipped= false
        this.isPrivateAddress= false
        this.providerTypeId= 0;
        this.primaryAddressId= 0;
        this.credentialId= 0;
        this.paymentId= 0;
        this.serviceId= 0;
        this.isadmin= false;
        this.isdriver= false;
        this.createdBy= 0;
        this.modifiedBy= 0;
        this.createdDate=new Date;
        this.modifiedDate=new Date;
        this.isActive= false;
        this.isDelete= false;
        this.id= 0;
        this.userName= "";
        this.email= "";
        this.passwordHash="";
        this.Driverid=0;
        this.companyid=0;

    }
    firstName:string;
    middleName: string
    lastName: string
    credential1: string
    credential2: string
    credential3: string
    credential4: string
    website: string
    practiceName: string
    isUsePracticeName: boolean;
    isAcceptNewPatients: boolean
    credentialDetailId: number;
    isPaymentSkipped: boolean
    isPrivateAddress: boolean
    providerTypeId: number;
    primaryAddressId: number;
    credentialId: number;
    paymentId: number;
    serviceId: number;
    isadmin: boolean;
    isdriver: boolean;
    createdBy: number;
    modifiedBy: number;
    createdDate: Date;
    modifiedDate: Date;
    isActive: boolean;
    isDelete: boolean;
    id: number;
    userName: string;
    email: string;
    passwordHash : string;
    Driverid:number;
    companyid:number;
  
}
