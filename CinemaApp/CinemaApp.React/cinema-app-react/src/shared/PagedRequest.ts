import { RequestFilters } from "./RequesFilters";

export interface PagedRequest{
    PageIndex : number;
    PageSize : number;
    columnNameForSorting : string;
    sortDirection : string;
    requestFilters : RequestFilters
}