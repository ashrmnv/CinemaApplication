import React from 'react';
import Card from "@mui/material/Card";
import Grid from "@mui/material/Grid";
import MoviePoster from "./movieItemComponents/MoviePoster";
import MovieContent from "./movieItemComponents/MovieContent";
import MovieButtons from "./movieItemComponents/MovieButtons";

const MovieItem = ({info}) => {
    return (
        <Grid item xs={12} sm={6} md={4} lg={3}>
            <Card>
                <MoviePoster id = {info.id}/>
                <MovieContent {...info}/>
                <MovieButtons/>
            </Card>
        </Grid>
    );
};

export default MovieItem;