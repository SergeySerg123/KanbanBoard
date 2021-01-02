import { User } from '../../models/User/user';
import { AccessTokenDto } from '../../models/token/access-token-dto';

export interface AuthUser {
    user: User;
    token: AccessTokenDto;
}