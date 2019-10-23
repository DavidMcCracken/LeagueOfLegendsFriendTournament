import { Component, OnInit, Input } from '@angular/core';
import { CreateTournamentService } from '../_services/create-tournament.service';
import { AuthService } from '../_services/auth.service';
import { AlertifyService } from '../_services/alertify.service';

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

  constructor(private createTournamentService: CreateTournamentService, private authService: AuthService,
     private alertify: AlertifyService) { }

  ngOnInit() {
    this.retrieveAllUsersInTournament();
  }

  retrieveAllUsersInTournament() {
    this.tournamentId = {'tournamentId': this.tournamentData.tournamentId};
    this.createTournamentService.retrieveAllUsersInTournament(this.tournamentId).subscribe(next => {
      this.playersData = next;
    });
  }
  joinTournament(){
    this.addingUserToTournament = {'tournamentId': this.tournamentData.tournamentId,
     'personJoiningTournament': this.authService.decodedToken.nameid};
    this.createTournamentService.addUser(this.addingUserToTournament).subscribe(next =>{
      this.alertify.success('Joined Tournament!');
    }, error => {
      this.alertify.error(error);
    });

  }

}
