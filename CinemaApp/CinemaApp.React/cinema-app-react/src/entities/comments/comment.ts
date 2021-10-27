import {User} from "../users/user";

export interface CommentReadDto{
    id : number;
    body : string;
    creatingDate : Date;
    userDto : User;
}