import { Component, OnInit } from '@angular/core';
import { CreateTournamentService } from '../_services/create-tournament.service';
import { UserService } from '../_services/user.service';
import { forEach } from '@angular/router/src/utils/collection';
import { Key } from 'protractor';

@Component({
  selector: 'app-join-tournament',
  templateUrl: './join-tournament.component.html',
  styleUrls: ['./join-tournament.component.css']
})
export class JoinTournamentComponent implements OnInit {
  model: any = [];

  constructor(private createTournamentService: CreateTournamentService, private userService: UserService) { }

  ngOnInit() {
    this.retrieveAllActive();
  }

  retrieveAllActive() {
    this.createTournamentService.retrieveJoinTournamentList().subscribe(next => {
      this.model = next;
      console.log(this.model);
    });
  }

}
