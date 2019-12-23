import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { WfDesignerComponent } from 'src/app/wf-designer/wf-designer.component';
import { CreateDocumentComponent } from 'src/app/create-request/create-request.component';
import { UpdateRequestComponent } from 'src/app/update-request/update-request.component';

const routes: Routes = [
  { path: 'wf-designer', component: WfDesignerComponent },
  { path: "create-request", component: CreateDocumentComponent },
  { path: "update-request", component: UpdateRequestComponent},
  { path: '', redirectTo: '/wf-designer', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
