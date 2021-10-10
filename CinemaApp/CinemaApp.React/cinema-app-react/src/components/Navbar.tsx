import React, {FC} from 'react';
import AppBar from '@mui/material/AppBar';
import Box from '@mui/material/Box';
import Toolbar from '@mui/material/Toolbar';
import Typography from '@mui/material/Typography';
import HomeIcon from '@mui/icons-material/Home';
import AccountCircleIcon from '@mui/icons-material/AccountCircle';
import {Link} from 'react-router-dom';

const linkStyle = {
    textDecoration : "none",
    color : "white"
};

const Navbar : FC = () : JSX.Element => {
    return (
        <Box sx={{ flexGrow: 1 }}>
            <AppBar position="static">
                <Toolbar>
                    <Link to="/movies" style = {linkStyle}>
                        <HomeIcon fontSize="large"/>
                    </Link>
                    <Typography variant="h5" component="div" sx={{ flexGrow: 1, mt : 1 }}>
                        
                    </Typography>
                    <Link to="/login" style={linkStyle}>
                        <AccountCircleIcon fontSize="large"/>
                    </Link>
                </Toolbar>
            </AppBar>
        </Box>
    );
}

export default Navbar;