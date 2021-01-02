import { HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { UserLoginDto } from '../models/Auth/user-login-dto';
import { UserRegisterDto } from '../models/Auth/user-register-dto';
import { AccessTokenDto } from '../models/Token/access-token-dto';
import { User } from '../models/User/user';
import { map } from 'rxjs/operators';
import { EventService } from './event.service';
import { HttpService } from './http.service';
import { UserService } from './user.service';
import { AuthUser } from '../models/Auth/auth-user';

@Injectable({ providedIn: 'root' })
export class AuthenticationService {
    public routePrefix = '/api';
    private user: User;

    constructor(
        private httpService: HttpService, 
        private userService: UserService, 
        private eventService: EventService
    ) {}

    public getUser() {
        return this.user
            ? of(this.user)
            : this.userService.getUserFromToken().pipe(
                  map((resp) => {
                      this.user = resp.body;
                      this.eventService.userChanged(this.user);
                      return this.user;
                  })
              );
    }

    public setUser(user: User) {
        this.user = user;
        this.eventService.userChanged(user);
    }

    public register(user: UserRegisterDto) {
        return this._handleAuthResponse(this.httpService.postFullRequest<AuthUser>(`${this.routePrefix}/register`, user));
    }

    public login(user: UserLoginDto) {
        return this._handleAuthResponse(this.httpService.postFullRequest<AuthUser>(`${this.routePrefix}/auth/login`, user));
    }

    public logout() {
        this.revokeRefreshToken();
        this.removeTokensFromStorage();
        this.user = undefined;
        this.eventService.userChanged(undefined);
    }

    public areTokensExist() {
        return localStorage.getItem('accessToken') && localStorage.getItem('refreshToken');
    }

    public revokeRefreshToken() {
        return this.httpService.postFullRequest<AccessTokenDto>(`${this.routePrefix}/token/revoke`, {
            refreshToken: localStorage.getItem('refreshToken')
        });
    }

    public removeTokensFromStorage() {
        localStorage.removeItem('accessToken');
        localStorage.removeItem('refreshToken');
        localStorage.removeItem('confirmToken');
    }

    public refreshTokens() {
        return this.httpService
            .postFullRequest<AccessTokenDto>(`${this.routePrefix}/token/refresh`, {
                accessToken: JSON.parse(localStorage.getItem('accessToken')),
                refreshToken: JSON.parse(localStorage.getItem('refreshToken'))
            })
            .pipe(
                map((resp) => {
                    this._setTokens(resp.body);
                    return resp.body;
                })
            );
    }

    public get accessToken() {
        return localStorage.getItem('accessToken');
    }

    public get confirmToken() {
        return localStorage.getItem('confirmToken');
    }

    public setConfirmToken(confirmToken: string) {
        localStorage.setItem("confirmToken", confirmToken);
    }

    private _handleAuthResponse(observable: Observable<HttpResponse<AuthUser>>) {
        return observable.pipe(
            map((resp) => {
                this._setTokens(resp.body.token);
                this.user = resp.body.user;
                this.eventService.userChanged(resp.body.user);
                return resp.body.user;
            })
        );
    }

    

    private _setTokens(tokens: AccessTokenDto) {
        if (tokens && tokens.accessToken && tokens.refreshToken) {
            localStorage.setItem('accessToken', JSON.stringify(tokens.accessToken.token));
            localStorage.setItem('refreshToken', JSON.stringify(tokens.refreshToken));
            this.getUser();
        }
    }
}
