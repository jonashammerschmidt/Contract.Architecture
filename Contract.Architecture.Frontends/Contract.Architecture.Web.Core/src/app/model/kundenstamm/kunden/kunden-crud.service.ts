import { Injectable } from '@angular/core';
import { BackendCoreService } from 'src/app/services/backend/backend-core.service';
import { ApiKunde } from './dtos/api/api-kunde';
import { ApiKundeDetail } from './dtos/api/api-kunde-detail';
import { Kunde, IKunde } from './dtos/i-kunde';
import { KundeCreate, IKundeCreate } from './dtos/i-kunde-create';
import { KundeDetail, IKundeDetail } from './dtos/i-kunde-detail';
import { KundeUpdate, IKundeUpdate } from './dtos/i-kunde-update';

@Injectable()
export class KundenCrudService {

    constructor(private backendCoreService: BackendCoreService) { }

    public async getKunden(): Promise<IKunde[]> {
        const apiKunden = await this.backendCoreService.get<ApiKunde[]>('/api/kundenstamm/kunden');

        const kunden = apiKunden.map(apiKunde => Kunde.fromApiKunde(apiKunde));
        return kunden;
    }

    public async getKundeDetail(kundeId: string): Promise<IKundeDetail> {
        const apiKundeDetail = await this.backendCoreService.get<ApiKundeDetail>('/api/kundenstamm/kunden/' + kundeId);

        const kundeDetail = KundeDetail.fromApiKundeDetail(apiKundeDetail);
        return kundeDetail;
    }

    public async createKunde(kundeCreate: IKundeCreate): Promise<string> {
        const options = {
            body: KundeCreate.toApiKundeCreate(kundeCreate)
        };

        const result = await this.backendCoreService.post<{ data: string }>('/api/kundenstamm/kunden', options);

        const newKundeId = result.data;
        return newKundeId;
    }

    public async updateKunde(kundeUpdate: IKundeUpdate): Promise<void> {
        const options = {
            body: KundeUpdate.toApiKundeUpdate(kundeUpdate)
        };

        await this.backendCoreService.put('/api/kundenstamm/kunden', options);
    }

    public async deleteKunde(kundeId: string): Promise<void> {
        await this.backendCoreService.delete('/api/kundenstamm/kunden/' + kundeId);
    }

}
