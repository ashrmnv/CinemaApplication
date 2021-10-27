import React, {FC, useContext, useState} from 'react';
import TextField from '@mui/material/TextField';
import * as yup from "yup";
import Button from "@mui/material/Button";
import {useForm} from "react-hook-form";
import {yupResolver} from "@hookform/resolvers/yup";
import {CommentCreate} from "../../../../entities/comments/commentCreate";
import {addNewComment} from "../../../../features/CommentService";
import {AuthContext} from "../../../../app/App";

interface CommentFormProps{
    movieId : number;
    setAddNewComment : React.Dispatch<React.SetStateAction<number>>;
}
const CommentForm : FC<CommentFormProps> = ({movieId, setAddNewComment}) : JSX.Element => {
    const {isAuth, token} = useContext(AuthContext);
    const [value, setValue] = useState<string>("");
    
    const schema = yup.object().shape({
        body : yup.string().max(1000).required()
    })
    const {register, handleSubmit, errors} : any = useForm({resolver:yupResolver(schema)})
    const onSubmitHandler = async (data) => {
        if (isAuth){
            const date = new Date();
            const userId = localStorage.getItem('id');
            console.log(data.body);
            const commentData : CommentCreate = {
                body : data.body,
                creatingDate : date,
                userId : parseInt(userId !== null ? userId : "-1"),
                movieId : movieId
            }
            const response = await addNewComment(commentData, token);
            setAddNewComment(response.id);
            setValue("");
        }
        else{
            alert("Need to login");
        }
    };

    return (
        <form onSubmit={handleSubmit(onSubmitHandler)}>
            <TextField
                {...register("body")} 
                id="outlined-multiline-flexible"
                label="Add Comment"
                multiline
                maxRows={4}
                value={value}
                onChange={(e) => setValue(e.target.value)}
                sx = {{width : "100%"}}
            />
            <Button variant="contained" type = "submit" sx={{mt : 2}}>
                Add Comment
            </Button>
        </form>
    );
};

export default CommentForm;