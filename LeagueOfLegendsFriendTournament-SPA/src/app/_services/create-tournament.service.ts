import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { JwtHelperService } from '@auth0/angular-jwt';

@Injectable({
  providedIn: 'root'
})
export class CreateTournamentService {
  baseUrl = 'http://localhost:5000/api/tournament/';
  jwtHelper = new JwtHelperService();

constructor(private http: HttpClient) { }

  create(model: any){
    return this.http.post(this.baseUrl + 'create', model);

  }
  retrieveAllActive() {
    return this.http.get(this.baseUrl + 'retrieve-all-active');
  }

  retrieveJoinTournamentList() {
    return this.http.get(this.baseUrl + 'jointournamentlist');
  }


}
