import { Director } from "../directors/director";

export interface Movie{
    id : number;
    title : string;
    genre : string;
    premierDate : Date;
    rating : number;
    director : Director;
}