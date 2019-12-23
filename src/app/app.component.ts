import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { SharedService } from 'src/app/shared-services/shared.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Workflow Server Integration Test';

  constructor(private _httpClient: HttpClient,
    private _sharedService: SharedService) {

    let schemeListUrl = 'http://localhost:8077/workflowapi/getschemelist/';
    this._httpClient.get(schemeListUrl).subscribe((result: any) => {
      this._sharedService.schemeCodes = result.data;
      this._sharedService.schemeCode = result.data[0];
    });

    let usersUrl = 'http://localhost:44328/api/workflow/users';    
    this._httpClient.get(usersUrl).subscribe((result: any) => {
      this._sharedService.users = result.data;
    });
  }
}


