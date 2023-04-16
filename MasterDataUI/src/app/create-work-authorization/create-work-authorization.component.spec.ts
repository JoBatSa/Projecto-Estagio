import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateWorkAuthorizationComponent } from './create-work-authorization.component';

describe('CreateWorkAuthorizationComponent', () => {
  let component: CreateWorkAuthorizationComponent;
  let fixture: ComponentFixture<CreateWorkAuthorizationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CreateWorkAuthorizationComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CreateWorkAuthorizationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
