import {showPaginatedComments} from "../../../../features/CommentService";

export const getComments = async (setComments, movieId) => {
    const responsePagedData = await showPaginatedComments({
        PageIndex: 0,
        PageSize: 10,
        columnNameForSorting: "CreatingDate",
        sortDirection: "Descending",
        requestFilters:
            {
                filterLogicalOperator: 0,
                filters: [
                    {
                        path: "MovieId",
                        value: movieId,
                        expression: 0
                    }
                ]
            }
    });
    setComments(responsePagedData.items);
}