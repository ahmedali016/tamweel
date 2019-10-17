import { Component, OnInit,Input } from '@angular/core';
import {  ActivatedRoute } from '@angular/router';
import{ClientApiService}from '../client-api.service';
import {clients} from '../clientclass';
import {JobApiService} from '../job-api.service';
import{ApiService}from'../api.service';
import{Department}from '../departmentclass';
import {jobtitle} from '../jobtitleclass';
import {Address} from '../clientaddress';
import {Phone} from '../clientphone';

@Component({
  selector: 'app-editclient',
  templateUrl: './editclient.component.html',
  styleUrls: ['./editclient.component.scss']
})
export class EditclientComponent implements OnInit {
 @Input() data:clients;
  
   phonenum:Phone[] = [];
   adders:Address[] = [];
   //public phonenum:Array<string> = [];
  //public adders:Array<string> = [];
  departdata: Department[] ;
  jobdata:jobtitle[]=[];
   fileToUpload: File = null;
  constructor(private route:ActivatedRoute,private api:ClientApiService,private jobapi:JobApiService,private departapi:ApiService) { }

  ngOnInit() {
    this.departapi.getDepartment().subscribe(res => {this.departdata = res;}, err => {console.log(err);});
  
   this.jobapi.getjobs().subscribe(res=>{this.jobdata=res});
    let adata:clients;
    const id = +this.route.snapshot.paramMap.get('id');
    console.log(id);
    this.api.getClientData(id).subscribe(res=>this.data=res);
     this.api.getClientData(id).subscribe(res=>this.adders=res.clientAddress);
    this.api.getClientData(id).subscribe(res=>this.phonenum=res.clientPhone);
   
   //for(var i=0;i<this.addrs.length;i++){
   //  this.adders.push(this.addrs[i].addres);
   //}
   //for(var i=0;i<this.phos.length;i++){
   //  this.phonenum.push(this.phos[i].phones);
   //}
  }
  
    handleFileInput(files: FileList) {
    this.fileToUpload = files.item(0);
}
  AddClient(name,birthdate,mail,department,job,pass,conf,img){
   
   const id = +this.route.snapshot.paramMap.get('id');
    const formData = new FormData();
    formData.append('id', id.toString() );
    formData.append('name', name);
    formData.append('birth', birthdate);
    formData.append('mail', mail);
    formData.append('department', department);
    formData.append('job', job);
    formData.append('pass', pass);    
    formData.append('phones',JSON.stringify(this.phonenum));    
    formData.append('addresses',JSON.stringify(this.adders));
    formData.append('file', this.fileToUpload);
  

    console.log(this.fileToUpload);
    this.api.editClient(formData).subscribe();
  }
  
  AddPhone(phone){
    if(phone>0)
    this.phonenum.push({'phones':phone,'clientId':0});
  }
  DelPhone(index){
    this.phonenum.pop();
  }
  AddAddress(address){
    this.adders.push({'addres':address,'clientId':0});
  }
  DelAddress(index){
    this.adders.pop();
  }

}
