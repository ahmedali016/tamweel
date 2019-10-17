import { Component, OnInit } from '@angular/core';
import{ApiService}from'../api.service';
import{Department}from '../departmentclass';
import { FormGroup } from '@angular/forms';
import { Observable, of, throwError } from 'rxjs';
@Component({
  selector: 'app-departments',
  templateUrl: './departments.component.html',
  styleUrls: ['./departments.component.scss']
})
export class DepartmentsComponent implements OnInit {
displayedColumns: string[] = ['departid', 'departname'];
data: Department[] ;
departname='';
isLoadingResults = true;
  constructor(private api: ApiService) { }
  ngOnInit() {
    
    this.api.getDepartment()
  .subscribe(res => {
    this.data = res;
    console.log(this.data);
    this.isLoadingResults = false;
  }, err => {
    console.log(err);
    this.isLoadingResults = false;
  });
  }
  
 AddDepartment(depart:string) {
  //this.senddata.departmentName='new depart';
  
  let newdepart:Department={departmentName:depart,depaId:0}
  this.api.addDepart(newdepart).subscribe(res=>this.data=res);
    
  }
  
  DeleteDepartment(id:number){
     let conf=confirm("Are you want to delete this department!");
    if(conf==true){
    this.api.deleteDepart(id).subscribe(res=>this.data=res);
    }
  }
  EditDepartment(id:number,depart:string){
    let department={departmentName:depart,depaId:id};
    this.api.EditDepart(department).subscribe(res=>this.data=res);
  }
}
