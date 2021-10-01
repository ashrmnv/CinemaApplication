import React from 'react';
import CardMedia from "@mui/material/CardMedia";

const MoviePoster = ({id}) =>{
    return (
        <CardMedia
            component="img"
            sx = {{maxHeight: 500, minHeight: 500}}
            alt={"Poster for " + id}
            image={"/data/img/" + id + ".webp"}
        />
    );
}

export default MoviePoster;