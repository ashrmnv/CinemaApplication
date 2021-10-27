import React,{FC, useState} from 'react';
import {CommentReadDto} from '../model/comment';
import {CommentUpdateDto} from '../model/commentUpdateDto';
import {deleteComment} from '../../../features/CommentService';
import {updateComment} from '../../../features/CommentService';
import TextField from '@mui/material/TextField';
import Card from '@mui/material/Card';
import CardActions from '@mui/material/CardActions';
import CardContent from '@mui/material/CardContent';
import Button from '@mui/material/Button';
import Typography from '@mui/material/Typography';
import * as yup from "yup";
import {useForm} from "react-hook-form";
import {yupResolver} from "@hookform/resolvers/yup";


interface CommentProps{
    comment : CommentReadDto;
    setAddNewComment : React.Dispatch<React.SetStateAction<number>>;
}
const CommentItem: FC<CommentProps> = ({comment, setAddNewComment}) : JSX.Element => {

    const userIdCheck = localStorage.getItem('id');
    const userId = parseInt(userIdCheck !== null ? userIdCheck : "-1");
    const roleCheck = localStorage.getItem('role');
    const userRole = roleCheck !== null ? roleCheck : "unAuth";
    const [isUpdating, setIsUpdating] = useState<boolean>(false);
    const [newValue, setNewValue] = useState<string>(comment.body);

    const deleteAction = async () => {
        const tokenCheck = localStorage.getItem('token');
        const token = tokenCheck ? tokenCheck : " ";
        await deleteComment(comment.id, token);
        setAddNewComment(comment.id * comment.id);
    }

    const schema = yup.object().shape({
        body : yup.string().max(1000).required()
    })
    const {register, handleSubmit, errors} : any = useForm({resolver:yupResolver(schema)})
    const updateAction = async () => {
        const date = new Date();
        const updatedComment : CommentUpdateDto = {
            body : newValue,
            creatingDate : date,
            userId : userId
        }
        const tokenCheck = localStorage.getItem('token');
        const token = tokenCheck ? tokenCheck : " ";
        const response = await updateComment(updatedComment, comment.id, token);
        setIsUpdating(false);
        setAddNewComment(-1);

    }

    const creatingDate = new Date(comment.creatingDate);
    return(
        <Card sx={{ width: '100%', margin : "2% 0" }}>
            <CardContent>
                <Typography variant="body2" component="div" color="text.secondary">
                    {comment.userDto.login} {creatingDate.toLocaleDateString("en-US")} {creatingDate.toLocaleTimeString("it-IT")}
                </Typography>
                {
                    isUpdating
                        ?
                        <form onSubmit={handleSubmit(updateAction)}>
                            <TextField
                                {...register("body")}
                                maxRows={4}
                                value={newValue}
                                onChange={(e) => setNewValue(e.target.value)}
                                sx = {{width : "100%"}}
                            />
                            <Button size="small" type = "submit">Save changes</Button>
                        </form>
                        :
                        <Typography variant="h5" >
                            {comment.body}
                        </Typography>
                }
            </CardContent>
            <CardActions sx={{display : "flex", justifyContent : "flex-end"}}>
                {
                    !isUpdating && userId === comment.userDto.id
                        ?
                        <Button size="small" type = "button" onClick={() => setIsUpdating(true)}>Update</Button>
                        :
                        <div></div>
                }
                {
                    userId === comment.userDto.id || userRole === "admin"
                        ?
                        <Button size="small" onClick={deleteAction}>Delete</Button>
                        :
                        <div></div>
                }
            </CardActions>
        </Card>
    );
}

export default CommentItem;