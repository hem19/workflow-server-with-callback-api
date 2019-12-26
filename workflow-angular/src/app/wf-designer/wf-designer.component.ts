import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { SharedService } from 'src/app/shared-services/shared.service';

declare let WorkflowDesigner: any;
declare let WorkflowDesignerForm: any;

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

    this.wfdesigner = new WorkflowDesigner({
      name: 'simpledesigner',
      apiurl: this.apiurl,
      renderTo: 'wfdesigner',
      imagefolder: '/assets/workflow/images/',
      graphwidth: window.innerWidth - this.offsetX,
      graphheight: window.innerHeight - this.offsetY,
      forms: {
        activity: function (params) {
          console.log(params);
          params.elements = [
             { name: "Name", field: "Name", type: "input" },
             { name: "State", field: "State", type: "input" }
          ];
          var form = new WorkflowDesignerForm(params);
          var saveFunc = function (data) {
             form.ClearTempField(data);
             form.parameters.saveFunc(Object.assign(params.data, data));
             return true;
          };
          form.showModal(saveFunc);
        },
        // transition:  function(params){
        //     console.log(params);
        // },
        // actors:  function(params){
        //     console.log(params);
        // },
        // commands:  function(params){
        //     console.log(params);
        // },
        // timers:  function(params){
        //     console.log(params);
        // },
        // codeactions:  function(params){
        //     console.log(params);
        // },
        // parameters:  function(params){
        //     console.log(params);
        // },
        // localization:  function(params){
        //     console.log(params);
        // },
        // legend: function(params){
        //     console.log(params);
        // },
        // processinfo: function(params){
        //     console.log(params);
        // }
      },
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
