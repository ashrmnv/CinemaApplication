import React, {FC, useContext} from 'react';
import AppBar from '@mui/material/AppBar';
import Box from '@mui/material/Box';
import Toolbar from '@mui/material/Toolbar';
import Typography from '@mui/material/Typography';
import HomeIcon from '@mui/icons-material/Home';
import {Link} from 'react-router-dom';
import {AuthContext} from '../../app/App';
import LoginIcon from "./components/LoginIcon";
import AuthedIcon from "./components/AuthedIcon";

const linkStyle = {
    textDecoration : "none",
    color : "white"
};

const Navbar : FC = () : JSX.Element => {
    const {isAuth, setIsAuth} = useContext(AuthContext);

    return (
        <Box sx={{ flexGrow: 1 }}>
            <AppBar position="static">
                <Toolbar>
                    <Link to="/movies" style = {linkStyle}>
                        <HomeIcon fontSize="large"/>
                    </Link>
                    <Typography variant="h5" component="div" sx={{ flexGrow: 1, mt : 1 }}>
                        
                    </Typography>
                    {
                        isAuth
                            ?
                            <AuthedIcon/>
                            :
                            <LoginIcon/>
                    }
                </Toolbar>
        <Box sx={{ display: 'flex', alignItems: 'center', textAlign: 'center' }}>
      </Box>
            </AppBar>
        </Box>
    );
}

export default Navbar;