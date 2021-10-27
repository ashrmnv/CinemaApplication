import React,{FC} from 'react';
import CardContent from "@mui/material/CardContent";
import Typography from "@mui/material/Typography";
import { Movie } from '../../models/movie';

interface MovieProps{
    movie : Movie;
}
const MovieContent : FC<MovieProps> = ({movie}) : JSX.Element => {
    return (
        <CardContent>
            <Typography gutterBottom variant="h5" component="div">
                {movie.title}
            </Typography>
            <Typography variant="body2" color="text.secondary">
                {movie.genre}
            </Typography>
        </CardContent>
    );
};

export default MovieContent;