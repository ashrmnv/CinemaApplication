import React, {useEffect} from 'react';
import {useState} from 'react';
import Grid from "@mui/material/Grid";
import MovieItem from "./MovieItem";
import CircularProgress from  "@mui/material/CircularProgress";
import AddMovieIcon from "./movieListComponents/AddMovieIcon";
import Box from "@mui/material/Box";
import MovieListHeader from "./movieListComponents/MovieListHeader";
import AddMovieForm from "./AddMovieForm";

const MovieList = () =>{
    const [movies, setMovies] = useState([]);
    const [isLoaded, setIsLoaded] = useState(false);
    const [error, setError] = useState(null);

    const getData = () => {
        fetch('./data/MoviesExample.json', {
            headers: {
                'Content-Type' : 'application/json',
                'Accept' : 'application/json'
            }
        })
            .then(response => response.json())
            .then((result) => {
                    setIsLoaded(true);
                    setMovies(result);
                },
                (error) => {
                    setIsLoaded(true);
                    setError(error);
                })
    }

    useEffect( getData , []);

    if (error) {
        return <div>Ошибка: {error.message}</div>;
    } else if (!isLoaded) {
        return(
            <Box sx={{ display: 'flex' , flexDirection: 'column', alignItems: 'center', mt:20 }}>
                <CircularProgress />
            </Box>
            );
    } else {
        return (
            <div className="MovieList">
                <MovieListHeader title="Now Showing"/>
                <Grid container spacing={4} >
                    {movies.map(movie => (
                        <MovieItem info ={movie} key = {movie.id}/>
                        )
                    )}
                </Grid>
                <AddMovieIcon/>
                <AddMovieForm/>
            </div>
        );
    }
}

export default MovieList;