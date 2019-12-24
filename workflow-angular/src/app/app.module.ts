import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {HttpClientModule} from '@angular/common/http';
import { FormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CreateDocumentComponent } from './create-request/create-request.component';
import { WfDesignerComponent } from './wf-designer/wf-designer.component';
import { UpdateRequestComponent } from './update-request/update-request.component';

@NgModule({
  declarations: [
    AppComponent,
    CreateDocumentComponent,
    WfDesignerComponent,
    UpdateRequestComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
