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
  Json: any = {};
  RiotIdData: any = [];
  RiotMatches: any;
  RiotMatchesDetailed: any;
  compiledData: any = [];

  constructor(private dataService: DataService, private createTournamentService: CreateTournamentService,
     private authService: AuthService, private riotGames: RiotGamesService) { }

  ngOnInit() {
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
      this.riotGames.getSummonerDataMultiple(this.Json).subscribe( data => {
        this.RiotIdData = data;
        this.createAccountIdJson(tournament);
        this.riotGames.getMatchesBasedOffDateTimeMultiple(this.Json.users).subscribe( games => {
          this.RiotMatches = games;
          this.createMatchIdJson(this.RiotMatches);
          this.riotGames.getMatchesDetailsMultiple(this.Json.matchId).subscribe( details => {
            this.RiotMatchesDetailed = details;
            this.compiledDataFinish();
          })
        })
      });
    });
  }

  createUsernameJson() {
    this.Json.username = [];
    for ( let i = 0; i < this.ActiveTournament.length; i++) {
      this.Json.username.push(this.ActiveTournament[i].username);
      this.compiledData.push({username: this.ActiveTournament[i].username});
    }
  }

  createAccountIdJson(tournament: any) {
    this.Json.users = [];
    const startTime = (new Date(tournament.startTime.replace('-', '/').replace('T', ' '))).getTime();
    const endTime = (new Date(tournament.endTime.replace('-', '/').replace('T', ' '))).getTime();
    for ( let i = 0; i < this.RiotIdData.length; i++) {
      this.Json.users.push({accountid: this.RiotIdData[i].accountId, begintime: startTime,
         endtime: endTime});
      this.compiledData[i].accountid = this.RiotIdData[i].accountId;
    }

  }
  createMatchIdJson(riotMatches: any) {
    this.Json.matchId = [];


    for ( let i = 0; i < this.RiotMatches.length; i++) {
      this.compiledData[i].matchIds = [];
      for ( let j = 0; j < this.RiotMatches[i].matches.length; j++){
        this.Json.matchId.push({matchId: this.RiotMatches[i].matches[j].gameId});
        this.compiledData[i].matchIds.push({matchId: this.RiotMatches[i].matches[j].gameId});
      }
    }
  }

  compiledDataFinish() {
    console.log(this.compiledData);
    console.log(this.RiotMatchesDetailed);
    for ( let i = 0; i < this.compiledData.length; i++) {
      for( let j = 0; j < this.compiledData[i].matchIds.length; j++) {
        for ( let k = 0; k < this.RiotMatchesDetailed.length; k++) {
          console.log('compare compiled: ' + this.compiledData[i].matchIds[j].matchId
           + 'uncompiled: ' + this.RiotMatchesDetailed[k].gameId);
          if (this.compiledData[i].matchIds[j].matchId === this.RiotMatchesDetailed[k].gameId) {
            this.compiledData[i].matchIds[j].MatchDetails = this.RiotMatchesDetailed[k];
            break;
          }
        }
      }
    }
    console.log(this.compiledData);
  }
}
