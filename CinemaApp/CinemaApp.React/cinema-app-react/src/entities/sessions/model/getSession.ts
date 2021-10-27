import {showPaginatedSessions} from "../../../features/SessionService";

export const getSessions = async (setSessions, setValue, movieId) => {
    const responsePagedData = await showPaginatedSessions({
        PageIndex: 0,
        PageSize: 10,
        columnNameForSorting: "DateTime",
        sortDirection: "Descending",
        requestFilters:
            {
                filterLogicalOperator: 0,
                filters: [
                    {
                        path: "MovieId",
                        value: movieId.toString(),
                        expression: 0
                    }
                ]
            }
    });
    setSessions(responsePagedData.items);
    if ( responsePagedData.items.length !== 0) setValue(responsePagedData.items[0].id)
}