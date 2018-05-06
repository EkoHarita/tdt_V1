import { Component, OnInit, OnDestroy, ViewChild } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import 'rxjs/add/operator/switchMap';
import { AccountService } from "../../services/account.service";
import { Permission } from '../../models/permission.model';


@Component({
  selector: 'settings',
  templateUrl: './settings.component.html',
  styleUrls: ['./settings.component.css']
})
export class SettingsComponent implements OnInit, OnDestroy {

  isProfileActivated = true;
  isPreferencesActivated = false;
  isUsersActivated = false;
  isRolesActivated = false;

  readonly profileTab = "profile";
  readonly preferencesTab = "preferences";
  readonly usersTab = "users";
  readonly rolesTab = "roles";

  constructor(private route: ActivatedRoute, private accountService: AccountService) {
  }


  ngOnInit() {
    // this.fragmentSubscription = this.route.fragment.subscribe(anchor => this.showContent(anchor));
  }


  ngOnDestroy() {
    // this.fragmentSubscription.unsubscribe();
  }

  get canViewUsers() {
    return this.accountService.userHasPermission(Permission.viewUsersPermission);
  }

  get canViewRoles() {
    return this.accountService.userHasPermission(Permission.viewRolesPermission);
  }
}
