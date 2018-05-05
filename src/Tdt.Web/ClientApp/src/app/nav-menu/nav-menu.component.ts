import { Component, OnInit } from '@angular/core';
import {LocalStoreManager} from "../services/local-store-manager.service";
import {AuthService} from "../services/auth.service";

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent implements OnInit {

  isAppLoaded: boolean;
  isUserLoggedIn: boolean;

  constructor(storageManager: LocalStoreManager, private authService: AuthService) {
    storageManager.initialiseStorageSyncListener();
  }

  ngOnInit() {
    this.isUserLoggedIn = this.authService.isLoggedIn;

    // 1 sec to ensure all the effort to get the css animation working is appreciated :|, Preboot screen is removed .5 sec later
    setTimeout(() => this.isAppLoaded = true, 1000);

    setTimeout(() => {
      if (this.isUserLoggedIn) {

      }
    }, 2000);

    this.authService.getLoginStatusEvent().subscribe(isLoggedIn => {
      this.isUserLoggedIn = isLoggedIn;

      setTimeout(() => {
        if (!this.isUserLoggedIn) {
        }
      }, 500);
    });
  }

  logout() {
    this.authService.logout();
    this.authService.redirectLogoutUser();
  }
}
