import React, {FC, useContext, useRef} from 'react';
import Button from '@mui/material/Button';
import Menu from '@mui/material/Menu';
import MenuItem from '@mui/material/MenuItem';
import AppsIcon from '@mui/icons-material/Apps';
import Box from '@mui/material/Box';
import IconButton from '@mui/material/IconButton';
import Popover from '@mui/material/Popover';
import Typography from '@mui/material/Typography';
import FilterAltIcon from '@mui/icons-material/FilterAlt';
import FormGroup from '@mui/material/FormGroup';
import FormControlLabel from '@mui/material/FormControlLabel';
import Checkbox from '@mui/material/Checkbox';
import {movieFiltersContext} from "../../CinemaPlaybill";

const GenreFilter : FC = () : JSX.Element =>{
    const {movieFilters, setMovieFilters} = useContext(movieFiltersContext);

    const [isChecked, setIsChecked] = React.useState<boolean>(false);

    const genresPopout = useRef<any>({} as any);

    const AddFilter = (event: React.ChangeEvent<HTMLInputElement>) => {
      console.log(event.target.value , event.target.checked);
      for(const x of genresPopout.current.children){
        console.log(x.children[0].value);
      }
      if (event.target.checked){
        setMovieFilters([...movieFilters, {
          path : "Genre",
          value : event.target.value.toString(),
          expression : 1
        }
      ]);
      }
      else{
        const clearedMovieFilters = movieFilters.filter(x => x.value !== event.target.value.toString());
        console.log('1');
        setMovieFilters(clearedMovieFilters);      
     }
    //   event.target.checked = true;
    }

    const [anchorClickEl, setAnchorClickEl] = React.useState(null);

    const handleClick = (event) => {
      setAnchorClickEl(event.currentTarget);
    };
  
    const handleClose = () => {
      setAnchorClickEl(null);
    };
  
    const openClick = Boolean(anchorClickEl);
    const id = openClick ? 'simple-popover' : undefined;

  const [anchorHoverEl, setAnchorHoverEl] = React.useState<HTMLElement | null>(null);

  const handlePopoverOpen = (event: React.MouseEvent<HTMLElement>) => {
    setAnchorHoverEl(event.currentTarget);
  };

  const handlePopoverClose = () => {
    setAnchorHoverEl(null);
  };

  const openHover = Boolean(anchorHoverEl);
  
    return (
      <Typography component="span">
        <IconButton 
          aria-owns={openHover ? 'mouse-over-popover' : undefined}
          aria-describedby={id} 
          onClick={handleClick} 
          onMouseEnter={handlePopoverOpen}
          onMouseLeave={handlePopoverClose}
        >
          <FilterAltIcon color='primary'/>
        </IconButton>
        <Popover
          id={id}
          open={openClick}
          anchorEl={anchorClickEl}
          onClose={handleClose}
          anchorOrigin={{
            vertical: 'bottom',
            horizontal: 'left',
          }}
        >
        <FormGroup sx={{p : 2}} ref={genresPopout}>
          <FormControlLabel  control={<Checkbox value="Action" onChange={AddFilter}/>} label="Action" />
          <FormControlLabel  control={<Checkbox value="Adventure" onChange={AddFilter}/>} label="Adventure" />
          <FormControlLabel  control={<Checkbox value="Animation" onChange={AddFilter}/>} label="Animation" />
          <FormControlLabel  control={<Checkbox value="Comedy" onChange={AddFilter}/>} label="Comedy" />
          <FormControlLabel  control={<Checkbox value="Crime" onChange={AddFilter}/>} label="Crime" />
          <FormControlLabel  control={<Checkbox value="Drama" onChange={AddFilter}/>} label="Drama" />
          <FormControlLabel  control={<Checkbox value="Fantasy" onChange={AddFilter}/>} label="Fantasy" />
          <FormControlLabel  control={<Checkbox value="History" onChange={AddFilter}/>} label="History" />
          <FormControlLabel  control={<Checkbox value="Horror" onChange={AddFilter}/>} label="Horror" />
          <FormControlLabel  control={<Checkbox value="Mystery" onChange={AddFilter}/>} label="Mystery" />
          <FormControlLabel  control={<Checkbox value="Sci-Fi" onChange={AddFilter}/>} label="Sci-Fi" />
          <FormControlLabel  control={<Checkbox value="Thriller" onChange={AddFilter}/>} label="Thriller" />
        </FormGroup>
        </Popover>
        <Popover
        id="mouse-over-popover"
        sx={{
          pointerEvents: 'none',
        }}
        open={openHover}
        anchorEl={anchorHoverEl}
        anchorOrigin={{
          vertical: 'center',
          horizontal: 'left',
        }}
        transformOrigin={{
          vertical: 'center',
          horizontal: 'right',
        }}
        onClose={handlePopoverClose}
        disableRestoreFocus
      >
        <Typography sx={{ p: 1 }}>Choose genres</Typography>
      </Popover>
      </Typography>
    );
}

export default GenreFilter;