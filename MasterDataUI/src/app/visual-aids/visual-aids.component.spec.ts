import { ComponentFixture, TestBed } from '@angular/core/testing';

import { VisualAidsComponent } from './visual-aids.component';

describe('VisualAidsComponent', () => {
  let component: VisualAidsComponent;
  let fixture: ComponentFixture<VisualAidsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ VisualAidsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(VisualAidsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
