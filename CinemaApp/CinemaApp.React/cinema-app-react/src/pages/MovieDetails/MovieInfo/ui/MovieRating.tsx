import React, {FC, useContext} from 'react';
import {Rating} from "@mui/material";
import {AuthContext} from "../../../../app/App";
import {addNewRating} from "../../../../features/MovieService";
import {useParams} from 'react-router-dom';

interface MovieRatingProps{
    ratingNumber : number;
    ratingSum : number;
    setIsRated : React.Dispatch<React.SetStateAction<number>>;
}
const MovieRating : FC<MovieRatingProps> = ({ratingNumber, ratingSum, setIsRated}) : JSX.Element => {

    const {isAuth, token} = useContext(AuthContext);
    const params = useParams();
    const oldRating : number = ratingNumber !== 0 ? ratingSum/ratingNumber : 0;

    interface ChangeRatingBody{
        movieId : number,
        userId: number,
        rating : number
    };

    const changeRating = async (event : any) =>{
        const userId = localStorage.getItem('id');

        const data : ChangeRatingBody = {
            movieId : params.id,
            userId : parseInt(userId !== null ? userId : "-1"),
            rating : event.target.value
        };
        const response = await addNewRating(data, token);
        setIsRated(event.target.value);

    }
    if (isAuth){
        return(
            <div>
                <Rating
                    value={oldRating}
                    max={10}
                    onClick={changeRating}
                />
                <p style={{opacity: 0.6}}> ({ratingNumber} votes) </p>
            </div>
        );
    }
    else{
        return(
            <div>
                <Rating
                    value={oldRating}
                    max={10}
                    readOnly
                />
                <p style={{opacity: 0.6}}> ({ratingNumber} votes) </p>
            </div>
        );
    }
};

export default MovieRating;