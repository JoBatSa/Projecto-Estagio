import { TestBed } from '@angular/core/testing';

import { WorkAuthorizationService } from './work-authorization.service';

describe('WorkAuthorizationService', () => {
  let service: WorkAuthorizationService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(WorkAuthorizationService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
