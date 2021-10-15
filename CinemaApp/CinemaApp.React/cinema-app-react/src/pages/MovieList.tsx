import React, {FC} from 'react';
import {useState} from 'react';
import {useEffect} from 'react';
import Grid from "@mui/material/Grid";
import MovieItem from "../components/MovieItem";
import CircularProgress from  "@mui/material/CircularProgress";
import AddMovieIcon from "../components/movieListComponents/AddMovieIcon";
import Box from "@mui/material/Box";
import MovieListHeader from "../components/movieListComponents/MovieListHeader";
import AddMovieForm from "../components/AddMovieForm";
import {Movie} from "../entities/movies/movie";
import {getMovies} from "../services/MovieService";


const MovieList : FC = () : JSX.Element =>{
    const [movies, setMovies] = useState<Movie[]>([]);
    const [isLoaded, setIsLoaded] = useState(true);
    const [error, setError] = useState<Error>();
    const token : string = "";

    const getData = async () => {
        const responseData = await getMovies(token);
        setMovies(responseData);
    }

    useEffect(() => {
        
        getData();
    }, []);

    if (error) {
        return <div>Ошибка: {error.message}</div>;
    } else if (!isLoaded) {
        console.log(movies);
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
                        <MovieItem movie ={movie} key = {movie.id}/>
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