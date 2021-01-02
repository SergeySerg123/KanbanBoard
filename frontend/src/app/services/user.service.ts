import { Injectable } from '@angular/core';
import { User } from '../models/User/user';
import { HttpService } from './http.service';

@Injectable({ providedIn: 'root' })
export class UserService {
    public routePrefix = '/api/users';

    constructor(private httpService: HttpService) {}

    public getUserFromToken() {
        return this.httpService.getFullRequest<User>(`${this.routePrefix}/fromToken`);
    }

    public getUserById(id: number) {
        return this.httpService.getFullRequest<User>(`${this.routePrefix}`, { id });
    }

    public updateUser(user: User) {
        return this.httpService.putFullRequest<User>(`${this.routePrefix}`, user);
    }

    public copyUser({ avatar, email, userName, id }: User) {
        return {
            avatar,
            email,
            userName,
            id
        };
    }
}
