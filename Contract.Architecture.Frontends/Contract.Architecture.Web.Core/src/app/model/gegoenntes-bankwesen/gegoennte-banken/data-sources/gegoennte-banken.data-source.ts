import { CollectionViewer, DataSource } from '@angular/cdk/collections';
import { BehaviorSubject, Observable } from 'rxjs';
import { GegoennteBankenCrudService } from 'src/app/model/gegoenntes-bankwesen/gegoennte-banken/gegoennte-banken-crud.service';
import { IGegoennteBank } from '../dtos/i-gegoennte-bank';
import { IPaginationOptions } from 'src/app/services/backend/i-pagionation-options';

export class GegoennteBankenDataSource implements DataSource<IGegoennteBank> {

    private gegoennteBankenSubject = new BehaviorSubject<IGegoennteBank[]>([]);
    private gegoennteBankenTotalCountSubject = new BehaviorSubject<number>(0);
    private loadingSubject = new BehaviorSubject<boolean>(false);

    public gegoennteBankenTotalCount$ = this.gegoennteBankenTotalCountSubject.asObservable();
    public loading$ = this.loadingSubject.asObservable();

    constructor(private gegoennteBankenCrudService: GegoennteBankenCrudService) { }

    connect(): Observable<IGegoennteBank[]> {
        return this.gegoennteBankenSubject.asObservable();
    }

    disconnect(): void {
        this.gegoennteBankenSubject.complete();
        this.loadingSubject.complete();
    }

    loadGegoennteBanken(paginationOptions: IPaginationOptions): void {
        this.loadingSubject.next(true);

        void this.gegoennteBankenCrudService.getGegoennteBanken(paginationOptions)
            .then(gegoennteBankenPagedResult => {
                this.gegoennteBankenSubject.next(gegoennteBankenPagedResult.data);
                this.gegoennteBankenTotalCountSubject.next(gegoennteBankenPagedResult.totalCount);
            })
            .catch(() => this.gegoennteBankenSubject.next([]))
            .finally(() => this.loadingSubject.next(false));
    }
}
