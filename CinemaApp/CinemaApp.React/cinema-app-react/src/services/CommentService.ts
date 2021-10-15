import {PagedRequest} from "../shared/PagedRequest";
import {PaginatedResult} from "../shared/PaginatedResult";

import {CommentReadDto} from "../entities/comments/comment";

const BASE_URL : string = "https://localhost:5001/api/";

export const showPaginatedComments = async (pagedRequest:PagedRequest,token) : Promise<PaginatedResult<CommentReadDto>>=>{
    try {
        const response = await fetch(BASE_URL + "comments/paginated-result", {
            method: 'POST',
            headers: {
                Authorization: `Bearer ${token}`,
                'Content-type': 'application/json',
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