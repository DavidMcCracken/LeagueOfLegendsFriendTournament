import { Component, OnInit } from '@angular/core';
import { CreateTournamentService } from '../_services/create-tournament.service';
import { UserService } from '../_services/user.service';
import { forEach } from '@angular/router/src/utils/collection';
import { Key } from 'protractor';
import { RiotGamesService } from '../_services/riot-games.service';

@Component({
  selector: 'app-join-tournament',
  templateUrl: './join-tournament.component.html',
  styleUrls: ['./join-tournament.component.css']
})
export class JoinTournamentComponent implements OnInit {
  model: any = [];
  focusTournamentUsername: any = {};
  focusTournament: any = false;
  final: any = [];

  constructor(private createTournamentService: CreateTournamentService, private riotGamesService: RiotGamesService) { }

  ngOnInit() {
    this.retrieveAllActive();
  }

  focusOnTournament(username: any) {
    this.focusTournamentUsername = {'Username': username };
    this.focusTournament = true;
    this.riotGamesService.GetSummonerData(this.focusTournamentUsername).subscribe(next => {
      this.final = next;
      console.log(this.final);
    });
  }

  retrieveAllActive() {
    this.createTournamentService.retrieveJoinTournamentList().subscribe(next => {
      this.model = next;
    });
  }

}
