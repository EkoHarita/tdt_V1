import { Injectable } from '@angular/core';

import { LocalStoreManager } from './local-store-manager.service';
import { DBkeys } from './db-keys';
import { Utilities } from './utilities';
import { environment } from '../../environments/environment';

type UserConfiguration = {
    homeUrl: string,
};

@Injectable()
export class ConfigurationService {

    public static readonly appVersion: string = "1.0";

    public baseUrl = environment.baseUrl || Utilities.baseUrl();
    public loginUrl = environment.loginUrl;
    public fallbackBaseUrl = "http://localhost:5000";

    public static readonly defaultHomeUrl: string = "/";

    private _homeUrl: string = null;

    constructor(private localStorage: LocalStoreManager) {
        this.loadLocalChanges();
    }

    private loadLocalChanges() {

        if (this.localStorage.exists(DBkeys.HOME_URL))
            this._homeUrl = this.localStorage.getDataObject<string>(DBkeys.HOME_URL);
    }

    private saveToLocalStore(data: any, key: string) {
        setTimeout(() => this.localStorage.savePermanentData(data, key));
    }

    public import(jsonValue: string) {

        this.clearLocalChanges();

        if (!jsonValue)
            return;

        let importValue: UserConfiguration = Utilities.JSonTryParse(jsonValue);

        if (importValue.homeUrl != null)
            this.homeUrl = importValue.homeUrl;
    }

    public export(changesOnly = true): string {

        let exportValue: UserConfiguration =
            {
                homeUrl: changesOnly ? this._homeUrl : this.homeUrl
            };

        return JSON.stringify(exportValue);
    }

    public clearLocalChanges() {
        this._homeUrl = null;
        this.localStorage.deleteData(DBkeys.HOME_URL);
    }

    set homeUrl(value: string) {
        this._homeUrl = value;
        this.saveToLocalStore(value, DBkeys.HOME_URL);
    }

    get homeUrl() {
        if (this._homeUrl != null)
            return this._homeUrl;

        return ConfigurationService.defaultHomeUrl;
    }
}
