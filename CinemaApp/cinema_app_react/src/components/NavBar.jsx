import * as React from 'react';
import AppBar from '@mui/material/AppBar';
import Box from '@mui/material/Box';
import Toolbar from '@mui/material/Toolbar';
import Typography from '@mui/material/Typography';
import HomeIcon from '@mui/icons-material/Home';
import AccountCircleIcon from '@mui/icons-material/AccountCircle';

const NavBar = () => {
    return (
        <Box sx={{ flexGrow: 1 }}>
            <AppBar position="static">
                <Toolbar>
                    <HomeIcon
                                fontSize="large"
                                edge="start"
                                color="inherit"
                                aria-label="menu"
                                sx={{ mr: 2 }}
                     />
                    <Typography variant="h5" component="div" sx={{ flexGrow: 1, mt : 1 }}>
                        
                    </Typography>
                    <AccountCircleIcon/>
                </Toolbar>
            </AppBar>
        </Box>
    );
}

export default NavBar;