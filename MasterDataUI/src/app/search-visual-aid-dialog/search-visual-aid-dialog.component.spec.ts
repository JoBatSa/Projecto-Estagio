import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SearchVisualAidDialogComponent } from './search-visual-aid-dialog.component';

describe('SearchVisualAidDialogComponent', () => {
  let component: SearchVisualAidDialogComponent;
  let fixture: ComponentFixture<SearchVisualAidDialogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SearchVisualAidDialogComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SearchVisualAidDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
