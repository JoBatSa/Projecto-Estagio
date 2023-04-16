import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SearchWorkOrderDialogComponent } from './search-work-order-dialog.component';

describe('SearchWorkOrderDialogComponent', () => {
  let component: SearchWorkOrderDialogComponent;
  let fixture: ComponentFixture<SearchWorkOrderDialogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SearchWorkOrderDialogComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SearchWorkOrderDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
