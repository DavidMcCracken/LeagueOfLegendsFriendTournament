/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { RiotGamesService } from './riot-games.service';

describe('Service: RiotGames', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [RiotGamesService]
    });
  });

  it('should ...', inject([RiotGamesService], (service: RiotGamesService) => {
    expect(service).toBeTruthy();
  }));
});
