import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

import { CoreHttpService } from './core-http.service';
import { UserLogin } from '../common/model/user-login.model';

@Injectable({
  providedIn: 'root'
})
export class UserService extends CoreHttpService {

  constructor(
    _http: HttpClient,
    router: Router,
    toastr: ToastrService
  ) {
    super(_http, router, toastr)
  }

  //current user
  public updateUserStorage(itemName: string, itemData: any) {
    localStorage.setItem(itemName, JSON.stringify(itemData));
  }

  public clearUserStorage(itemName: string) {
    localStorage.removeItem(itemName);
  }

  get user(): UserLogin {
    return JSON.parse(localStorage.getItem('currentUser'))
  }
  
}

