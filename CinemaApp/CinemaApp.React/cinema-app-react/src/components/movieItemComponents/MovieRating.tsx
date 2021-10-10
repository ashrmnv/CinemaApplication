import React, {FC} from 'react'; 
import {useState} from 'react';
import {Popover, Rating} from "@mui/material";
import Typography from "@mui/material/Typography";
interface RatingProps{
    rating : number;
}
const MovieRating : FC<RatingProps> = ({rating}) : JSX.Element => {
    const [anchorEl, setAnchorEl] = useState(null);
    const open = Boolean(anchorEl);

    const showRating = (event) => {
        setAnchorEl(event.currentTarget);
    }
    const hideRating = () => {
        setAnchorEl(null);
    }
    return (
        <span
            onMouseEnter={showRating}
            onMouseLeave={hideRating}
            aria-owns={open ? 'mouse-over-popover' : undefined}
            aria-haspopup="true"
        >
            <Rating
                value={rating}
                max={10}
                precision={0.1}
                readOnly
            />
            <Popover
                id="mouse-over-popover"
                sx={{
                    pointerEvents: 'none',
                }}
                open={open}
                anchorEl={anchorEl}
                anchorOrigin={{
                    vertical: 'bottom',
                    horizontal: 'left',
                }}
                transformOrigin={{
                    vertical: 'top',
                    horizontal: 'left',
                }}
                onClose={hideRating}
                disableRestoreFocus
            >
                <Typography sx={{ p: 1 }}>{rating}/10</Typography>
            </Popover>
        </span>
    );
};

export default MovieRating;