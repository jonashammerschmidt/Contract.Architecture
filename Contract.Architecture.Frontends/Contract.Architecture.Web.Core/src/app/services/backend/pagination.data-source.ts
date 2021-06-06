import { DataSource } from '@angular/cdk/collections';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { BehaviorSubject, merge, Observable } from 'rxjs';
import { tap } from 'rxjs/operators';
import { TableFilterBarComponent } from 'src/app/components/ui/table-filter-bar/table-filter-bar.component';
import { IPaginationFilterItem, IPaginationOptions } from 'src/app/services/backend/i-pagionation-options';
import { IPagedResult } from './i-paged-result';

export class PaginationDataSource<T> implements DataSource<T> {

    private paginationSubject = new BehaviorSubject<T[]>([]);
    private paginationTotalCountSubject = new BehaviorSubject<number>(0);
    private loadingSubject = new BehaviorSubject<boolean>(false);

    public totalCount$ = this.paginationTotalCountSubject.asObservable();
    public loading$ = this.loadingSubject.asObservable();

    constructor(
        private paginationGetter: (paginationOptions: IPaginationOptions) => Promise<IPagedResult<T>>,
        private filterResolve: () => IPaginationFilterItem[]) {
    }

    public initialize(
        tableFilterBarComponent: TableFilterBarComponent,
        matPaginator: MatPaginator,
        matSort: MatSort): void {
        this.loadData({ limit: 10, offset: 0 });

        merge(
            matSort.sortChange,
            tableFilterBarComponent.filterTermChange,
            tableFilterBarComponent.filterItemsValuesChange)
            .pipe(
                tap(() => matPaginator.pageIndex = 0),
            ).subscribe();

        merge(
            matSort.sortChange,
            matPaginator.page,
            tableFilterBarComponent.filterTermChange,
            tableFilterBarComponent.filterItemsValuesChange)
            .pipe(
                tap(() => {
                    const options: IPaginationOptions = {
                        limit: matPaginator.pageSize,
                        offset: matPaginator.pageIndex * matPaginator.pageSize,
                        sortField: matSort.active,
                        sortDirection: matSort.direction,
                        filters: this.filterResolve()
                    };
                    this.loadData(options);
                })
            ).subscribe();
    }

    connect(): Observable<T[]> {
        return this.paginationSubject.asObservable();
    }

    disconnect(): void {
        this.paginationSubject.complete();
        this.loadingSubject.complete();
    }

    loadData(paginationOptions: IPaginationOptions): void {
        this.loadingSubject.next(true);

        void this.paginationGetter(paginationOptions)
            .then(paginationPagedResult => {
                this.paginationSubject.next(paginationPagedResult.data);
                this.paginationTotalCountSubject.next(paginationPagedResult.totalCount);
            })
            .catch(() => this.paginationSubject.next([]))
            .finally(() => this.loadingSubject.next(false));
    }
}
