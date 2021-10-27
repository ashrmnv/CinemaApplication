import React, {FC, useEffect, useState} from 'react';
import { getSessions } from '../../MovieDetails/Sessions/model/getSession';
import Accordion from '@mui/material/Accordion';
import AccordionSummary from '@mui/material/AccordionSummary';
import AccordionDetails from '@mui/material/AccordionDetails';
import Typography from '@mui/material/Typography';
import ExpandMoreIcon from '@mui/icons-material/ExpandMore';
import {ticketReadDto} from "../../../entities/tickets/models/ticketReadDto";
import {useFetchingTickets} from "../../../entities/tickets/models/useFetchingTickets";


interface TicketsListProps{
    sessionId : number;
}
const AdminTicketsList : FC<TicketsListProps> = ({sessionId}) : JSX.Element => {

    const [tickets, setTickets] = useState<ticketReadDto[]>([]);
    const [fetchData, isLoading, error] = useFetchingTickets(setTickets, sessionId);


    useEffect(() => {
        fetchData();
    }, [])
    return (
        <div>
            {
                tickets.map((ticket) =>(
                        <AccordionDetails>
                            <Typography>
                                {ticket.id}. Row : {ticket.row} Place : {ticket.place}
                            </Typography>
                        </AccordionDetails>
                ))
            }
        </div>
    );
};

export default AdminTicketsList;