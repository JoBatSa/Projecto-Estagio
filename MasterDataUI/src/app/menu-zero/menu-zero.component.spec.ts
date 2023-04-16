import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MenuZeroComponent } from './menu-zero.component';

describe('MenuZeroComponent', () => {
  let component: MenuZeroComponent;
  let fixture: ComponentFixture<MenuZeroComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MenuZeroComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MenuZeroComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
