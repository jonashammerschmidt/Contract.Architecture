import { Injectable } from '@angular/core';
import { BackendCoreService } from 'src/app/services/backend/backend-core.service';
import { ApiBank } from './dtos/api/api-bank';
import { ApiBankDetail } from './dtos/api/api-bank-detail';
import { Bank, IBank } from './dtos/i-bank';
import { BankCreate, IBankCreate } from './dtos/i-bank-create';
import { BankDetail, IBankDetail } from './dtos/i-bank-detail';
import { BankUpdate, IBankUpdate } from './dtos/i-bank-update';

@Injectable()
export class BankenCrudService {

    constructor(private backendCoreService: BackendCoreService) { }

    public async getBanken(): Promise<IBank[]> {
        const apiBanken = await this.backendCoreService.get<ApiBank[]>('/api/bankwesen/banken');

        const banken = apiBanken.map(apiBank => Bank.fromApiBank(apiBank));
        return banken;
    }

    public async getBankDetail(bankId: string): Promise<IBankDetail> {
        const apiBankDetail = await this.backendCoreService.get<ApiBankDetail>('/api/bankwesen/banken/' + bankId);

        const bankDetail = BankDetail.fromApiBankDetail(apiBankDetail);
        return bankDetail;
    }

    public async createBank(bankCreate: IBankCreate): Promise<string> {
        const options = {
            body: BankCreate.toApiBankCreate(bankCreate)
        };

        const result = await this.backendCoreService.post<{ data: string }>('/api/bankwesen/banken', options);

        const newBankId = result.data;
        return newBankId;
    }

    public async updateBank(bankUpdate: IBankUpdate): Promise<void> {
        const options = {
            body: BankUpdate.toApiBankUpdate(bankUpdate)
        };

        await this.backendCoreService.put('/api/bankwesen/banken', options);
    }

    public async deleteBank(bankId: string): Promise<void> {
        await this.backendCoreService.delete('/api/bankwesen/banken/' + bankId);
    }

}
