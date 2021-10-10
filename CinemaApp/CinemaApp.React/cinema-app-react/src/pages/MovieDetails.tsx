import React, { FC, useEffect, useState } from 'react';
import {useParams} from 'react-router-dom';
import { Movie } from '../api/movies/movie';

const MovieDetails: FC = () : JSX.Element => {
    const params = useParams();
    const [movie, setMovies] = useState<Movie>();
    const [isLoaded, setIsLoaded] = useState(false);
    const [error, setError] = useState<Error>();

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
    return(
        <h1>ТАЛВатлоывропвоалпд</h1>
    );
}
    // if (error) {
    //     return <div>Ошибка: {error.message}</div>;
    // } else if (!isLoaded) {
    //     return(
    //         <Box sx={{ display: 'flex' , flexDirection: 'column', alignItems: 'center', mt:20 }}>
    //             <CircularProgress />
    //         </Box>
    //         );
    // } else {
    //     return (
    //         <div className="MovieList">
    //             <MovieListHeader title="Now Showing"/>
    //             <Grid container spacing={4} >
    //                 {movies.map(movie => (
    //                     <MovieItem movie ={movie} key = {movie.id}/>
    //                     )
    //                 )}
    //             </Grid>
    //             <AddMovieIcon/>
    //             <AddMovieForm/>
    //         </div>


export default MovieDetails;

