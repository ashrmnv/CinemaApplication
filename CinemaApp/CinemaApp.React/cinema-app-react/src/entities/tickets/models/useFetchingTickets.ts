import {showTickets} from "../../../features/TicketService";
import {useState} from "react";

export const useFetchingTickets = (setTickets, sessionId) :  [() => Promise<void>, boolean, Error] => {
    const [isLoading, setIsLoading] = useState<boolean>(true);
    const [error, setError] = useState<Error>({} as Error);
    const fetchData = async () => {
        try {
            setIsLoading(true)
            const responseData = await showTickets(sessionId);
            setTickets(responseData);
        } catch (e: any) {
            setError(e);
        } finally {
            setIsLoading(false);
        }
    }
    return [fetchData, isLoading, error];
}