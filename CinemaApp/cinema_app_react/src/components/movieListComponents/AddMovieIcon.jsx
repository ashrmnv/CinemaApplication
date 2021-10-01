import React from 'react';
import Box from '@mui/material/Box';
import Fab from '@mui/material/Fab';
import AddIcon from '@mui/icons-material/Add';

const AddMovieIcon = () =>{
    const AddNewMovie = () => {
        let display = document.getElementById("AddForm").style.display;
        if (display !== "none"){
            document.getElementById("AddForm").style.display = "none";
        }
        else{
            document.getElementById("AddForm").style.display = "block";
        }


    }

    return(
        <Box component="span" sx={{mt: 5, display: 'flex' , flexDirection: 'column', alignItems: 'center'}}>
        <Fab color="primary" aria-label="add" onClick={AddNewMovie}>
            <AddIcon />
        </Fab>
        </Box>
    );
}

export default AddMovieIcon;