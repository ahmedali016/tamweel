import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'one page';
  constructor(
    private router: Router
  ) { }
  ngOnInit() {
    this.router.navigate(['/login']);
  }
}
