import React, {useContext} from 'react';
import Fab from "@mui/material/Fab";
import AddIcon from "@mui/icons-material/Add";
import {movieInWaitingList} from "../../../../features/MovieService";
import {AuthContext} from "../../../../app/App";
import {useParams} from 'react-router-dom';

const AddInWaitingIcon = () => {

    const {isAuth, token} = useContext(AuthContext);
    const params = useParams();

    interface waitingList{
        userId : number,
        movieId : number
    }
    const addInWaitingList = async () => {
        const userId = localStorage.getItem('id');

        const data : waitingList = {
            userId : parseInt(userId !== null ? userId : "-1"),
            movieId : params.id
        };
        const response = await movieInWaitingList(data, token);
        console.log(response);
    }
    return (
        <Fab color="primary" aria-label="add" onClick={addInWaitingList}>
            <AddIcon />
        </Fab>
    );
};

export default AddInWaitingIcon;