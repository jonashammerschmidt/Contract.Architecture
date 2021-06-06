import { BehaviorSubject, ReplaySubject } from 'rxjs';
import { IPagedResult } from 'src/app/services/backend/i-paged-result';

export class MultiDataSource<T> {

    private data: T[] = [];
    public dataSubject = new ReplaySubject<T[]>(1);
    public data$ = this.dataSubject.asObservable();

    private pageSize = 10;
    private pageIndex = -1;
    private filterTerm = '';

    private done = false;

    public loading = false;
    private loadingSubject = new BehaviorSubject<boolean>(false);
    public loading$ = this.loadingSubject.asObservable();

    constructor(
        private paginationGetter: (pageSize: number, pageIndex: number, filterTerm: string) => Promise<IPagedResult<T>>) {
        this.dataSubject.next([]);
        this.loadNext();
    }

    public filter(filterTerm: string): void {
        if (filterTerm !== this.filterTerm) {
            this.filterTerm = filterTerm;

            this.pageIndex = -1;
            this.data = [];
            this.done = false;

            this.dataSubject.next(this.data);
            this.loadNext();
        }
    }

    public loadNext(): void {
        if (!this.done) {
            this.pageIndex++;
            this.loadData();
        }
    }

    private loadData(): void {
        this.loading = true;
        this.loadingSubject.next(true);

        void this.paginationGetter(this.pageSize, this.pageIndex, this.filterTerm)
            .then(paginationPagedResult => {
                this.data = this.data.concat(paginationPagedResult.data);
                if (paginationPagedResult.offset + paginationPagedResult.limit >= paginationPagedResult.totalCount) {
                    this.done = true;
                }
            })
            .finally(() => {
                this.dataSubject.next(this.data);
                this.loading = false;
                this.loadingSubject.next(false);
            });
    }
}
