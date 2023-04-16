import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SearchVisualAidComponent } from './search-visual-aid.component';

describe('SearchVisualAidComponent', () => {
  let component: SearchVisualAidComponent;
  let fixture: ComponentFixture<SearchVisualAidComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SearchVisualAidComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SearchVisualAidComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
