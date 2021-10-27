import {Movie} from "../entities/movies/models/movie";
import {MovieDetails} from "../entities/movies/models/movieDetails";
import {PagedRequest} from "../shared/RequestFilters/PagedRequest";
import {PaginatedResult} from "../shared/RequestFilters/PaginatedResult";

const BASE_URL : string = "https://localhost:5001/api/";

export const getAllMovies = async () => {
    try{
        const response = await fetch(BASE_URL + "movies", {
            method: 'GET',
            headers: {
                'Content-type': 'application/json'
            }
        })
        const responseData = await response.json();
        return await responseData;
    }
    catch(e : any){
        throw e;
    }
};

export const getMovies = async (pagedRequest:PagedRequest) => {
    try{
        const response = await fetch(BASE_URL + "movies/paginated-result", {
            method: 'POST',
            headers: {
                'Content-type': 'application/json'
            },
            body: JSON.stringify(pagedRequest),
        })
        const responseData = await response.json();
        return await responseData;
    }
    catch(e : any){
        throw e;
    }
};

export const getMovieDetails = async (id : number) : Promise<MovieDetails> => {
    try {
        const response = await fetch(
            BASE_URL + "movies/" + id,
            {
                method: "GET",
                headers: {
                    //Authorization: "Bearer " + token,
                    'Content-type': 'application/json'
                },
            }
        );
        const responseData = await response.json();
        return responseData;
    } catch (ex: any) {
        throw ex;
    }
};

interface ChangeRatingBody{
    movieId : number,
    userId: number,
    rating : number
};

export const addNewRating = async (changeRatingBody : ChangeRatingBody, token : string) => {
    try {
        const response = await fetch(
            BASE_URL + "movies/set-movie-rating",
            {
                method: "POST",
                headers: {
                    Authorization: "Bearer " + token,
                    'Content-type': 'application/json'
                },
                body: JSON.stringify(changeRatingBody),
            }
        );
        const responseData = await response;
        return responseData;
    } catch (ex: any) {
        throw ex;
    }
}

interface WaitingList{
    userId : number,
    movieId : number
}
export const movieInWaitingList = async (waitingList : WaitingList, token : string) => {
    try {
        const response = await fetch(
            BASE_URL + "movies/add-in-waiting-list",
            {
                method: "POST",
                headers: {
                    Authorization: "Bearer " + token,
                    'Content-type': 'application/json'
                },
                body: JSON.stringify(waitingList),
            }
        );
        const responseData = await response;
        return responseData;
    } catch (ex: any) {
        throw ex;
    }
}

export const deleteMovie = async(movieId : number, token : string) => {
    try{
        const response = await fetch(BASE_URL + "movies/" + movieId,{
            method : 'DELETE',
            headers: {
                Authorization: `Bearer ${token}`
            }
        })
        const responseData = response;
        return responseData;
    }
    catch(e: any){
        throw e;
    }
}