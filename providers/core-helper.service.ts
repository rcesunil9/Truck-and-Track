import { EventEmitter, Injectable } from '@angular/core';
import { AbstractControl, FormArray, FormGroup, ValidatorFn } from '@angular/forms';
import { Title } from '@angular/platform-browser';
import { Router } from '@angular/router';
import { HttpClient, HttpEvent, HttpEventType, HttpRequest } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { ProgressStatusEnum} from 'src/common/model/file-upload.model'
import { ConstantKey } from './core-helper.classes';
import { ToastrService } from 'ngx-toastr';

@Injectable({
  providedIn: 'root'
})
export class CoreHelperService {

  downloadStatus: any;
  fileName: string = ""

  constructor(private titleService: Title, private route: Router,
    private http: HttpClient, private toast: ToastrService) {
    this.downloadStatus = new EventEmitter<ProgressStatusEnum>();
  }

  setBrowserTabTitle = (title: string) => {
    this.titleService.setTitle(title);
  }

  isNullOrUndefined<T>(tObj: T): boolean {
    return tObj === null || tObj === undefined;
  }

  // isNullOrUndefinedMultiple(...tObj): boolean {
  //   return !tObj.every((tEntry) => tEntry !== null && tEntry !== undefined);
  // }

  isStringEmptyOrWhitespace(stringToParse: string) {
    return this.isNullOrUndefined(stringToParse) || stringToParse.trim() === '';
  }

  isArrayEmpty<T>(tArr: T[]): boolean {
    return this.isNullOrUndefined(tArr) || tArr.length <= 0;
  }

  getShortedText = (text: string, limit: number) => {
    if (!this.isNullOrUndefined(limit)) {
      return text.length > limit ? text.substring(0, limit) + '...' : text;
    }
    return text.length > ConstantKey.STRINGLIMITSHORT ? text.substring(0, ConstantKey.STRINGLIMITSHORT) + '...' : text;
  }

  removeAllWhiteSpaces = (text: string) => {
    return text.replace(/\s/g, '');
  }

  snakeCaseToLowerCase = (text: string) => {
    return text.replace(/\_/g, '');
  }

  minSelectedCheckboxes(min = 1) {
    const validator: ValidatorFn = (formArray: AbstractControl) => {
      if (formArray instanceof FormArray) {
        const totalSelected = formArray.controls.length;
        return totalSelected >= min ? null : { notSelected: true };
      }

      throw new Error('formArray is not an instance of FormArray');
    };

    return validator;
  }

  getLoggedinUserDetail() {
    var userData = localStorage.getItem('currentUser');
    if (userData !== null && userData !== undefined && userData !== "") {
      return JSON.parse(userData);
    }
    else {
      this.route.navigate(['/auth']);
    }
  }
  patternPasswordValidator(): ValidatorFn {
    return (control: AbstractControl): any => {
      if (control.value) {

        const regex = new RegExp('^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[!@#\$%\^&\*])(?=.{8,})')
        const valid = regex.test(control.value);
        if (!valid) {
          return { invalidPassword: true };
        }
        // return valid ?  null : { invalidPassword: true };
      }
      //const regex = new RegExp('^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9]).{8,}$');
    };
  }
  MustMatch(controlName: string, matchingControlName: string) {
    return (formGroup: FormGroup) => {
      const control = formGroup.controls[controlName];
      const matchingControl = formGroup.controls[matchingControlName];

      if (matchingControl.errors && !matchingControl.errors.mustMatch) {
        // return if another validator has already found an error on the matchingControl
        return;
      }

      // set error on matchingControl if validation fails
      if (control.value !== matchingControl.value) {
        matchingControl.setErrors({ mustMatch: true });
      } else {
        matchingControl.setErrors(null);
      }
    }
  }

  public GetDownloadFileBlob(file: string): Observable<HttpEvent<Blob>> {
    return this.http.request(new HttpRequest(
      'GET',
      `${environment.apiUrl}/api/Driver/downloadfile?file=${file}`,
      null,
      {
        reportProgress: true,
        responseType: 'blob'
      }));
  }

  public downloadFile(pdfFileName: string, isPdfOpen: boolean = false) {
    this.fileName = pdfFileName?.split("\\")?.pop()!;
    this.GetDownloadFileBlob(pdfFileName).subscribe(
      (data: any) => {
        switch (data.type) {
          case HttpEventType.DownloadProgress:
            this.downloadStatus.emit({ status: ProgressStatusEnum.IN_PROGRESS, percentage: Math.round((data.loaded / data.total) * 100) });
            break;
          case HttpEventType.Response:
            this.downloadStatus.emit({ status: ProgressStatusEnum.COMPLETE });

            if (isPdfOpen) {
              var file = new Blob([data.body], { type: data.body.type });
              var fileURL = URL.createObjectURL(file);
              window.open(fileURL);
            }
            else {

              const downloadedFile = new Blob([data.body], { type: data.body.type });
              const a = document.createElement('a');
              a.setAttribute('style', 'display:none;');
              document.body.appendChild(a);
              a.download = this.fileName
              a.href = URL.createObjectURL(downloadedFile);
              a.target = '_blank';
              a.click();
              document.body.removeChild(a);
            }

            break;
        }
      },
      error => {
        this.downloadStatus.emit({ status: ProgressStatusEnum.ERROR });
        this.toast.error("File Not Found");
      }
    );
  }

}

