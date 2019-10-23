import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { AlertifyService } from '../_services/alertify.service';
import { CreateTournamentService } from '../_services/create-tournament.service';
import { AuthService } from '../_services/auth.service';

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

  constructor(public authService: AuthService, private createTournamentService: CreateTournamentService,
    private alertify: AlertifyService) { }

  ngOnInit() {

  }

  create() {
    this.model.CreaterOfTournament = this.authService.decodedToken.nameid;
    this.model.active = 1;
    this.createTournamentService.create(this.model).subscribe(() => {
      this.createUser = {'tournamentName': this.model.tournamentName, 'CreaterOfTournament': this.model.CreaterOfTournament};
      if (this.createUser.CreaterOfTournament != null) {
        this.createTournamentService.addUser(this.createUser).subscribe();
      }
      this.alertify.success('Thank you for registering');
    }, error => {
        this.alertify.error(error);
    });
  }

  cancel() {
    this.cancelRegister.emit(false);
  }
}
