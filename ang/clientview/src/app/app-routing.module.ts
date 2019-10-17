import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './login.component';
import {RegisterformComponent}from'./registerform/registerform.component';
import {ClientComponent} from './client/client.component';
import { AddclientComponent } from './addclient/addclient.component';
import { EditclientComponent } from './editclient/editclient.component';
import{DepartmentsComponent}from'./departments/departments.component';
import{JobTitleComponent}from'./job-title/job-title.component';
const routes: Routes = [{ path: 'login', component: LoginComponent },
                        { path: 'register', component: RegisterformComponent },
                        {path:'department',component:DepartmentsComponent},
                        {path:'jobtitle',component:JobTitleComponent},
                        {path:'client',component:ClientComponent},
                        {path:'addclient',component:AddclientComponent},
                        {path:'editclient/:id',component:EditclientComponent}];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
