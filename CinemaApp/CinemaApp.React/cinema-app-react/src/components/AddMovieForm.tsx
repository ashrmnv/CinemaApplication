import React from 'react';
import {TextField} from "@mui/material";
import {useForm} from 'react-hook-form';
import MovieListHeader from "./movieListComponents/MovieListHeader";
import { Movie } from '../api/movies/movie';

const AddMovieForm = () => {
    const {register, handleSubmit} = useForm();
    const AddMovie = (value : Movie) =>{
        console.log(value);
    }
    return (
        <form id = "AddForm" style ={{display: "none"}} onSubmit={handleSubmit(AddMovie)}>
            <MovieListHeader title="Add Movie"/>
            <TextField
                //name={"id"}
                id="outlined-required"
                label="Required"
                {...register("id")}
            />
            <TextField
                //name="director"
                id="outlined-required"
                label="Required"
                {...register("director")}
            />
            <TextField
                //name="genre"
                id="outlined-required"
                label="Required"
                {...register("genre")}
            />
            <input type="submit" value="Кнопка"/>
        </form>
    );
};

export default AddMovieForm;