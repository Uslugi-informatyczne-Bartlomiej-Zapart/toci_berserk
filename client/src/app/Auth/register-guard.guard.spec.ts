import { TestBed } from '@angular/core/testing';

import { RegisterGuardGuard } from './register-guard.guard';

describe('RegisterGuardGuard', () => {
  let guard: RegisterGuardGuard;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    guard = TestBed.inject(RegisterGuardGuard);
  });

  it('should be created', () => {
    expect(guard).toBeTruthy();
  });
});
