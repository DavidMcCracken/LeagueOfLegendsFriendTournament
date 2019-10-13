import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  baseUrl = 'http://localhost:5000/api/user/';

constructor(private http: HttpClient) { }

  getUser(user: any) {
    return this.http.get(this.baseUrl + 'user/' + user);
  }

}
