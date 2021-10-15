import React, {FC} from 'react';
import Card from "@mui/material/Card";
import Grid from "@mui/material/Grid";
import MoviePoster from "./movieItemComponents/MoviePoster";
import MovieContent from "./movieItemComponents/MovieContent";
import MovieButtons from "./movieItemComponents/MovieButtons";
import { Movie } from '../entities/movies/movie';

interface MovieProps{
    movie : Movie;
}

const MovieItem : FC<MovieProps> = ({movie}) : JSX.Element =>{
    return (
        <Grid item xs={12} sm={6} md={4} lg={3}>
            <Card>
                <MoviePoster id = {movie.id}/>
                <MovieContent movie = {movie}/>
                <MovieButtons id = {movie.id}/>
            </Card>
        </Grid>
    );
};

export default MovieItem;