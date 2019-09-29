import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { MessagesComponent } from './messages/messages.component';
import { JoinTournamentComponent } from './join-tournament/join-tournament.component';
import { CreateTournamentComponent } from './create-tournament/create-tournament.component';
import { ActiveTournamentsComponent } from './active-tournaments/active-tournaments.component';
import { AuthGuard } from './_guards/auth.guard';

export const appRoutes: Routes = [
    { path: '', component: HomeComponent},
    {
        path: '',
        runGuardsAndResolvers: 'always',
        canActivate: [AuthGuard],
        children: [
            { path: 'messages', component: MessagesComponent},
            { path: 'join-tournament', component: JoinTournamentComponent},
            { path: 'create-tournament', component: CreateTournamentComponent},
            { path: 'active-tournaments', component: ActiveTournamentsComponent},
        ]
    },
    { path: '**', redirectTo: '', pathMatch: 'full'},
];
