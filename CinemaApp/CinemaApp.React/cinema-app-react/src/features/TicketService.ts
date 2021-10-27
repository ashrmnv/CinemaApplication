import {ticketCreateDto} from "../entities/tickets/models/ticketCreateDto";
import {ticketReadDto} from "../entities/tickets/models/ticketReadDto";
import {PagedRequest} from "../shared/RequestFilters/PagedRequest";

const BASE_URL : string = "https://localhost:5001/api/";

export const showTickets = async(sessionId : number) : Promise<ticketReadDto[]> => {
    try{
        const response = await fetch(BASE_URL + "tickets?sessionId="+sessionId,{
            method : 'GET',
            headers: {
                'Content-type': 'application/json'
            }
        })
        const responseData = response.json();
        return responseData;
    }
    catch(e: any){
        throw e;
    }
}

export const buyTicket = async(ticketCreate : ticketCreateDto, token : string) =>{
    try{
        const response = await fetch(BASE_URL + "tickets",{
            method : 'POST',
            headers: {
                Authorization: `Bearer ${token}`,
                'Content-type': 'application/json',
            },
            body: JSON.stringify(ticketCreate)
        })
        const responseData = response.json();
        return responseData;
    }
    catch(e: any){
        throw e;
    }
}