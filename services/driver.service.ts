import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { CoreHttpService } from './core-http.service';
import { ToastrService } from 'ngx-toastr';
import { UserLogin } from 'src/common/model/user-login.model';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class DriverService extends CoreHttpService {

  constructor(
    _http: HttpClient,
    router: Router,
    toastr: ToastrService
  ) {
    super(_http, router, toastr)
  }

  adddriver(data: any): Observable<any> {
    return this.post(`${environment.apiUrl}/api/Account/AddDriver`, data);
  }

  fileUpload(file: FormData): Observable<any> {
    return this.postFormData(`${environment.apiUrl}/api/Account/SaveDriverPhoto`, file)
  }

  GetDriverDetailsbyID(driverId: number): Observable<any> {
    return this.get(`${environment.apiUrl}/api/Driver/GetDriverDetailsbyID?DriverID=` + driverId);
  }
}
