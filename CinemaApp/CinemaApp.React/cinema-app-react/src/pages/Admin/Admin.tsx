import React, {FC, useEffect, useState} from 'react';
import { Movie } from '../../entities/movies/models/movie';
import { getAllMovies } from '../../features/MovieService';
import Accordion from '@mui/material/Accordion';
import AccordionSummary from '@mui/material/AccordionSummary';
import AccordionDetails from '@mui/material/AccordionDetails';
import Typography from '@mui/material/Typography';
import ExpandMoreIcon from '@mui/icons-material/ExpandMore';
import AdminSessionsList from './ui/AdminSessionsList';
import IconButtons from './ui/IconButtons';



const Admin : FC = () : JSX.Element => {
    
    const roleCheck = localStorage.getItem('role');
    const userRole = roleCheck !== null ? roleCheck : "unAuth";

    const [allMovies, setAllMovies] = useState<Movie[]>([]);
    const getData = async () => {
        const response = await getAllMovies();
        setAllMovies(response);
    }

    useEffect(() => {
        getData();
    }, [])
    if (userRole !== "admin"){
        return (
            <div>Only for admin)</div>
        );
    }
    else{
        return (
            <div>
                <div>
                    {
                        allMovies.map(movie => (
                            <Accordion>
                                <AccordionSummary
                                expandIcon={<ExpandMoreIcon />}
                                aria-controls="panel1a-content"
                                id="panel1a-header"
                                >
                                <Typography>
                                    {movie.id}. {movie.title}
                                    <IconButtons movieId={movie.id} getMovies = {getData}/>
                                </Typography>
                                </AccordionSummary>
                                <AccordionDetails>
                                <Typography>
                                    <div>
                                        <AdminSessionsList movieId = {movie.id}/>
                                    </div>
                                </Typography>
                                </AccordionDetails>
                            </Accordion>
                        ))
                    }
                </div>
            </div>
        );
    }
    
};

export default Admin;