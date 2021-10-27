import React, {useState, useContext, FC} from 'react';
import Box from '@mui/material/Box';
import Tabs from '@mui/material/Tabs';
import Tab from '@mui/material/Tab';
import {movieFiltersContext} from "../../CinemaPlaybill";
import GenreFilter from './GenreFilter';
import Typography from '@mui/material/Typography';


const MovieListHeader: FC = () : JSX.Element => {

    const [value, setValue] = useState(1);

    const handleChange = (event, newValue) => {
      setValue(newValue);
    };

    const {movieFilters, setMovieFilters} = useContext(movieFiltersContext);

    return (
        <Box sx={{ width: '100%', bgcolor: 'background.paper'}}>
                  <Box sx={{display: 'flex', justifyContent: 'space-between', float: 'right', marginTop: "6px", marginRight: '2px'}}>

                    <GenreFilter/>
                  </Box>
          <Box sx={{display: "flex", justifyContent: 'center'}}>
          <Tabs value={value} onChange={handleChange} variant="scrollable"
                        scrollButtons="auto" >
          <Tab label="Now Showing" onClick = {() => {
                        const date = new Date();
                        setMovieFilters(
                            [{
                                path : "PremiereDate",
                                value : date.toLocaleDateString("en-US"),
                                expression : 2
                            }]);
                          }
          }/>
          <Tab label="All Movies" onClick={() => {setMovieFilters([]);}}/>
          <Tab label="Coming Soon" onClick={() => {
            const date = new Date();
            setMovieFilters(
                [{
                    path : "PremiereDate",
                    value : date.toLocaleDateString("en-US"),
                    expression : 3
                }]);
              }}/>
        </Tabs>
        </Box>
      </Box>
    );
};

export default MovieListHeader;