import { TestBed } from '@angular/core/testing';

import { RequistionApiService } from './requistion-api.service';

describe('RequistionApiService', () => {
  let service: RequistionApiService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(RequistionApiService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
