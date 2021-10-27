import React, {FC, useContext, useRef} from 'react';
import {useState} from 'react';
import {useEffect} from 'react';
import Grid from "@mui/material/Grid";
import MovieItem from "../../../entities/movies/ui/MovieItem";
import CircularProgress from  "@mui/material/CircularProgress";
import Box from "@mui/material/Box";
import {Movie} from "../../../entities/movies/models/movie";
import {PagedRequest} from "../../../shared/RequestFilters/PagedRequest";
import {movieFiltersContext} from "../CinemaPlaybill";
import {useObserver} from "./model/useObserver";
import {useFetching} from "./model/useFetching";

const MovieList : FC = () : JSX.Element =>{
    const [movies, setMovies] = useState<Movie[]>([]);
    const [isLoading, setIsLoading] = useState(true);
    const [error, setError] = useState<Error>();
    const [page, setPage] = useState<number>(0);
    const [dynamicPage, setDynamicPage] = useState<number>(0);
    const [totalPages, setTotalPages] = useState<number>(0);
    const {movieFilters} = useContext(movieFiltersContext);
    const lastElement = useRef<HTMLDivElement>({} as HTMLDivElement);
    const firstRender = useRef<boolean>(true);

    let obj : PagedRequest = {
        PageIndex : page,
        PageSize : 4,
        columnNameForSorting : "PremiereDate",
        sortDirection : "Ascending",
        requestFilters :
            {
                filterLogicalOperator : 0,
                filters : movieFilters
            }
    };

    const getData = useFetching(obj, setIsLoading, setPage, movies,
            setMovies, setTotalPages, setError);
    
    useObserver(lastElement, page < totalPages, isLoading,() => {
        setPage(obj.PageIndex + 1);
        setDynamicPage(dynamicPage + 1);
    })

    useEffect(() => {
        getData(false);
    }, [dynamicPage]);

    useEffect(() => {
        if (firstRender.current){
            firstRender.current = false;
            return;
        }
        getData(true);
    }, [movieFilters])


    if (error) {
        return <div>Ошибка: {error.message}</div>;
    } else {
        return (
            <div className="MovieList">
                <Grid container spacing={4} >
                    {movies.map(movie => (
                        <MovieItem movie ={movie} key = {movie.id}/>
                        )
                    )}
                </Grid>
                {
                    isLoading
                    ?
                        <Box sx={{ display: 'flex' , flexDirection: 'column', alignItems: 'center', mt: 10}}>
                            <CircularProgress />
                        </Box>
                    :
                    <div></div>
                }
                <div ref={lastElement}></div>
            </div>
        );
    }
}

export default MovieList;