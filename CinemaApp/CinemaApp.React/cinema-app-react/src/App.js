import {useState, useContext} from 'react';
import MovieList from "./pages/MovieList";
import Login from "./pages/Login";
import Navbar from "./components/Navbar";
import {BrowserRouter, Switch, Route, Redirect} from "react-router-dom";
import MovieDetailsPage from "./pages/MovieDetails";

function App(){
    const userAuth = useContext();
    return (
        <BrowserRouter>
            <Navbar/>
            <Switch>
                <Route exact path="/login">
                    <Login/>
                </Route>
                <Route exact path="/movies">
                    <MovieList/>
                </Route>
                <Route exact path="/movies/:id">
                    <MovieDetailsPage/>
                </Route>
                <Redirect to='/login'/>
            </Switch>
        </BrowserRouter>
  )
  ;
}

export default App;