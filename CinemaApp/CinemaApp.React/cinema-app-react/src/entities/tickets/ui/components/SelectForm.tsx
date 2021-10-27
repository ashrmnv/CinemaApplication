import React, {FC, useContext, useState, useEffect} from 'react';
import {Box, FormControl, InputAdornment, InputLabel, MenuItem, Select, SelectChangeEvent} from "@mui/material";
import TextField from "@mui/material/TextField";
import {ticketReadDto} from "../../models/ticketReadDto";
import Button from "@mui/material/Button";
import {useTicketSubmit} from "../../models/useTicketSubmit";
import {AuthContext} from "../../../../app/App";
import SnackbarMessage from "../../../../shared/Snackbar/SnackbarMessage";

interface SelectFormProps{
    tickets : ticketReadDto[];
    fetchData : () => Promise<void>;
    sessionId : number;
}

const SelectForm : FC<SelectFormProps> = ({tickets, fetchData, sessionId}) => {
    const {isAuth, token} = useContext(AuthContext);

    const [row, setRow] = useState<string>('');
    const [place, setPlace] = useState<string>('');
    const [price, setPrice] = useState<number>(0);

    const rowNumbers : number[] = [1,2,3,4,5];
    const placeNumbersDefault : number[] = [1,2,3,4,5,6,7,8,9,10];
    const priceArray : number[] = [25,30,30,45,50]

    useEffect(() => {
        updateSelect()
    }, [sessionId, fetchData]);

    const updateSelect = () => {
        setPlace('');
        setRow('');
        setPrice(0);
    }

    const handlePlaceChange = (event: SelectChangeEvent) => {
        setPlace(event.target.value as string);
    };

    const handleRowChange = (event: SelectChangeEvent) => {
        setRow(event.target.value as string);
        setPlace('');
        setPrice(priceArray[parseInt(event.target.value)-1])
    };

    const [submitBuy, isLoading, error] = useTicketSubmit(isAuth, place, row, price, fetchData, sessionId);

    const [openSnackbar, setOpenSnackbar] = useState<boolean>(false);


    return (
        <Box sx ={{display: "flex", justifyContent:"flex-start"}}>
            <FormControl sx ={{margin : "0 2%", width : "25%"}} >
                <InputLabel id="demo-simple-select-label">Row</InputLabel>
                <Select
                    labelId="demo-simple-select-label"
                    id="demo-simple-select"
                    value={row}
                    label="Row"
                    onChange={handleRowChange}
                >
                    {
                        rowNumbers.map(rowNumber => (
                            <MenuItem value={rowNumber} key={rowNumber} >{rowNumber}</MenuItem>
                        ))
                    }
                </Select>
            </FormControl>
            <FormControl sx ={{margin : "0 2%", width : "25%"}}>
                <InputLabel id="demo-simple-select-label">Place</InputLabel>
                <Select
                    labelId="demo-simple-select-label"
                    id="demo-simple-select"
                    value={place}
                    label="Place"
                    onChange={handlePlaceChange}
                >
                    {
                        placeNumbersDefault.map(function(placeNumber){
                            if (tickets.find((ticket) => ticket.row === parseInt(row))  && tickets.find((ticket) => ticket.place === placeNumber)){
                                return (<MenuItem value={placeNumber} key={placeNumber} disabled>{placeNumber}</MenuItem>)
                            }
                            else{
                                return (<MenuItem value={placeNumber} key={placeNumber}>{placeNumber}</MenuItem>)
                            }
                        })
                    }
                </Select>
            </FormControl>
            <FormControl sx={{margin : "0 2%", width : "25%"}}>
                <TextField
                    label = "Price"
                    variant = "filled"
                    value = {price}
                    disabled
                    id="Price"
                    InputProps={{
                        startAdornment: (
                            <InputAdornment position="start">
                                $
                            </InputAdornment>
                        ),
                    }}
                />
            </FormControl>
            <Button
                variant="contained"
                onClick={() => {
                    submitBuy();
                    setOpenSnackbar(!openSnackbar);
                }}
            >
                Buy ticket
            </Button>
                <SnackbarMessage open={openSnackbar} setOpen={setOpenSnackbar} error={error} isLoading = {isLoading}/>
        </Box>
    );
};

export default SelectForm;