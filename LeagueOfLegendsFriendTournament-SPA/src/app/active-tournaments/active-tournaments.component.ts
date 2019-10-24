import { Component, OnInit, Injectable } from '@angular/core';
import { TournamentInfoComponent } from '../tournament-info/tournament-info.component';
import { DataService } from '../_services/data.service';

@Component({
  selector: 'app-active-tournaments',
  templateUrl: './active-tournaments.component.html',
  styleUrls: ['./active-tournaments.component.css']
})

export class ActiveTournamentsComponent implements OnInit {

  ActiveTournament: any;

  constructor(private dataService: DataService) { }

  ngOnInit() {
    console.log('this' + typeof(this.ActiveTournament));
    this.dataService.currentActiveTournamentData.subscribe(x => this.ActiveTournament = x);
  }

}
