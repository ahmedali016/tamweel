import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule  } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './login.component';
import { DepartmentsComponent } from './departments/departments.component';
import { JobTitleComponent } from './job-title/job-title.component';
import { ClientComponent } from './client/client.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { RegisterformComponent } from './registerform/registerform.component';
import { AddclientComponent } from './addclient/addclient.component';
import { EditclientComponent } from './editclient/editclient.component';

  
@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    DepartmentsComponent,
    JobTitleComponent,
    ClientComponent,
    RegisterformComponent,
    AddclientComponent,
    EditclientComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
  HttpClientModule,
    AppRoutingModule,
 
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
