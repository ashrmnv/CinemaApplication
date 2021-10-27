import React, {FC, useContext, useEffect, useState, useRef} from 'react';
import InfoSnackbar from "../../../shared/Snackbar/InfoSnackbar";
import {AuthContext} from "../../../app/App";
import {ticketReadDto} from "../models/ticketReadDto";
import Button from '@mui/material/Button';
import { Box } from "@mui/material";
import { buyTicket} from '../../../features/TicketService';
import { ticketCreateDto } from '../models/ticketCreateDto';
import {useFetchingTickets} from "../models/useFetchingTickets";
import SelectForm from "./components/SelectForm";

interface TicketsSelectorProps{
    sessionId : number;
}
const TicketsSelector : FC<TicketsSelectorProps> = ({sessionId}) => {

    const [tickets, setTickets] = useState<ticketReadDto[]>([]);

    const [fetchData, isLoading, error] = useFetchingTickets(setTickets, sessionId);

    useEffect(() => {
        fetchData();
    }, [sessionId])



    return(
        <Box sx={{ minWidth: 120, padding : 5 }}>
            <form>
                <SelectForm tickets={tickets} fetchData = {fetchData} sessionId = {sessionId}/>
                 <Box sx={{display : "flex", justifyContent : "flex-end", padding : 2}}>
                </Box>
        </form>
        </Box>
    )
}
export default TicketsSelector;