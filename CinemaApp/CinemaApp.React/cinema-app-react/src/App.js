import MovieList from "./pages/MovieList";
import Navbar from "./components/Navbar";
import {BrowserRouter, Switch, Route, Redirect} from "react-router-dom";
import MovieDetails from "./pages/MovieDetails";

function App() {
  return (
      <BrowserRouter>
          <Navbar/>
          <Switch>
              <Route exact path="/movies">
                  <MovieList/>
              </Route>
              <Route exact path="/movies/:id">
                  <MovieDetails/>
              </Route>
              <Redirect to='/movies'/>
          </Switch>
      </BrowserRouter>
  )
  ;
}

export default App;