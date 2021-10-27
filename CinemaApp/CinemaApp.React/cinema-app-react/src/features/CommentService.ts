import {PagedRequest} from "../shared/RequestFilters/PagedRequest";
import {PaginatedResult} from "../shared/RequestFilters/PaginatedResult";
import {CommentUpdateDto} from "../entities/comments/model/commentUpdateDto";
import {CommentReadDto} from "../entities/comments/model/comment";
import {CommentCreate} from "../entities/comments/model/commentCreate";


const BASE_URL : string = "https://localhost:5001/api/";

export const showPaginatedComments = async (pagedRequest:PagedRequest) : Promise<PaginatedResult<CommentReadDto>> => {
    try {
        const response = await fetch(BASE_URL + "comments/paginated-result", {
            method: 'POST',
            headers: {
                'Content-type': 'application/json'
            },
            body: JSON.stringify(pagedRequest),
        })
        const responseData = await response.json();
        console.log(responseData);
        return responseData;
        
    } catch (error:any) {
        throw error;
    }
}


export const addNewComment = async(commentCreate : CommentCreate, token : string) : Promise<CommentReadDto> =>{
    try{
        const response = await fetch(BASE_URL + "comments",{
            method : 'POST',
            headers: {
                Authorization: `Bearer ${token}`,
                'Content-type': 'application/json',
            },
            body: JSON.stringify(commentCreate)
        })
        const responseData = response.json();
        return responseData;
    }
    catch(e: any){
        throw e;
    }
}

export const deleteComment = async(commentId : number, token : string) => {
    try{
        const response = await fetch(BASE_URL + "comments/" + commentId,{
            method : 'DELETE',
            headers: {
                Authorization: `Bearer ${token}`
            }
        })
        const responseData = response;
        return responseData;
    }
    catch(e: any){
        throw e;
    }
}

export const updateComment = async(commentUpdateDto : CommentUpdateDto, commentId : number, token : string) => {
    try{
        const response = await fetch(BASE_URL + "comments/" + commentId,{
            method : 'PUT',
            headers: {
                Authorization: `Bearer ${token}`,
                'Content-type': 'application/json',
            },
            body: JSON.stringify(commentUpdateDto)
        })
        const responseData = response.json();
        return responseData;
    }
    catch(e: any){
        throw e;
    }
}