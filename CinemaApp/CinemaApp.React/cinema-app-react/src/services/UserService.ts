import {PagedRequest} from "../shared/PagedRequest";
import {PaginatedResult} from "../shared/PaginatedResult";

import {CommentReadDto} from "../entities/comments/comment";

const BASE_URL : string = "https://localhost:5001/api/";

interface UserLoginDto{
    email : string,
    password : string
}

export const getToken = async (data : UserLoginDto)=>{
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
        return responseData;
        
    } catch (error:any) {
        throw error;
    }
}