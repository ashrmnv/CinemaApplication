import {useState} from "react";

interface callbackInterface{
    (...args) : void;
}
export const useFetching = (callback : callbackInterface) => {
    const [isLoading, setIsLoading] = useState<boolean>(true);
    const [error, setError] = useState<Error>();
    const fetching = async (...args) => {
        try {
            setIsLoading(true)
            await callback(...args);
        } catch (e: any) {
            setError(e);
        } finally {
            setIsLoading(false);
        }
    }
    return [fetching, isLoading, error];
}