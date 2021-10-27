import React, {FC} from 'react';
import {CardActions} from "@mui/material";
import Button from "@mui/material/Button";
import {useHistory} from "react-router-dom";

interface IdProps {
    id : number;
}

const MovieButtons : FC<IdProps> = ({id}) => {
    const router = useHistory();

    return (
        <CardActions>
            <Button size="small" variant="contained" onClick={() => router.push("/movies/" + id)}>Buy tickets</Button>
        </CardActions>
    );
};

export default MovieButtons;