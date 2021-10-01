import React from 'react';
import CardContent from "@mui/material/CardContent";
import Typography from "@mui/material/Typography";
import MovieRating from "./MovieRating";

const MovieContent = (info) => {
    return (
        <CardContent>
            <Typography gutterBottom variant="h5" component="div">
                {info.id}. {info.title}
            </Typography>
            <Typography variant="body2" color="text.secondary">
                {info.director}, {info.genre}
            </Typography>
            <MovieRating rating={info.rating}/>
        </CardContent>
    );
};

export default MovieContent;