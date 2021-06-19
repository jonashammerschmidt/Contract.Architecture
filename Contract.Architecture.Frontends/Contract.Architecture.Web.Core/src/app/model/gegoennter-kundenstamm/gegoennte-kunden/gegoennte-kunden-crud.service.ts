import { Injectable } from '@angular/core';
import { BackendCoreService } from 'src/app/services/backend/backend-core.service';
import { IPagedResult } from 'src/app/services/backend/i-paged-result';
import { IPaginationOptions, toPaginationParams } from 'src/app/services/backend/i-pagionation-options';
import { ApiGegoennterKunde } from './dtos/api/api-gegoennter-kunde';
import { ApiGegoennterKundeDetail } from './dtos/api/api-gegoennter-kunde-detail';
import { GegoennterKunde, IGegoennterKunde } from './dtos/i-gegoennter-kunde';
import { GegoennterKundeCreate, IGegoennterKundeCreate } from './dtos/i-gegoennter-kunde-create';
import { GegoennterKundeDetail, IGegoennterKundeDetail } from './dtos/i-gegoennter-kunde-detail';
import { GegoennterKundeUpdate, IGegoennterKundeUpdate } from './dtos/i-gegoennter-kunde-update';

@Injectable()
export class GegoennteKundenCrudService {

    constructor(private backendCoreService: BackendCoreService) { }

    public async getGegoennteKunden(paginationOptions: IPaginationOptions): Promise<IPagedResult<IGegoennterKunde>> {
        const url = '/api/gegoennter-kundenstamm/gegoennte-kunden?' + toPaginationParams(paginationOptions);
        const gegoennteKundenResult = await this.backendCoreService.get<IPagedResult<ApiGegoennterKunde>>(url);

        gegoennteKundenResult.data = gegoennteKundenResult.data
            .map(apiGegoennterKunde => GegoennterKunde.fromApiGegoennterKunde(apiGegoennterKunde));
        return gegoennteKundenResult;
    }

    public async getGegoennterKundeDetail(gegoennterKundeId: string): Promise<IGegoennterKundeDetail> {
        const apiGegoennterKundeDetail = await this.backendCoreService.get<ApiGegoennterKundeDetail>('/api/gegoennter-kundenstamm/gegoennte-kunden/' + gegoennterKundeId);

        const gegoennterKundeDetail = GegoennterKundeDetail.fromApiGegoennterKundeDetail(apiGegoennterKundeDetail);
        return gegoennterKundeDetail;
    }

    public async createGegoennterKunde(gegoennterKundeCreate: IGegoennterKundeCreate): Promise<string> {
        const options = {
            body: GegoennterKundeCreate.toApiGegoennterKundeCreate(gegoennterKundeCreate)
        };

        const result = await this.backendCoreService.post<{ data: string }>('/api/gegoennter-kundenstamm/gegoennte-kunden', options);

        const newGegoennterKundeId = result.data;
        return newGegoennterKundeId;
    }

    public async updateGegoennterKunde(gegoennterKundeUpdate: IGegoennterKundeUpdate): Promise<void> {
        const options = {
            body: GegoennterKundeUpdate.toApiGegoennterKundeUpdate(gegoennterKundeUpdate)
        };

        await this.backendCoreService.put('/api/gegoennter-kundenstamm/gegoennte-kunden', options);
    }

    public async deleteGegoennterKunde(gegoennterKundeId: string): Promise<void> {
        await this.backendCoreService.delete('/api/gegoennter-kundenstamm/gegoennte-kunden/' + gegoennterKundeId);
    }

}
