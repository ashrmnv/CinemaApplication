import React, {FC, createContext, useState} from 'react';
import MovieListHeader from "./MovieList/ui/MovieListHeader";
import MovieList from './MovieList/MovieList';
import {Filter} from "../../shared/RequestFilters/Filter";

interface Filters{
    movieFilters : Filter[],
    setMovieFilters : React.Dispatch<React.SetStateAction<Filter[]>>
}

export const movieFiltersContext = createContext({} as Filters);

const CinemaPlaybill : FC = () : JSX.Element => {
    const [movieFilters, setMovieFilters] = useState<Filter[]>([]);
    return (
            <movieFiltersContext.Provider value ={
                {movieFilters,
                setMovieFilters}
            }>
                <div>
                    <MovieListHeader/>
                    <MovieList />
                </div>
            </movieFiltersContext.Provider>
    );
};

export default CinemaPlaybill;