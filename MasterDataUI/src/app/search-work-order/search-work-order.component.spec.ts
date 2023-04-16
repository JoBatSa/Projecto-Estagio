import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SearchWorkOrderComponent } from './search-work-order.component';

describe('SearchWorkOrderComponent', () => {
  let component: SearchWorkOrderComponent;
  let fixture: ComponentFixture<SearchWorkOrderComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SearchWorkOrderComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SearchWorkOrderComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
