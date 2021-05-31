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
        requestUrl += `&sort.${paginationOptions.sortDirection}=${paginationOptions.sortField}`;
    }

    if (paginationOptions.filters) {
        for (const filterItem of paginationOptions.filters) {
            if (filterItem.filterField &&
                filterItem.filterField.length > 0) {
                if (filterItem.equalsFilters && filterItem.equalsFilters.length > 0) {
                    const orChar = encodeURI('|');
                    const filterValue = filterItem.equalsFilters
                        .map(filterOrItem => filterOrItem).join(orChar);
                    requestUrl += `&filter.${filterItem.filterField}=${filterValue}`;
                }

                if (filterItem.containsFilters && filterItem.containsFilters.length > 0) {
                    const percentChar = encodeURI('%');
                    const orChar = encodeURI('|');
                    const filterValue = filterItem.containsFilters
                        .map(filterOrItem => percentChar + filterOrItem + percentChar).join(orChar);
                    requestUrl += `&filter.${filterItem.filterField}=${filterValue}`;
                }
            }
        }
    }

    return requestUrl;
}
