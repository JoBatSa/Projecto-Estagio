import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateVisualAidComponent } from './create-visual-aid.component';

describe('CreateVisualAidComponent', () => {
  let component: CreateVisualAidComponent;
  let fixture: ComponentFixture<CreateVisualAidComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CreateVisualAidComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CreateVisualAidComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
