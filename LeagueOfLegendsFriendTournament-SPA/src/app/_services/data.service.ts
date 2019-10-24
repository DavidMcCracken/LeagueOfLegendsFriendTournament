import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class DataService {
  private currentActiveTournamentSource = new BehaviorSubject([]);
  currentActiveTournamentData = this.currentActiveTournamentSource.asObservable();

  private currentTournamentNameSource = new BehaviorSubject([]);
  currentTournamentName = this.currentTournamentNameSource.asObservable();

  constructor() {}

  changeCurrentActiveTournamentData(data: any) {
    this.currentActiveTournamentSource.next(data);
  }

  changecurrentTournamentNameSource(data: any) {
    this.currentTournamentNameSource.next(data);
  }
}
