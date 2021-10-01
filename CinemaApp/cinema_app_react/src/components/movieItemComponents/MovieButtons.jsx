import React from 'react';
import {CardActions} from "@mui/material";
import Button from "@mui/material/Button";

const MovieButtons = () => {
    return (
        <CardActions>
            <Button size="small" variant="contained">Buy tickets</Button>
        </CardActions>
    );
};

export default MovieButtons;