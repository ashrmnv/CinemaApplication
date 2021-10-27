import {Expression} from "./Expression";

export interface Filter{
    path : string;
    value : string;
    expression : Expression;
}