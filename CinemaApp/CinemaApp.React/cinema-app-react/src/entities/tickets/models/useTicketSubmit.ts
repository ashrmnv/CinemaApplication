import {ticketCreateDto} from "./ticketCreateDto";
import {buyTicket} from "../../../features/TicketService";
import { useState } from "react";


export const useTicketSubmit = (isAuth : boolean, place : string, row : string, price : number,
    fetchData : () => Promise<void>, sessionId : number) : [() => Promise<void>, boolean, string] => {

    const [isLoading, setIsLoading] = useState<boolean>(true);
    const [errorMessage, setErrorMessage] = useState<string>("");
    
    const submitBuy = async () => {
        setErrorMessage("");
            if (isAuth){
            if (place === '' || row === '' || sessionId === 0){
                setErrorMessage("Feel all the fields");
                return;
            }
            try{
                setIsLoading(true);
                const userId = localStorage.getItem('id');
                const tokenCheck = localStorage.getItem('token');
                const token = tokenCheck ? tokenCheck : " ";
                const ticketData : ticketCreateDto = {
                    place : parseInt(place),
                    row : parseInt(row),
                    price : price,
                    userId : parseInt(userId !== null ? userId : "-1"),
                    sessionId : sessionId
                }
                const response = await buyTicket(ticketData, token);
                fetchData();
            }
            catch(e : any){
                setErrorMessage("Smth bad with request");
            }
            finally{
                setIsLoading(false);
            }
        }
        else{
            setErrorMessage("Need to login")
        }
    }
return [submitBuy, isLoading, errorMessage];
};