import React, {FC, useEffect, useState} from 'react';
import { getSessions } from '../../MovieDetails/Sessions/model/getSession';
import Accordion from '@mui/material/Accordion';
import AccordionSummary from '@mui/material/AccordionSummary';
import AccordionDetails from '@mui/material/AccordionDetails';
import Typography from '@mui/material/Typography';
import ExpandMoreIcon from '@mui/icons-material/ExpandMore';
import {sessionReadDto} from "../../../entities/sessions/sessionReadDto";
import AdminTicketsList from "./AdminTicketsList";

interface SessionListProps{
    movieId : number;
}
const AdminSessionList : FC<SessionListProps> = ({movieId}) : JSX.Element => {
    const [value, setValue] = useState<number>(0);
    const [sessions, setSessions] = useState<sessionReadDto[]>([]);
    const [sessionId, setSessionId] = useState<number>(value);

    useEffect(() => {
        getSessions(setSessions, setValue, movieId);
    }, [])
    return (
        <div>
            {
                sessions.map((session) =>(
                    <Accordion>
                        <AccordionSummary
                            expandIcon={<ExpandMoreIcon />}
                            aria-controls="panel1a-content"
                            id="panel1a-header"
                            >
                            <Typography>{session.id} : {session.dateTime.toString().replace("T", " ")}</Typography>
                        </AccordionSummary>
                        <AdminTicketsList sessionId = {session.id}/>
                    </Accordion>
                ))
            }
        </div>
    );
};

export default AdminSessionList;