import React, {FC, useEffect, useState} from 'react';
import CommentItem from "./ui/CommentItem";
import CommentForm from "./ui/CommentForm";
import {CommentReadDto} from "../../../entities/comments/comment";
import {getComments} from "./model/getComments";
import Box from '@mui/material/Box';
import Paper from '@mui/material/Paper';

interface CommentsProps{
    movieId : number
}
const CommentsList: FC<CommentsProps> = ({movieId}) : JSX.Element => {
    const [comments, setComments] = useState<CommentReadDto[]>([]);
    const [addNewComment, setAddNewComment] = useState<number>(0);

    useEffect(() => {
        getComments(setComments, movieId);
    },[addNewComment])
    return (
        <Box>
            {
                comments.map(comment => (
                    <CommentItem comment={comment} key={comment.id} setAddNewComment = {setAddNewComment}/>
                ))
            }
            <CommentForm movieId={movieId} setAddNewComment = {setAddNewComment}/>
        </Box>
    );
};

export default CommentsList;