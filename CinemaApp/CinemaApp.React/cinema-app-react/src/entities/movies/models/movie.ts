import { Director } from "../../directors/director";
import { Poster } from "../../posters/poster";


export interface Movie{
    id : number;
    title : string;
    genre : string;
    premierDate : Date;
    rating : number;
    directorReadDto : Director;
    posterReadDto : Poster;
}