import { TestBed } from '@angular/core/testing';

import { NamedListService } from './named-list.service';

describe('NamedListService', () => {
  let service: NamedListService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(NamedListService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
