import React, {FC, useEffect, useState} from 'react';

import DeleteIcon from '@mui/icons-material/Delete';
import EditIcon from '@mui/icons-material/Edit';
import IconButton from '@mui/material/IconButton';


interface IconsButtonsProps{
    movieId : number;
    getMovies : () => Promise<void>;
}
const AdminTicketsList : FC<IconsButtonsProps> = ({movieId, getMovies}) : JSX.Element => {

    const deleteMovie = async () => {

    }
    return (
        <div>
            <IconButton>
                <EditIcon color="primary"/>
            </IconButton>
            <IconButton onClick={deleteMovie}>
                <DeleteIcon color="primary"/>
            </IconButton>
        </div>
    );
};

export default AdminTicketsList;