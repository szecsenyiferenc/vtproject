/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { RestBackendService } from './rest-backend.service';

describe('Service: RestBackend', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [RestBackendService]
    });
  });

  it('should ...', inject([RestBackendService], (service: RestBackendService) => {
    expect(service).toBeTruthy();
  }));
});
