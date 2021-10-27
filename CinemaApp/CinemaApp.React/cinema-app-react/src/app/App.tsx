import React, {useState, useContext, createContext, useEffect} from 'react';
import Navbar from "../pages/Navbar/Navbar";
import {BrowserRouter} from "react-router-dom";
import './style.css';
import AppRouter from "./router/AppRouter";

interface userAuthProps{
    isAuth : boolean,
    setIsAuth : React.Dispatch<React.SetStateAction<boolean>>,
    token : string,
    setToken : React.Dispatch<React.SetStateAction<string>>
};

export const AuthContext = createContext({} as userAuthProps);

function App(){
    const [isAuth, setIsAuth] = useState<boolean>(false);
    const [token, setToken] = useState<string>("");

    useEffect(() => {
        if (localStorage.getItem('id') && localStorage.getItem('token')){
            setIsAuth(true);
            const accessToken = localStorage.getItem('token');
            setToken(accessToken !== null ? accessToken : "-1");
        }
        else{
            console.log("unAuth");
        }
    }, [isAuth])

    return (
        <AuthContext.Provider value={{
            isAuth,
            setIsAuth,
            token,
            setToken
        }}>
            <BrowserRouter>
                <Navbar/>
                <AppRouter/>
            </BrowserRouter>
        </AuthContext.Provider>
    );
}

export default App;