import React, {FC} from 'react';
import CardMedia from "@mui/material/CardMedia";
import { Poster } from '../../../posters/poster';


interface PosterProps{
    poster : Poster;
}
const MoviePoster : FC<PosterProps> = ({poster}) : JSX.Element =>{
    if (poster === null){
        return (
        <CardMedia
            component="img"
            sx = {{maxHeight: 500, minHeight: 500}}
            alt={"Poster for this movie doesn't exists"}
            image={"/data/img/default.jpg"}
        />
        );
    }
    else{
        return (
            <CardMedia
                component="img"
                sx = {{maxHeight: 500, minHeight: 500}}
                alt={"Poster doesn't found"}
                image={"/data/img/" + poster.path}
            />
        );
    }
}

export default MoviePoster;