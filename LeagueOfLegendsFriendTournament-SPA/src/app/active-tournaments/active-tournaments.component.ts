import { Component, OnInit, Injectable, OnChanges, SimpleChanges } from '@angular/core';
import { TournamentInfoComponent } from '../tournament-info/tournament-info.component';
import { DataService } from '../_services/data.service';
import { CreateTournamentService } from '../_services/create-tournament.service';
import { AuthService } from '../_services/auth.service';
import { isUndefined } from 'util';
import { RiotGamesService } from '../_services/riot-games.service';

@Component({
  selector: 'app-active-tournaments',
  templateUrl: './active-tournaments.component.html',
  styleUrls: ['./active-tournaments.component.css']
})

export class ActiveTournamentsComponent implements OnInit {

  ActiveTournament: any;
  TournamentsUserIsIn: any;
  usernameJson: any = {};
  RiotIdData: any = [];
  RiotMatches: any;
  RiotMatchesDetailed: any;

  constructor(private dataService: DataService, private createTournamentService: CreateTournamentService,
     private authService: AuthService, private riotGames: RiotGamesService) { }

  ngOnInit() {
    this.dataService.currentActiveTournamentData.subscribe(x => this.ActiveTournament = x);
    this.showActiveTournamentsForUser();
  }

  showActiveTournamentsForUser() {
    this.createTournamentService.getActiveTournamentsForUsers({ 'userId': this.authService.decodedToken.nameid}).subscribe(tournaments => {
      this.TournamentsUserIsIn = tournaments;
    });
  }
  displayActiveTournament(tournament: any) {
    this.createTournamentService.retrieveAllUsersInTournament({'tournamentId': tournament.tournamentId}).subscribe(next => {
      this.ActiveTournament = next;
      this.createUsernameJson();

      this.riotGames.getSummonerDataMultiple(this.usernameJson).subscribe( data => {
        this.RiotIdData = data;
        console.log(this.RiotIdData);
        


      });
    });
  }

  createUsernameJson() {
    this.usernameJson.username = [];
    for ( let i = 0; i < this.ActiveTournament.length; i++) {
      this.usernameJson.username.push(this.ActiveTournament[i].username);
    }
  }
}
