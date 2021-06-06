import { Injectable } from '@angular/core';
import { BackendCoreService } from 'src/app/services/backend/backend-core.service';
import { IPagedResult } from 'src/app/services/backend/i-paged-result';
import { IPaginationOptions, toPaginationParams } from 'src/app/services/backend/i-pagionation-options';
import { ApiGegoennteBank } from './dtos/api/api-gegoennte-bank';
import { ApiGegoennteBankDetail } from './dtos/api/api-gegoennte-bank-detail';
import { GegoennteBank, IGegoennteBank } from './dtos/i-gegoennte-bank';
import { GegoennteBankCreate, IGegoennteBankCreate } from './dtos/i-gegoennte-bank-create';
import { GegoennteBankDetail, IGegoennteBankDetail } from './dtos/i-gegoennte-bank-detail';
import { GegoennteBankUpdate, IGegoennteBankUpdate } from './dtos/i-gegoennte-bank-update';

@Injectable()
export class GegoennteBankenCrudService {

    constructor(private backendCoreService: BackendCoreService) { }

    public async getGegoennteBanken(paginationOptions: IPaginationOptions): Promise<IPagedResult<IGegoennteBank>> {
        const url = '/api/gegoenntes-bankwesen/gegoennte-banken?' + toPaginationParams(paginationOptions);
        const gegoennteBankenResult = await this.backendCoreService.get<IPagedResult<ApiGegoennteBank>>(url);

        gegoennteBankenResult.data = gegoennteBankenResult.data
            .map(apiGegoennteBank => GegoennteBank.fromApiGegoennteBank(apiGegoennteBank));
        return gegoennteBankenResult;
    }

    public async getGegoennteBankDetail(gegoennteBankId: string): Promise<IGegoennteBankDetail> {
        const apiGegoennteBankDetail = await this.backendCoreService.get<ApiGegoennteBankDetail>('/api/gegoenntes-bankwesen/gegoennte-banken/' + gegoennteBankId);

        const gegoennteBankDetail = GegoennteBankDetail.fromApiGegoennteBankDetail(apiGegoennteBankDetail);
        return gegoennteBankDetail;
    }

    public async createGegoennteBank(gegoennteBankCreate: IGegoennteBankCreate): Promise<string> {
        const options = {
            body: GegoennteBankCreate.toApiGegoennteBankCreate(gegoennteBankCreate)
        };

        const result = await this.backendCoreService.post<{ data: string }>('/api/gegoenntes-bankwesen/gegoennte-banken', options);

        const newGegoennteBankId = result.data;
        return newGegoennteBankId;
    }

    public async updateGegoennteBank(gegoennteBankUpdate: IGegoennteBankUpdate): Promise<void> {
        const options = {
            body: GegoennteBankUpdate.toApiGegoennteBankUpdate(gegoennteBankUpdate)
        };

        await this.backendCoreService.put('/api/gegoenntes-bankwesen/gegoennte-banken', options);
    }

    public async deleteGegoennteBank(gegoennteBankId: string): Promise<void> {
        await this.backendCoreService.delete('/api/gegoenntes-bankwesen/gegoennte-banken/' + gegoennteBankId);
    }

}
