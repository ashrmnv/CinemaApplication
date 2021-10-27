import { Director } from "../../directors/director";
import { Actor } from "../../actors/actor";
import { Poster } from "../../posters/poster";


export interface MovieDetails{
    id: number;
    title: string;
    description: string;
    genre: string;
    premiereDate: Date;
    ratingsSum: number;
    ratingsNumber: number;
    directorReadDto: Director;
    posterReadDto : Poster;
    actors: Actor[];
}
