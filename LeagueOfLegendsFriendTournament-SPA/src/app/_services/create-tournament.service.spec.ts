/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { CreateTournamentService } from './create-tournament.service';

describe('Service: CreateTournament', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [CreateTournamentService]
    });
  });

  it('should ...', inject([CreateTournamentService], (service: CreateTournamentService) => {
    expect(service).toBeTruthy();
  }));
});
