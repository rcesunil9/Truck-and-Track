export class Register {
    constructor() {
        this.Email = "";
        this.FirstName = "";
        this.MiddleName = "";
        this.LastName = "";
        this.Dateofbirth = null
        this.PhoneNumber = "";
        this.Createdby = 0;
    }
    Email: string;
    FirstName: string;
    MiddleName: string;
    LastName: string;
    Dateofbirth: Date | null;
    PhoneNumber: string;
    Createdby: number;
}
