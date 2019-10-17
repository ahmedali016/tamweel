import { Component, OnInit } from '@angular/core';
import {Phone}from '../clientphone';
import{ClientApiService}from '../client-api.service';
import {JobApiService} from '../job-api.service';
import{ApiService}from'../api.service';
import{Department}from '../departmentclass';
import {jobtitle} from '../jobtitleclass';

@Component({
  selector: 'app-addclient',
  templateUrl: './addclient.component.html',
  styleUrls: ['./addclient.component.scss']
})
export class AddclientComponent implements OnInit {
  
  public phonenum:Array<string> = [];
  public adders:Array<string> = [];
  departdata: Department[] ;
  jobdata:jobtitle[]=[];
  fileToUpload: File = null;
  constructor(private api:ClientApiService,private jobapi:JobApiService,private departapi:ApiService) { }

  ngOnInit() {
    this.departapi.getDepartment()
  .subscribe(res => {this.departdata = res;console.log(this.departdata);}, err => {console.log(err);});
  
   this.jobapi.getjobs().subscribe(res=>{this.jobdata=res});
  
  }
  handleFileInput(files: FileList) {
    this.fileToUpload = files.item(0);
}
  AddClient(name,birthdate,mail,department,job,pass,conf,img){
   
   
    const formData = new FormData();
    formData.append('name', name);
    formData.append('birth', birthdate);
    formData.append('mail', mail);
    formData.append('department', department);
    formData.append('job', job);
    formData.append('pass', pass);    
    formData.append('phones',JSON.stringify(this.phonenum));    
    formData.append('addresses',JSON.stringify(this.adders));
    formData.append('file', this.fileToUpload);
  
    console.log(conf);
    console.log(this.fileToUpload);
    this.api.addClient(formData).subscribe();
  }
  
  AddPhone(phone){
    if(phone>0)
    this.phonenum.push(phone);
  }
  DelPhone(index){
    this.phonenum.pop();
  }
  AddAddress(address){
    this.adders.push(address);
  }
  DelAddress(index){
    this.adders.pop();
  }
}
