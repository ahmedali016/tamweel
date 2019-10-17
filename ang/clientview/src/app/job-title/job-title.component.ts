import { Component, OnInit } from '@angular/core';
import {jobtitle} from '../jobtitleclass';
import {JobApiService} from '../job-api.service';
import { Observable } from "rxjs";
import { Router, ActivatedRoute, ParamMap } from '@angular/router';
@Component({
  selector: 'app-job-title',
  templateUrl: './job-title.component.html',
  styleUrls: ['./job-title.component.scss']
})
export class JobTitleComponent implements OnInit {

 //public data: Observable<Array<jobtitle>>;
  data:jobtitle[]=[];
  constructor(private api:JobApiService,private router:Router) { }

  ngOnInit() {
     
    this.api.getjobs().subscribe(res=>{this.data=res});
  }
    
    
  AddJobTitle(job){
    console.log(job);
    let newJob={jobTitle:job,jobId:0};
    this.api.addJob(newJob).subscribe(res=>this.data=res);

  }
  
  DeleteJob(id){
    let conf=confirm("Are you want to delete this job!");
    if(conf==true){
      this.api.deleteJob(id).subscribe(res=>this.data=res);
    }
    
  }
  
  EditJob(id,job){
    
    let edited={jobTitle:job,jobId:id};
    let rs= this.api.EditJob(edited).subscribe(res=>this.data=res);
    console.log(rs);
  }

}
