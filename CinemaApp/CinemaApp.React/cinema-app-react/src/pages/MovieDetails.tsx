import React, { FC, useEffect, useState } from 'react';
import {useParams} from 'react-router-dom';
import { MovieDetails } from '../entities/movies/movieDetails';
import { CommentReadDto } from '../entities/comments/comment';

import {getMovieDetails} from "../services/MovieService";
import {showPaginatedComments} from "../services/CommentService";

import {PaginatedResult} from "../shared/PaginatedResult";

import CircularProgress from  "@mui/material/CircularProgress";
import Box from "@mui/material/Box";

const MovieDetailsPage: FC = () : JSX.Element => {
    const params = useParams();
    const [movie, setMovie] = useState<MovieDetails>({} as MovieDetails) ;
    const [comments, setComments] = useState<PaginatedResult<CommentReadDto>>({} as PaginatedResult<CommentReadDto>);
    const [isLoaded, setIsLoaded] = useState(false);
    const token : string = "";


    const getComments = async () => {
        const responsePagedData = await showPaginatedComments({
            PageIndex : 0,
            PageSize : 10,
            columnNameForSorting : "CreatingDate",
            sortDirection : "Descending",
            requestFilters : 
            {
                filterLogicalOperator : 0,
                filters : [
                    {
                        path : "MovieId",
                        value : params.id.toString(),
                        expression : "Equal"
                    }
                ]
            }
    
        }, token);
        setComments(responsePagedData);
    }

    const getData = async () => {
        try{
            setIsLoaded(false);
            const responseData = await getMovieDetails(token, params.id);
            setMovie(responseData);
            setIsLoaded(true);
            console.log(movie);
        }
        catch(e : any){
            return <div>Ошибка: {e.message}</div>;
        }
    }

    useEffect(() => {
        getData();
        getComments();
    }, []);
    if (!isLoaded) {
        return(
            <Box sx={{ display: 'flex' , flexDirection: 'column', alignItems: 'center', mt:20 }}>
                <CircularProgress />
            </Box>
            );
    } else {
        console.log(comments);

        return (
            <div className="MovieList">
                <div>
                    <h1>{movie.title}</h1>
                    <p>{movie.genre}</p>
                    <p>{movie.directorReadDto.firstName}, {movie.directorReadDto.lastName}</p>
                    <p>{movie.description}</p>
                    <p>{movie.actors[0].firstName}</p>
                </div>
                <div>
                    {/* <h3>{comments[0].id}</h3>
                    <h2>{comments[0].body}</h2> */}
                </div>
            </div>);
    }
}

export default MovieDetailsPage;
                    
                
            