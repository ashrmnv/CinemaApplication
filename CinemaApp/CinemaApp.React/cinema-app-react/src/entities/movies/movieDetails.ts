import { Director } from "../directors/director";
import { Actor } from "../actors/actor";


export interface MovieDetails{
    id: number;
    title: string;
    description: string;
    genre: string;
    premiereDate: Date;
    rating: number;
    directorReadDto: Director;
    actors: Actor[];
}
