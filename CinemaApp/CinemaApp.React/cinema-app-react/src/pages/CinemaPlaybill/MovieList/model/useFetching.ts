import React from 'react';
import {getMovies} from "../../../../features/MovieService";
import {useContext, useState} from "react";
import {movieFiltersContext} from "../../CinemaPlaybill";

export const useFetching = (obj, setIsLoading, setPage, movies,
                                  setMovies, setTotalPages, setError) =>{
    const {movieFilters} = useContext(movieFiltersContext);
    const fetching = async (isChangedFilter) => {
        try{
            setIsLoading(true);
            if (isChangedFilter){
                setPage(0);
                const responseData = await getMovies({
                    PageIndex : 0,
                    PageSize : 4,
                    columnNameForSorting : "PremiereDate",
                    sortDirection : "Ascending",
                    requestFilters :
                        {
                            filterLogicalOperator : 0,
                            filters : movieFilters
                        }
                });
                setMovies(responseData.items);
                setTotalPages(Math.ceil(responseData.total/responseData.pageSize));
            }
            else{
                const responseData = await getMovies(obj);
                setMovies([...movies, ...responseData.items]);
                setTotalPages(Math.ceil(responseData.total/responseData.pageSize));
            }
        }
        catch(e : any){
            setError(e);
        }
        finally{
            setIsLoading(false);
        }
    }
    return fetching;
}