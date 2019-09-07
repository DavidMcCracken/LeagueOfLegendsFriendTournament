import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-tournament',
  templateUrl: './tournament.component.html',
  styleUrls: ['./tournament.component.css']
})
export class TournamentComponent implements OnInit {
  values: any;

  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.getTournaments();
  }

  getTournaments(){
    this.http.get('http://localhost:5000/api/values').subscribe(response =>{
      this.values = response;
    }, error =>{
      console.log(error);
    });
  }

}
