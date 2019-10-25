import { Component, OnInit, Injectable, OnChanges, SimpleChanges } from '@angular/core';
import { TournamentInfoComponent } from '../tournament-info/tournament-info.component';
import { DataService } from '../_services/data.service';
import { CreateTournamentService } from '../_services/create-tournament.service';
import { AuthService } from '../_services/auth.service';
import { isUndefined } from 'util';

@Component({
  selector: 'app-active-tournaments',
  templateUrl: './active-tournaments.component.html',
  styleUrls: ['./active-tournaments.component.css']
})

export class ActiveTournamentsComponent implements OnInit {

  ActiveTournament: any;
  TournamentsUserIsIn: any;
  RiotIdData: any;
  RiotMatches: any;
  RiotMatchesDetailed: any;

  constructor(private dataService: DataService, private createTournamentService: CreateTournamentService,
     private authService: AuthService) { }

  ngOnInit() {
    this.dataService.currentActiveTournamentData.subscribe(x => this.ActiveTournament = x);
    this.showActiveTournamentsForUser();
  }

  showActiveTournamentsForUser() {
    this.createTournamentService.getActiveTournamentsForUsers({ 'userId': this.authService.decodedToken.nameid}).subscribe(tournaments => {
      this.TournamentsUserIsIn = tournaments;
    });
  }
}
