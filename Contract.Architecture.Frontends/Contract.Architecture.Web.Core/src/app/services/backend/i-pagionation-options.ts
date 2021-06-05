export interface IPaginationOptions {
    limit: number;
    offset: number;
    sortField?: string;
    sortDirection?: string;
    filters?: IPaginationFilterItem[];
}

export interface IPaginationFilterItem {
    filterField: string;
    equalsFilters?: string[];
    containsFilters?: string[];
}

export function toPaginationParams(paginationOptions: IPaginationOptions): string {
    let requestUrl =
        `limit=${paginationOptions.limit}` +
        `&offset=${paginationOptions.offset}`;

    if (paginationOptions.sortField &&
        paginationOptions.sortField.length > 0 &&
        paginationOptions.sortDirection &&
        paginationOptions.sortDirection.length > 0) {
        requestUrl += `&sort.${encodeURI(paginationOptions.sortDirection)}=${encodeURI(paginationOptions.sortField)}`;
    }

    if (paginationOptions.filters) {
        for (const filterItem of paginationOptions.filters) {
            if (filterItem.filterField &&
                filterItem.filterField.length > 0) {
                if (filterItem.equalsFilters && filterItem.equalsFilters.length > 0) {
                    const filterValue = filterItem.equalsFilters
                    .map(filterOrItem => filterOrItem).join('|');
                    requestUrl += `&filter.${encodeURI(filterItem.filterField)}=${encodeURI(filterValue)}`;
                }

                if (filterItem.containsFilters && filterItem.containsFilters.length > 0) {
                    const filterValue = filterItem.containsFilters
                        .map(filterOrItem => '%' + filterOrItem + '%').join('|');
                    requestUrl += `&filter.${encodeURI(filterItem.filterField)}=${encodeURI(filterValue)}`;
                }
            }
        }
    }

    return requestUrl;
}
