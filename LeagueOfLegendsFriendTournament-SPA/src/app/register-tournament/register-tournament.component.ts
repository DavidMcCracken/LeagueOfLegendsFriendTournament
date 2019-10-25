import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { AlertifyService } from '../_services/alertify.service';
import { CreateTournamentService } from '../_services/create-tournament.service';
import { AuthService } from '../_services/auth.service';
import { e } from '@angular/core/src/render3';
import { isUndefined } from 'util';

@Component({
  selector: 'app-register-tournament',
  templateUrl: './register-tournament.component.html',
  styleUrls: ['./register-tournament.component.css']
})
export class RegisterTournamentComponent implements OnInit {
  @Output() cancelRegister = new EventEmitter();
  model: any = {};
  createUser: any = {};
  gameTypes: string[] = ['MOST_KILLS', 'MOST_DEATHS', 'LEAST_DEATHS', 'MOST_ASSISTS', 'LONGEST_LIVING_SPREE', 'LARGEST_KILLING_SPREE',
  'MOST_GOLD_EARNED', 'MOST_TOTAL_DAMAGE_DEALT', 'LARGEST_VISION_SCORE', 'BEST_KDA_CHAMP_SPECIFIC', 'BEST_KDA_ROLE_SPECIFIC'
];
  createdTournament: any;
  createdUser: any;

  constructor(public authService: AuthService, private createTournamentService: CreateTournamentService,
    private alertify: AlertifyService) { }

  ngOnInit() {

  }

  create() {
    this.model.CreaterOfTournament = this.authService.decodedToken.nameid;
    this.model.active = 1;
    this.createTournamentService.create(this.model).subscribe(next => {
      this.createdTournament = next;
      this.createUser = {'tournamentId': this.createdTournament.tournamentId, 'PersonJoiningTournament': this.model.CreaterOfTournament};
         this.createTournamentService.addUser(this.createUser).subscribe(next => {
          this.createdUser = next;
        if(isUndefined(this.createdUser)){
          this.alertify.error('Tournament is already made');

        } else {
          this.alertify.success('Thank you for registering');

      }
        });
        
    });
  }

  cancel() {
    this.cancelRegister.emit(false);
  }
}
