import { Component, OnInit } from '@angular/core';
import {clients} from '../clientclass';
import{ClientApiService}from '../client-api.service';
@Component({
  selector: 'app-client',
  templateUrl: './client.component.html',
  styleUrls: ['./client.component.scss']
})
export class ClientComponent implements OnInit {

clientData:clients[]=[];
  constructor(private api:ClientApiService) { }

  ngOnInit() {
    this.api.getClient().subscribe(res=>this.clientData=res);
    
  }

  DeleteClient(id){
     let conf=confirm("Are you want to delete this client!");
    if(conf==true){
      this.api.deleteClient(id).subscribe(res=>this.clientData=res);
    }
  }
}
