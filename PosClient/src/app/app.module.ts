import {  HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { RestDataService } from './Core/Services/rest.service';
import { DashboardModule } from './dashboard/dashboard.module';
import { FeaturesModule } from './Modules/features.module';
import { LayoutModule } from './Shared/layout/layout.module';
import { JwtModule } from "@auth0/angular-jwt";
import { AuthGuard } from './Shared/guard/auth-guard';


@NgModule({
  declarations: [
    AppComponent,    
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    DashboardModule, 
    LayoutModule,
    FormsModule, HttpClientModule, NgbModule, FeaturesModule, JwtModule
  ],
  providers: [RestDataService, AuthGuard],
  bootstrap: [AppComponent]
})
export class AppModule { }
