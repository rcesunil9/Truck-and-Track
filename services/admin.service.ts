import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Observable } from 'rxjs';
import { UserRegisterService } from 'src/common/model/user-register-service.model';
import { environment } from 'src/environments/environment';
import { CoreHttpService } from './core-http.service';

@Injectable({
  providedIn: 'root'
})
export class AdminService extends CoreHttpService {

  constructor(
    _http: HttpClient,
    router: Router,
    toastr: ToastrService
  ) {
    super(_http, router, toastr)
  }

  addadmin(userModel: UserRegisterService): Observable<any> {
    return this.post(`${environment.apiUrl}/api/Account/AddUser`, userModel);
  }

  fileUpload(file: FormData): Observable<any> {
    return this.postFormData(`${environment.apiUrl}/api/Account/SaveAdminPhoto`, file)
  }
}
