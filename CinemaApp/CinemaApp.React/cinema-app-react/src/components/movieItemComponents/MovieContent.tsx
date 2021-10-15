import React,{FC} from 'react';
import CardContent from "@mui/material/CardContent";
import Typography from "@mui/material/Typography";
import MovieRating from "./MovieRating";
import { Movie } from '../../entities/movies/movie';

interface MovieProps{
    movie : Movie;
}
const MovieContent : FC<MovieProps> = ({movie}) : JSX.Element => {
    return (
        <CardContent>
            <Typography gutterBottom variant="h5" component="div">
                {movie.id}. {movie.title}
            </Typography>
            <Typography variant="body2" color="text.secondary">
                {movie.directorReadDto.firstName}, {movie.genre}
            </Typography>
            <MovieRating rating={movie.rating}/>
        </CardContent>
    );
};

export default MovieContent;