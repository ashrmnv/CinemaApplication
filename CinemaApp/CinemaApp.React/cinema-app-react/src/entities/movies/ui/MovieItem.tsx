import React, {FC} from 'react';
import Card from "@mui/material/Card";
import Grid from "@mui/material/Grid";
import MoviePoster from "./components/MoviePoster";
import MovieContent from "./components/MovieContent";
import MovieButtons from "./components/MovieButtons";
import { Movie } from '../models/movie';

interface MovieProps{
    movie : Movie;
}

const MovieItem : FC<MovieProps> = ({movie}) : JSX.Element =>{
    return (
        <Grid item xs={12} sm={6} md={4} lg={3}>
            <Card>
                <MoviePoster poster = {movie.posterReadDto}/>
                <MovieContent movie = {movie}/>
                <MovieButtons id = {movie.id}/>
            </Card>
        </Grid>
    );
};

export default MovieItem;