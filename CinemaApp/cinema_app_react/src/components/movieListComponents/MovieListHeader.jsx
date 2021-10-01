import React from 'react';
import Typography from "@mui/material/Typography";

const MovieListHeader = ({title}) => {
    return (
        <Typography
            variant="h3"
            component="div"
            color = 'primary'
            sx={{m: 2, display: 'flex' , flexDirection: 'column', alignItems: 'center'}}
        >
            {title}
        </Typography>
    );
};

export default MovieListHeader;