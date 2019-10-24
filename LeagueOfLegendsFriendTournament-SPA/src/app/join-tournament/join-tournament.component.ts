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

  constructor(private createTournamentService: CreateTournamentService, private riotGamesService: RiotGamesService, 
    private dataService: DataService) { }

  ngOnInit() {
    this.retrieveAllActive();
  }

  focusOnTournament(tournament: any) {
    this.tournamentInfo = {'tournamentId': tournament.tournamentId, 'gameType': tournament.gameType, 
  'tournamentName': tournament.tournamentName};
    this.focusTournament = true;
  }

  retrieveAllActive() {
    this.createTournamentService.retrieveJoinTournamentList().subscribe(next => {
      this.model = next;
    });
  }

}
