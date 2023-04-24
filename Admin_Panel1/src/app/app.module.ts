import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';


import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavbarComponent } from './navbar/navbar.component';

import { BodyComponent } from './body/body.component';
import { ReactiveFormsModule } from '@angular/forms';
import { RequsitionFormComponent } from './requsition-form/requsition-form.component';
import { RequistionRequestsComponent } from './requistion-requests/requistion-requests.component';
import { RegisterdFormComponent } from './registerd-form/registerd-form.component';
import { BudgetAllocatorComponent } from './budget-allocator/budget-allocator.component';
import { AcquisitionTeamComponent } from './acquisition-team/acquisition-team.component';
import { HomeComponent } from './home/home.component';
import { ViewComponent } from './view/view.component';

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    BodyComponent,
    RequsitionFormComponent,
    RequistionRequestsComponent,
    RegisterdFormComponent,
    BudgetAllocatorComponent,
    AcquisitionTeamComponent,
    HomeComponent,
    ViewComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    HttpClientModule

  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
