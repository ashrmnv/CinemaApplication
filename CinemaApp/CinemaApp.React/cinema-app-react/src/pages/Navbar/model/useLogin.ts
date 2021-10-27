import {useState} from "react";
import {ticketCreateDto} from "../../../entities/tickets/models/ticketCreateDto";
import {buyTicket} from "../../../features/TicketService";
import {login} from "../../../features/UserService";

export const useLogin = (setIsAuth, setToken, setOpen) : [(data) => Promise<void>, boolean, string] => {

    const [isLoading, setIsLoading] = useState<boolean>(true);
    const [errorMessage, setErrorMessage] = useState<string>("");

    const onSubmitHandler = async (data) => {
        setErrorMessage("");
        try{
            setIsLoading(true);
            const response = await login(data);
            if (response.message){
                setErrorMessage(response.message);
            }
            else{
                localStorage.setItem('id', response.id);
                localStorage.setItem('role', response.role);
                localStorage.setItem('token', response.accessToken);
                console.log(response.role);
                setIsAuth(true);
                setToken(response.accessToken);
                setOpen(false);
            }
        }
        catch(e : any){
            setErrorMessage("Smth bad with request");
        }
        finally{
            setIsLoading(false);
        }

    }
    return [onSubmitHandler, isLoading, errorMessage];
};