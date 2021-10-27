import {PagedRequest} from "../shared/RequestFilters/PagedRequest";
import {PaginatedResult} from "../shared/RequestFilters/PaginatedResult";

import {CommentReadDto} from "../entities/comments/model/comment";
import {useContext} from "react";
import {AuthContext} from "../app/App";

const BASE_URL : string = "https://localhost:5001/api/";

interface UserLoginDto{
    email : string,
    password : string
}

export const login = async (data : UserLoginDto)=>{
    console.log(JSON.stringify(data));
    try {
        const response = await fetch(BASE_URL + "login", {
            method: 'POST',
            headers: {
                'Content-Type' : 'application/json',
            },
            body: JSON.stringify(data),
        })
        const responseData = await response.json();
        console.log(responseData);
        return responseData;
        
    } catch (error:any) {
        throw error;
    }
};

export const logout = async() =>{
    localStorage.removeItem('id');
    localStorage.removeItem('role');
    localStorage.removeItem('token');
}