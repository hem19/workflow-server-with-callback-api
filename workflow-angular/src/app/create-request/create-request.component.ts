import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import {SharedService} from 'src/app/shared-services/shared.service';
import { OperationResult, ProcessParameters } from './operationResult';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-create-request',
  templateUrl: './create-request.component.html',
  styleUrls: ['./create-request.component.css']
})
export class CreateDocumentComponent implements OnInit {

  scheme: any;
  schemes: Array<any>;
  state: any;
  states: Array<any>;
  selectedUser: any;
  users: Array<any>;
  title: string;
  leaveDays: number = 1;
  description: string;
  createInstanceUrl = 'http://localhost:8077/workflowapi/createinstance/';

  constructor(private _httpClient: HttpClient,
    private _sharedService: SharedService) { }

  ngOnInit() {
    if(!this.schemes){
      setTimeout(() => {
        this.schemes = this._sharedService.schemeCodes;
        this.scheme = this.schemes[0];
        this.users = this._sharedService.users;
        this.selectedUser = this.users[0];
      }, 300);
    }        
  }

  newGuid() {
    return 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function (c) {
      var r = Math.random() * 16 | 0,
        v = c == 'x' ? r : (r & 0x3 | 0x8);
      return v.toString(16);
    });
  }

  createRequest() {
    let processId = this.newGuid();
    let requestUrl = this.createInstanceUrl + processId;
    let formData = new FormData();
    formData.append("schemeCode", this.scheme);
    formData.append("identityId", this.selectedUser.Name);
    let processParams = {
      LeaveDays: this.leaveDays
    }
    formData.append("ProcessParameters", JSON.stringify(processParams));
    this.createInstanceWithParameters(requestUrl, this.scheme, this.selectedUser.Name, null, null, processParams, 'body', false).subscribe((result) => {
      console.log(result);
      alert('The request is created');
    });
  }

  public createInstanceWithParameters(processUrl: string, schemeCode: string, identityId?: string, impersonatedIdentityId?: string, schemeParameters?: string, processParameters?: ProcessParameters, observe: any = 'body', reportProgress: boolean = false ): Observable<any> {

    let queryParameters = new HttpParams();
    if (schemeCode !== undefined && schemeCode !== null) {
        queryParameters = queryParameters.set('schemeCode', schemeCode);
    }
    if (identityId !== undefined && identityId !== null) {
        queryParameters = queryParameters.set('identityId', identityId);
    }
    if (impersonatedIdentityId !== undefined && impersonatedIdentityId !== null) {
        queryParameters = queryParameters.set('impersonatedIdentityId', impersonatedIdentityId);
    }
    if (schemeParameters !== undefined && schemeParameters !== null) {
        queryParameters = queryParameters.set('schemeParameters', schemeParameters);
    }

    let headers = new HttpHeaders({"Content-Type": "application/json"});

    return this._httpClient.post<OperationResult>(processUrl,
        processParameters,
        {
            params: queryParameters,
            headers: headers,
            observe: observe,
            reportProgress: reportProgress
        }
    );
}
}
