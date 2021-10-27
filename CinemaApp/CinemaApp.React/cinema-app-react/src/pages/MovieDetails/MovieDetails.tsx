import React, { FC, useEffect, useState, useContext } from 'react';
import {useParams} from 'react-router-dom';
import { MovieDetails } from '../../entities/movies/models/movieDetails';
import {AuthContext} from '../../app/App';
import ActorItem from './MovieInfo/ui/ActorItem';
import Grid from '@mui/material/Grid';
import Divider from '@mui/material/Divider';
import CircularProgress from  "@mui/material/CircularProgress";
import Box from "@mui/material/Box";
import MovieRating from "./MovieInfo/ui/MovieRating";
import AddInWaitingIcon from "./MovieInfo/ui/AddInWaitingIcon";
import {getMovie} from "./MovieInfo/model/getMovie";
import CommentsList from "./Comments/CommentsList";
import SessionsList from "./Sessions/SessionsList";
import MovieInfo from "./MovieInfo/MovieInfo";

const MovieDetailsPage: FC = () : JSX.Element => {
    const params = useParams();
    const [movie, setMovie] = useState<MovieDetails>({} as MovieDetails);
    const [premiereDate, setPremiereDate] = useState<Date>({} as Date)

    const [isLoading, setIsLoading] = useState(true);
    const {isAuth, token} = useContext(AuthContext);
    const [isRated, setIsRated] = useState<number>(0);

    useEffect(() => {
        getMovie(setIsLoading, setMovie, setPremiereDate, params.id);
    }, [isRated]);


    if (isLoading) {
        return (
            <Box sx={{display: 'flex', flexDirection: 'column', alignItems: 'center', mt: 20}}>
                <CircularProgress/>
            </Box>
        );
    } else {
        return (
            <div className="MovieList">
                <h1 style={{display : "flex", justifyContent : "center"}}>{movie.title}</h1>
                <Grid container spacing={2} sx={{mt : 2}}>
                    <Grid item>
                        <img src={movie.posterReadDto !== null ? "/data/img/" + movie.posterReadDto.path : "/data/img/default.jpg"} alt="alt"
                             style={{maxHeight: 500, minHeight: 500}}/>
                    </Grid>
                    <Grid item xs={12} sm container>
                        <Grid item xs container direction="column" spacing={2}>
                            <MovieInfo movie={movie} setIsRated = {setIsRated} />
                            <Grid item container>
                                <Divider>SESSIONS</Divider>
                                <SessionsList movieId={params.id}/>
                            </Grid>
                        </Grid>
                    </Grid>
                </Grid>
                <Grid container spacing ={2}>
                    <Grid item xs={12}>
                        <h2 style ={{display : "flex", justifyContent : "center"}}>Comments</h2>
                    </Grid>
                    <Grid item xs={12}>
                        <CommentsList movieId={params.id}/>
                    </Grid>
                </Grid>
            </div>
        );
    }
}
export default MovieDetailsPage;
                    
                
            