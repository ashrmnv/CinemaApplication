import React, {FC} from 'react';
import Box from '@mui/material/Box';
import AddCircleOutlinedIcon from '@mui/icons-material/AddCircleOutlined';

const AddMovieIcon : FC = () : JSX.Element =>{
    const AddNewMovie = () => {
        let display = document.getElementById("AddForm")!.style.display;
        if (display !== "none"){
            document.getElementById("AddForm")!.style.display = "none";
        }
        else{
            document.getElementById("AddForm")!.style.display = "block";
        }
    }

    return(
        <Box component="span" sx={{mt: 5, display: 'flex' , flexDirection: 'column', alignItems: 'center'}}>
            <AddCircleOutlinedIcon
                fontSize="large"
                color="primary"
                onClick={AddNewMovie}
            />
        </Box>
    );
}

export default AddMovieIcon;