import { BrowserModule } from '@angular/platform-browser';
import { NgModule, ErrorHandler } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { NgxDatatableModule } from '@swimlane/ngx-datatable';

import { AppErrorHandler } from './app-error.handler';
import { ConfigurationService } from './services/configuration.service';
import { AlertService } from './services/alert.service';
import { LocalStoreManager } from './services/local-store-manager.service';
import { EndpointFactory } from './services/endpoint-factory.service';
import { AccountService } from './services/account.service';
import { AccountEndpoint } from './services/account-endpoint.service';
import { AuthService } from './services/auth.service';
import { AuthGuard } from './services/auth-guard.service';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { LoginComponent } from './components/login/login.component';
import {SettingsComponent} from "./components/settings/settings.component";
import {UserInfoComponent} from "./components/settings/user-info.component";
import {BootstrapSelectDirective} from "./directives/bootstrap-select.directive";
import {UserPreferencesComponent} from "./components/settings/user-preferences.component";
import {UsersManagementComponent} from "./components/settings/users-management.component";

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    NavMenuComponent,
    HomeComponent,
    FetchDataComponent,
    SettingsComponent,
    UserInfoComponent,
    UserPreferencesComponent,
    UsersManagementComponent,
    BootstrapSelectDirective
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'login', component: LoginComponent },
      { path: "settings", component: SettingsComponent, canActivate: [AuthGuard], data: { title: "Settings" } },
      { path: 'fetch-data', component: FetchDataComponent },
    ]),
    NgbModule.forRoot(),
    NgxDatatableModule
  ],
  providers: [
    { provide: 'BASE_URL', useFactory: getBaseUrl },
    { provide: ErrorHandler, useClass: AppErrorHandler },
    AlertService,
    ConfigurationService,
    LocalStoreManager,
    AuthService,
    AuthGuard,
    EndpointFactory,
    AccountService,
    AccountEndpoint
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }


export function getBaseUrl() {
  return document.getElementsByTagName('base')[0].href;
}
