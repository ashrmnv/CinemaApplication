import {getMovieDetails} from "../../../../features/MovieService";
import React from "react";

export const getMovie = async (setIsLoading, setMovie, setPremiereDate, movieId) => {
    try {
        setIsLoading(true);
        const responseData = await getMovieDetails(movieId);
        setMovie(responseData);
        setPremiereDate(responseData.premiereDate)
    } catch (e: any) {
        throw e;
    }
    finally {
        setIsLoading(false);
    }
}