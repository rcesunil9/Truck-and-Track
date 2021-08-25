import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { CoreHttpService } from './core-http.service';
import { ToastrService } from 'ngx-toastr';
import { Observable } from 'rxjs';
import { environment } from '../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AuthService extends CoreHttpService {

  constructor(
    _http: HttpClient,
    router: Router,
    toastr: ToastrService
  ) {
    super(_http, router, toastr)
  }

  getuserdetails(userid: string): Observable<any> {
    return this.get(`${environment.apiUrl}/api/account/GetUserDetailsByID?UserID=` + userid);
  }

  login(userName: string, password: string): Observable<any> {
    return this.get(`${environment.apiUrl}/api/account/Login?Username=` + userName + '&PasswordHash=' + password);
  }

  forgotPassword(email: string): Observable<any> {
    return this.get(`${environment.apiUrl}/api/account/ForgetPassword?EmailId=` + email);
  }


  changePassword(userid: number, password: string, form: string): Observable<any> {
    return this.get(`${environment.apiUrl}/api/account/ChangePassword?UserID=` + userid + '&Password=' + password + '&From=' + form);
  }

}
