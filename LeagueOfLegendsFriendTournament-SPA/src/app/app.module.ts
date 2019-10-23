import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { BsDropdownModule } from 'ngx-bootstrap';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';
import { NavComponent } from './nav/nav.component';
import { FormsModule } from '@angular/forms';
import { AuthService } from './_services/auth.service';
import { HomeComponent } from './home/home.component';
import { RegisterComponent } from './register/register.component';
import { ErrorInterceptorProvider } from './_services/error.interceptor';
import { AlertifyService } from './_services/alertify.service';
import { JoinTournamentComponent } from './join-tournament/join-tournament.component';
import { MessagesComponent } from './messages/messages.component';
import { appRoutes } from './routes';
import { ActiveTournamentsComponent } from './active-tournaments/active-tournaments.component';
import { AuthGuard } from './_guards/auth.guard';
import { RegisterTournamentComponent } from './register-tournament/register-tournament.component';
import { CreateTournamentService } from './_services/create-tournament.service';
import { TournamentInfoComponent } from './tournament-info/tournament-info.component';
import { RiotGamesService } from './_services/riot-games.service';
import { UserService } from './_services/user.service';
import { DataService } from './_services/data.service';


@NgModule({
   declarations: [
      AppComponent,
      NavComponent,
      HomeComponent,
      RegisterComponent,
      JoinTournamentComponent,
      MessagesComponent,
      ActiveTournamentsComponent,
      RegisterTournamentComponent,
      TournamentInfoComponent
   ],
   imports: [
      BrowserModule,
      HttpClientModule,
      FormsModule,
      BsDropdownModule.forRoot(),
      RouterModule.forRoot(appRoutes)
   ],
   providers: [
      AuthService,
      ErrorInterceptorProvider,
      AlertifyService,
      AuthGuard,
      CreateTournamentService,
      RiotGamesService,
      UserService,
      DataService
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
