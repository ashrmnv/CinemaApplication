import {Movie} from "../entities/movies/movie";
import {MovieDetails} from "../entities/movies/movieDetails";


const BASE_URL : string = "https://localhost:5001/api/";

export const getMovies = async (token : string) : Promise<Movie[]> => {
    try{
        const response = await fetch(
            BASE_URL + "movies" ,
            {
                method:"GET",
                headers: {
                    Authorization: "Bearer " + token,
                },
            }
        );
        const responseData = await response.json();
        return responseData;
    }
    catch(e : any){
        throw e;
    }
};

export const getMovieDetails = async (token : string, id : number) : Promise<MovieDetails> => {
    try{
        const response = await fetch(
            BASE_URL + "movies/" + id ,
            {
                method:"GET",
                headers: {
                    Authorization: "Bearer " + token,
                },
            }
        );
        const responseData = await response.json();
        return responseData;
    }
    catch(e : any){
        throw e;
    }
};