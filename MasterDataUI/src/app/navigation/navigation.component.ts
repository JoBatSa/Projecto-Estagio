import { Component, OnInit } from '@angular/core';

import { BreakpointObserver, Breakpoints } from '@angular/cdk/layout';
import { Observable } from 'rxjs';
import { map, shareReplay } from 'rxjs/operators';
import {HostListener} from '@angular/core';

@Component({
  selector: 'app-navigation',
  templateUrl: './navigation.component.html',
  styleUrls: ['./navigation.component.css']
})
export class NavigationComponent implements OnInit {

  appropriateBottomClass:string = '';
  isHandset$: Observable<boolean> = this.breakpointObserver
    .observe(Breakpoints.Handset)
    .pipe(
      map((result) => result.matches),
      shareReplay()
    );

  sections = this.breakpointObserver.observe(Breakpoints.Handset).pipe(
    map(() => {
      return [
        { title: 'menu', route: '/menu' },
        { title: 'Funcionarios', route: '/menuEmployee' },
        { title: 'Cliente', route: '/custumer' },
        { title: 'Registar funconario', route: '/menuRegisterEmployee' },
       /* { title: 'Requests', route: '/requests' },
        { title: '3D Viewer', route: '/visual-model' },
        { title: 'Path Search', route: '/path-search' },
        { title: 'Humor State', route: '/humor-state' },*/
      ];
    })
  );

  @HostListener('window:resize', ['$event'])
  getScreenHeight() {
    if (window.innerHeight <= 305) {
      this.appropriateBottomClass = 'bottomRelative';
    } else {
      this.appropriateBottomClass = 'bottomStick';
    }
  }

  constructor(private breakpointObserver: BreakpointObserver) {
    this.getScreenHeight();
  }

  ngOnInit(): void {
  }

}
