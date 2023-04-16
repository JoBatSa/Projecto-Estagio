import { Component, OnInit } from '@angular/core';
import { LayoutModule } from '@angular/cdk/layout';
import { map } from 'rxjs/operators';
import { Breakpoints, BreakpointObserver } from '@angular/cdk/layout';

import { Router } from '@angular/router';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.css']
})
export class MenuComponent implements OnInit {

 
  constructor(private router: Router) { }

  ngOnInit(): void {
    var local = localStorage.getItem('id');
   
  }

  onLogout() {
    localStorage.removeItem('id');
    this.router.navigateByUrl('/login');
  }

}