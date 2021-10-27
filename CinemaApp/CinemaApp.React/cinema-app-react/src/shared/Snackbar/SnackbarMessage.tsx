import React, {FC} from 'react';
import InfoSnackbar from "./InfoSnackbar";

interface MessageProps{
    error : string;
    isLoading : boolean;
    open : boolean;
    setOpen : React.Dispatch<React.SetStateAction<boolean>>;
}

const SnackbarMessage: FC<MessageProps> = ({error, isLoading, open, setOpen}) : JSX.Element => {
    console.log(open);
    if (error !== ""){
        return <InfoSnackbar open={open} setOpen={setOpen} message = {error} type="error"/>
    }
    else{
        return(
            <div>
                {
                    isLoading
                    ?
                    <InfoSnackbar open={open} setOpen={setOpen} message = "Loading..." type="success"/>
                    :
                    <InfoSnackbar open={open} setOpen={setOpen} message = "Completed successfully" type="success"/>
                }
            </div>
            );
    }
}

export default SnackbarMessage;