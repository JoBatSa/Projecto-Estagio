import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SearchWorkauthorizationComponent } from './search-workauthorization.component';

describe('SearchWorkauthorizationComponent', () => {
  let component: SearchWorkauthorizationComponent;
  let fixture: ComponentFixture<SearchWorkauthorizationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SearchWorkauthorizationComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SearchWorkauthorizationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
