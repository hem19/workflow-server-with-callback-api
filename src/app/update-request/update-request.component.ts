import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { SharedService } from 'src/app/shared-services/shared.service';

@Component({
  selector: 'app-update-request',
  templateUrl: './update-request.component.html',
  styleUrls: ['./update-request.component.css']
})
export class UpdateRequestComponent implements OnInit {

  schemeCode: string;
  processIds: Array<any> = [];
  selectedProcessId: any;
  commands: Array<any> = [];
  selectedUser: any;
  users: Array<any>;
  listOfProcessIdsUrl = "http://localhost:44328/api/workflow/GetNonFinalizedInstances";
  listOfCommandsUrl = 'http://localhost:8077/workflowapi/getavailablecommands/';
  executeCommandUrl = 'http://localhost:8077/workflowapi/executecommand/';

  constructor(private _httpClient: HttpClient,
    private _sharedService: SharedService) { }

  ngOnInit() {
    if(!this.schemeCode) {
      setTimeout(() => {
        this.schemeCode = this._sharedService.schemeCode;    
        this.users = this._sharedService.users;
        this.selectedUser = this.users[0];
        this.loadInstances();
      }, 300);
    }
  }

  fireCommand(command) {
    let completeUrl = this.executeCommandUrl + this.selectedProcessId;
    let data = new FormData();
    data.append("command", command.CommandName);
    data.append("identityId", this.selectedUser.Name);
    this._httpClient.post(completeUrl, data).subscribe((result) => {
      alert("command executed successfully");
      console.log(result);
    });
  }

  onSelectedProcessChanged() {
    this.loadCommands();
  }

  onSelectedUserChanged() {
    console.log(this.selectedUser);
    this.loadCommands();
  }

  loadCommands() {
    let initialCommandUrl = this.listOfCommandsUrl + this.selectedProcessId + "?identityId=" + this.selectedUser.Name;
    this._httpClient.get(initialCommandUrl).subscribe((result: any) => {
      this.commands = result.data;
    });
  }

  loadInstances() {
    let instancesUrl = this.listOfProcessIdsUrl + "?schemeCode=" + this.schemeCode;
    this._httpClient.get(instancesUrl).subscribe((result: any) => {
      this.processIds = result;
      this.selectedProcessId = this.processIds[0];
      this.loadCommands();
    });
  }

}
