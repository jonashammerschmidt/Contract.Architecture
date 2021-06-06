import { MultiDataSource } from './table-filter-bar-dropdown-multi/multi-data-source';

export interface TableFilterBarDropdownItem {
    dataName: string;
    dataSource: MultiDataSource<any>;
    valueExpr: string;
    displayExpr: string;
}
