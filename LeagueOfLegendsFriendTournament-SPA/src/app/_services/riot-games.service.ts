import { Injectable } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class RiotGamesService {
  baseUrl = 'http://localhost:5000/api/riotgames/';
  jwtHelper = new JwtHelperService();
constructor(private http: HttpClient) { }



  GetSummonerData(model: any) {
    let headers = new HttpHeaders();
    headers = headers.set('Content-Type', 'application/json; charset=utf-8');
    return this.http.post(this.baseUrl + 'getsummonerdata', model);
  }

  getMatchesBasedOffDateTime(model: any) {
    return this.http.get(this.baseUrl + 'getmatchesbasedoffdatetime', model);
  }

  getMatchesBasedOffDateTimeMultiple(model: any) {
    return this.http.post(this.baseUrl + 'getmatchesbasedoffdatetimemultiple', model);
  }

  getMatchesDetails(model: any) {
    return this.http.get(this.baseUrl + 'getmatchesdetails', model);
  }

  getSummonerDataMultiple(model: any) {
    return this.http.post(this.baseUrl + 'getsummonerdatamultiple', model);
  }
  getMatchesDetailsMultiple(model: any) {
    return this.http.post(this.baseUrl + 'getmatchdetailsmultiple', model);
  }


}
