import React, {FC} from 'react';
import CardMedia from "@mui/material/CardMedia";

interface PosterProps{
    id : number;
}
const MoviePoster : FC<PosterProps> = ({id}) : JSX.Element =>{
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