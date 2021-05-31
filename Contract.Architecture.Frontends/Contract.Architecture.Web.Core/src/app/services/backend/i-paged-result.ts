export interface IPagedResult<T> {
    count: number;
    data: T[];
    limit: number;
    offset: number;
    totalCount: number;
}
