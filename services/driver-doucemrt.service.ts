import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { CoreHttpService } from './core-http.service';
import { ToastrService } from 'ngx-toastr';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})

export class DriverDoucemrtService extends CoreHttpService {

  constructor(
    _http: HttpClient,
    router: Router,
    toastr: ToastrService
  ) {
    super(_http, router, toastr)
  }

  //get driver name list
  getDriverNames(companyId: number): Observable<any> {
    return this.get(`${environment.apiUrl}/api/Driver/GetAllDriverNames?CompanyID=` + companyId);
  }

  //get Document List
  getDriverDocumentList(driverId: number): Observable<any> {
    return this.get(`${environment.apiUrl}/api/Driver/GetDriverDocumentsforAdmin?DriverID=` + driverId);
  }

    //upload driver document
    uploadDriverDocument(model: FormData): Observable<any> {
      return this.postFormData(`${environment.apiUrl}/api/Driver/AddDriverDocumentsforAdmin`, model);
    }
  
    // delete document
    deleteDocument(driverDocumentID: number, deletedBy: number): Observable<any> {
      return this.delete(`${environment.apiUrl}/api/Driver/DeleteDriverDocumentsforAdmin?DriverDocumentID=` +driverDocumentID+ '&DeletedBy=' +deletedBy);
    }

}
