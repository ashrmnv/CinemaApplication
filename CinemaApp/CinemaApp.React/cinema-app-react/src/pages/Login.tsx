import React, {FC, useState} from 'react';
import * as yup from 'yup';
import {useForm} from 'react-hook-form';
import {yupResolver} from '@hookform/resolvers/yup';
import {getToken} from "../services/UserService";

const Login : FC = () : JSX.Element =>{
    const schema = yup.object().shape({
        email : yup.string().max(100).required(),
        password : yup.string().required()
    })
    const [token, setToken] = useState<string>("");
    const {register, handleSubmit, errors} : any = useForm({resolver:yupResolver(schema)})
    const onSubmitHandler = async (data) => {
        const response = await getToken(data);
        console.log(response);
    };
    return(
        <div>
            <form onSubmit={handleSubmit(onSubmitHandler)}>
                <label>
                    <p>Email</p>
                    <input {...register("email")} type="email"/>
                    <p>{errors?.email.message}</p>
                </label>
                <label>
                    <p>Password</p>
                    <input {...register("password")} type="password"/>
                    <p>{errors?.password.message}</p>
                </label>
                <div>
                    <button type="submit">Submit</button>
                </div>
            </form>
        </div>
    );
}

export default Login;