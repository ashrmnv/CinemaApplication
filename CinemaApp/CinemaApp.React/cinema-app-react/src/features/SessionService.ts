import {sessionReadDto} from "../entities/sessions/model/sessionReadDto";
import {PagedRequest} from "../shared/RequestFilters/PagedRequest";
import {PaginatedResult} from "../shared/RequestFilters/PaginatedResult";

const BASE_URL : string = "https://localhost:5001/api/";

export const showPaginatedSessions = async (pagedRequest:PagedRequest) : Promise<PaginatedResult<sessionReadDto>> => {
    try{
        const response = await fetch(BASE_URL + "sessions/paginated-result", {
            method: 'POST',
            headers: {
                'Content-type': 'application/json'
            },
            body: JSON.stringify(pagedRequest),
        })
        const responseData = await response.json();
        return await responseData;
    }
    catch(e : any){
        throw e;
    }
};