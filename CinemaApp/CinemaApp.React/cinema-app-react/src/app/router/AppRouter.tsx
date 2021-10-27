import React from 'react';
import Admin from "../../pages/Admin/Admin";
import CinemaPlaybill from "../../pages/CinemaPlaybill/CinemaPlaybill";
import MovieDetailsPage from "../../pages/MovieDetails/MovieDetails";
import {Switch, Route, Redirect} from "react-router-dom";


const AppRouter = () => {
    return (
        <Switch>
            <Route exact path="/movies">
                <CinemaPlaybill/>
            </Route>
            <Route exact path="/movies/:id">
                <MovieDetailsPage/>
            </Route>
            <Route exact path="/admin">
                <Admin/>
            </Route>
            <Redirect to='/movies'/>
        </Switch>
    );
};

export default AppRouter;