import { TestBed } from '@angular/core/testing';

import { VisualAidService } from './visual-aid.service';

describe('VisualAidService', () => {
  let service: VisualAidService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(VisualAidService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
