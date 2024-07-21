import { Routes } from '@angular/router';
import { AppComponent } from './app.component';
import { Component } from '@angular/core';
import { WelcomeComponent } from './welcome/welcome.component';
import { NotFoundComponent } from './not-found/not-found.component';
import { DirectComponent } from './direct/direct.component';
import { RegisterComponent } from './register/register.component';

export const routes: Routes = [
    {path: 'welcome', component: WelcomeComponent},
    {path: 'direct', component: DirectComponent},
    {path: 'register', component: RegisterComponent},
    {path: '**', component: NotFoundComponent}
];
