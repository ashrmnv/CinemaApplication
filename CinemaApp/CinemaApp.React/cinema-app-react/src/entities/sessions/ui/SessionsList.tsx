import React, {FC, useEffect, useState, createContext} from 'react';
import {sessionReadDto} from "../model/sessionReadDto";
import {getSessions} from "../model/getSession";
import Grid from '@mui/material/Grid';
import Tabs from "@mui/material/Tabs";
import Tab from "@mui/material/Tab";
import Box from "@mui/material/Box";
import TicketsSelector from '../../tickets/ui/TicketsSelector';
import {useFetching} from "../../../shared/hooks/useFetching";

interface SessionsProps{
    movieId : number;
}

const SessionsList : FC<SessionsProps> = ({movieId}) => {

    const [value, setValue] = React.useState(0);
    const [sessions, setSessions] = useState<sessionReadDto[]>([]);
    const [sessionId, setSessionId] = useState<number>(value);

    useEffect(() => {
        getSessions(setSessions, setValue, movieId);
    }, [])

    const handleChange = (event: React.SyntheticEvent, newValue: number) => {
        setValue(newValue);
        setSessionId(newValue);
    };
    if (sessions.length === 0)
        return (
            <Box sx={{ width: '100%' }}>
                <Box sx={{ maxWidth: "90%", bgcolor: 'background.paper', display : "flex", justifyContent : "center" }}>
                    <h1>Sessions was not added yet</h1>
                </Box>
            </Box>
        );
    else{
        return (
            <Grid item container sx={{ width: '100%' }}>
                <Box sx={{ maxWidth: "90%", bgcolor: 'background.paper' }}>
                    <Tabs
                        value={value}
                        onChange={handleChange}
                        aria-label="scrollable auto tabs example"
                        variant="scrollable"
                        scrollButtons="auto"
                    >
                        {
                            sessions.map(session => (
                                <Tab
                                    label={session.dateTime.toString().replace("T", " ")}
                                    key={session.id}
                                    value={session.id}
                                />
                            ))
                        }
                    </Tabs>
                </Box>
                <TicketsSelector sessionId = {sessionId}/>
            </Grid>
        );
    }

};

export default SessionsList;