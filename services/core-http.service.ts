import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { ToastrService } from 'ngx-toastr';
import { Injectable } from '@angular/core';
import { of } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CoreHttpService {

  constructor(private http: HttpClient,
    private router: Router,
    public toastrService: ToastrService) {
  }
  protected get<T>(method: string, params?: any): Observable<any> {
    return this.http.get(method,
      { headers: this.setHeaders(), params: this.setParams(params) }).pipe(
        map((response) => this.extractData<T>(response))
        , catchError(err => this.handleError(err)));
  }

  protected getBlobData<T>(method: string): Observable<any> {
    return this.http.get(method, { headers: this.setHeaders('formData'), responseType: 'blob' }).pipe(
      map((response) => { return response; })
      , catchError(err => this.handleError(err)));
  }

  protected getBlobDatapost<T>(method: string, body: any): Observable<any> {
    return this.http.post(method, body, { headers: this.setHeaders('formData'), responseType: 'blob' }).pipe(
      map((response) => { return response; })
      , catchError(err => this.handleError(err)));
  }

  protected post<T>(method: string, body: any): Observable<any> {
    const model = JSON.stringify(body);
    return this.http.post(method, model, { headers: this.setHeaders() }).pipe(
      map((response) => this.extractData<T>(response))
      , catchError(err => this.handleError(err)));
  }

  protected delete<T>(method: string, params?: any): Observable<any> {
    return this.http.delete(method, { headers: this.setHeaders(), params: this.setParams(params) }).pipe(
      map((response) => this.extractData<T>(response))
      , catchError(err => this.handleError(err)));
  }

  protected put<T>(method: string, body: any): Observable<any> {
    const model = JSON.stringify(body);
    return this.http.put(method, model, { headers: this.setHeaders() }).pipe(
      map((response) => this.extractData<T>(response))
      , catchError(err => this.handleError(err)));
  }

  protected postFormData<T>(method: string, body: any): Observable<any> {
    return this.http.post(method, body, { headers: this.setHeaders('formData') }).pipe(
      map((response) => this.extractData<T>(response))
      , catchError(err => this.handleError(err)));
  }

  private setHeaders(contentType?: string) {
    let headers = new HttpHeaders();
    if (contentType === 'formData') { } else if (contentType) {
      headers = headers.set('Content-Type', contentType);
    } else {
      headers = headers.set('Content-Type', 'application/json');
    }
    // const token = JSON.parse(localStorage.getItem('token'));
    // // check user
    // if (!!token) {
    //   headers = headers.append('Authorization', 'Bearer ' + token);
    // }
    return headers;
  }

  private setParams(params: any) {
    let httpParams = new HttpParams();
    if (!params) {
      return httpParams;
    }
    for (const param of Object.keys(params)) {
      if (params[param]) {
        httpParams = httpParams.set(param, params[param]);
      }
    }
    return httpParams;
  }

  private extractData<T>(res: any) {
    let body;
    try {
      body = res;
      body.messages.forEach((message: any) => {
        this.toastrService.success(message.messageText, message.title, { timeOut: 10000 });
        // console.log(message.messageText);
      });
    } catch (e) {
      return {};
    }
    return <T>body || {};
  }

  private logOutWhenTokenFalse() {
    localStorage.clear();
    this.router.navigate(['/auth']).then();
  }

  private handleError(error: Response | any) {
    let errorMessage = '';
    // Handle 401 - Unauthorized
    if (error.status === 400) {
      let errors;
      if (error._body) {
        errors = error._body;
      } else {
        errors = error.error;
      }
      if (errors && errors.length > 0) {
        errors.forEach((errorItem: any) => {
          this.toastrService.error(errorItem.errorMessage, 'Error', { timeOut: 10000 });
          console.error(errorItem);
        });
      }
      return of(error);
    }
    // Handle 401 - Unauthorized
    if (error.status === 401 || error.status === 403) {
      this.toastrService.warning('401(403) - Invalid token');
      console.error('401(403) - Invalid token');
      this.logOutWhenTokenFalse();
      console.error(error);
      return of(errorMessage);
    }
    if (error.status === 409) {
      this.toastrService.error(error.errorMessage, 'Error', { timeOut: 10000 });
      return of(errorMessage);
    }
    const body = error._body || '';
    errorMessage = `${error.status} - ${error.statusText || ''} ${body}`;
    console.error(errorMessage);
    this.toastrService.error(errorMessage, 'Error', { timeOut: 10000 });
    return of(errorMessage);
  }

}
