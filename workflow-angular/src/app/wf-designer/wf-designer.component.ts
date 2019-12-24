import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { SharedService } from 'src/app/shared-services/shared.service';

@Component({
  selector: 'app-wf-designer',
  templateUrl: './wf-designer.component.html',
  styleUrls: ['./wf-designer.component.css']
})
export class WfDesignerComponent implements OnInit {

  schemecodes = [];
  schemecode;
  processid = undefined;
  apiurl = 'http://localhost:8077/DesignerAPI'; //'/Designer/API'
  offsetX = 0;
  offsetY = 120;
  wfdesigner: any;

  constructor(private _httpClient: HttpClient,
    private _sharedService: SharedService) { }

  ngOnInit() {
    var me = this;
    let schemeListUrl = 'http://localhost:8077/workflowapi/getschemelist/';
    this._httpClient.get(schemeListUrl).subscribe((result: any) => {
      this.schemecodes = result.data;
      this.schemecode = this.schemecodes[0];
      me.wfdesignerRedraw();
      window.onresize = function (event) {
        if (me != undefined && me.wfdesigner != undefined) {
          me.wfdesignerRedraw();
        }
      };
    });
  }

  wfdesignerRedraw() {
    let data = undefined;
    if (this.wfdesigner != undefined) {
      // data = this.wfdesigner.data;
      this.wfdesigner.destroy();
    }

    this.wfdesigner = new window["WorkflowDesigner"]({
      name: 'simpledesigner',
      apiurl: this.apiurl,
      renderTo: 'wfdesigner',
      imagefolder: '/assets/workflow/images/',
      graphwidth: window.innerWidth - this.offsetX,
      graphheight: window.innerHeight - this.offsetY
    });

    if (data == undefined) {
      let isreadonly = false;
      if (this.processid != undefined && this.processid != '')
        isreadonly = true;

      let p = { schemecode: this.schemecode, processid: this.processid, readonly: isreadonly };

      if (this.wfdesigner.exists(p))
        this.wfdesigner.load(p);
      else
        this.wfdesigner.create();
    }
    else {
      this.wfdesigner.data = data;
      this.wfdesigner.render();
    }
  }

  // onNew() {
  //   let lastCode = this.schemecodes[this.schemecodes.length - 1];
  //   let newCode = lastCode.split('-')[0] + '-' + (+lastCode.split('-')[1] + 1);
  //   this.schemecode = newCode;
  //   this.schemecodes.push(newCode);
  //   this.wfdesigner.create();
  // }

  onSave() {
    this.wfdesigner.schemecode = this.schemecode;
    var error = this.wfdesigner.validate();
    if (error != undefined && error.length > 0) {
      alert(error);
    }
    else {
      this.wfdesigner.save(() => {
        alert('The scheme is saved');
      });
    }
  }

}
