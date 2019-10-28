import { Component, OnInit } from '@angular/core';
import { CreateTournamentService } from '../_services/create-tournament.service';
import { RiotGamesService } from '../_services/riot-games.service';
import { DataService } from '../_services/data.service';

@Component({
  selector: 'app-join-tournament',
  templateUrl: './join-tournament.component.html',
  styleUrls: ['./join-tournament.component.css']
})
export class JoinTournamentComponent implements OnInit {
  model: any = [];
  focusTournament: any = false;
  tournamentInfo: any;

  constructor(private createTournamentService: CreateTournamentService) { }

  ngOnInit() {
    this.retrieveAllActive();
  }

  focusOnTournament(tournament: any) {
    this.tournamentInfo = {'tournamentId': tournament.tournamentId, 'gameType': tournament.gameType,
  'tournamentName': tournament.tournamentName, 'username': tournament.username};
    this.focusTournament = true;
    console.log('tournament: ' + tournament);
  }

  retrieveAllActive() {
    this.createTournamentService.retrieveJoinTournamentList().subscribe(next => {
      this.model = next;
      console.log(this.model);
    });
  }

}
