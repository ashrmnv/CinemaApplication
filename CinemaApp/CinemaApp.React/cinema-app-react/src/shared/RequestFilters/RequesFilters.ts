import { Filter } from "./Filter";

export interface RequestFilters{
    filterLogicalOperator : number;
    filters : Filter[];
}