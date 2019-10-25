import { Component, OnInit, Input, Injectable } from '@angular/core';
import { CreateTournamentService } from '../_services/create-tournament.service';
import { AuthService } from '../_services/auth.service';
import { AlertifyService } from '../_services/alertify.service';
import { Router } from '@angular/router';
import { DataService } from '../_services/data.service';
import { isUndefined } from 'util';

@Component({
  selector: 'app-tournament-info',
  templateUrl: './tournament-info.component.html',
  styleUrls: ['./tournament-info.component.css']
})
export class TournamentInfoComponent implements OnInit {
  @Input() tournamentData: any;
  tournamentId: any;
  addingUserToTournament: any;
  playersData: any = [];
  dataToBeTransfered: any;
  

  constructor(private createTournamentService: CreateTournamentService, private authService: AuthService,
     private alertify: AlertifyService, private router: Router, private dataService: DataService) { }

  ngOnInit() {
    this.retrieveAllUsersInTournament();
  }

  retrieveAllUsersInTournament() {
    this.tournamentId = {'tournamentId': this.tournamentData.tournamentId};
    this.createTournamentService.retrieveAllUsersInTournament(this.tournamentId).subscribe(next => {
      this.playersData = next;
    });
  }

  test() {
    this.playersData.tournamentName = this.tournamentData.tournamentName;
    this.dataService.changeCurrentActiveTournamentData(this.playersData);
    this.router.navigate(['/active-tournaments']);

  }
  joinTournament() {
    this.addingUserToTournament = {'tournamentId': this.tournamentData.tournamentId,
     'personJoiningTournament': this.authService.decodedToken.nameid};
    this.createTournamentService.addUser(this.addingUserToTournament).subscribe(next => {
      let user: any;
      user = next;
      if (!isUndefined(user)) {
        this.alertify.success('Joined Tournament!');
      this.playersData.tournamentName = this.tournamentData.tournamentName;
      this.dataService.changeCurrentActiveTournamentData(this.playersData);
      this.router.navigate(['/active-tournaments']);
      } else {
        this.alertify.error('Something went wrong');
      }
    });

  }

}
