import React, {FC, useContext, useState, useEffect} from 'react';
import Grid from "@mui/material/Grid";
import Divider from "@mui/material/Divider";
import MovieRating from "./ui/MovieRating";
import AddInWaitingIcon from "./ui/AddInWaitingIcon";
import ActorItem from "./ui/ActorItem";
import {getMovie} from "./model/getMovie";
import {MovieDetails} from "../../../entities/movies/models/movieDetails";
import {AuthContext} from "../../../app/App";
import Box from "@mui/material/Box";
import CircularProgress from "@mui/material/CircularProgress";

interface MovieProps{
    movie : MovieDetails;
    setIsRated : React.Dispatch<React.SetStateAction<number>>;
}
const MovieInfo : FC<MovieProps> = ({movie, setIsRated}) : JSX.Element => {
    const [premiereDate, setPremiereDate] = useState<Date>({} as Date)
    const {isAuth, token} = useContext(AuthContext);

    const date = new Date();
    const date2 = new Date(movie.premiereDate);
    const itemStyle = {
        padding : "10px"
    }
        return (
            <Grid item>
                        <Grid item>
                            <p style={itemStyle}>Genres: {movie.genre}</p>
                            <Divider>DIRECTOR</Divider>
                            <p  style={itemStyle}>{movie.directorReadDto.firstName} {movie.directorReadDto.lastName}</p>
                            <Divider>DESCRIPTION</Divider>
                            <p  style={itemStyle}>{movie.description}</p>
                            <Divider>RATING</Divider>
                            {
                                date2.getTime() <= date.getTime()
                                    ?
                                    <MovieRating
                                        ratingNumber={movie.ratingsNumber}
                                        ratingSum={movie.ratingsSum}
                                        setIsRated = {setIsRated}
                                    />
                                    :
                                    <AddInWaitingIcon/>
                            }
                        </Grid>
                        <Grid item>
                            <Divider>ACTORS</Divider>
                            {movie.actors.map(actor => (
                                    <ActorItem actor={actor} key={actor.id}/>
                                )
                            )}
                        </Grid>
                    </Grid>
        );
};

export default MovieInfo;