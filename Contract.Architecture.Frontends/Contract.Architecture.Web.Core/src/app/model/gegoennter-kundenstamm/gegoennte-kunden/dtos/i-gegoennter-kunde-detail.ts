import { GegoennteBank, IGegoennteBank } from 'src/app/model/gegoenntes-bankwesen/gegoennte-banken/dtos/i-gegoennte-bank';
import { ApiGegoennterKundeDetail } from './api/api-gegoennter-kunde-detail';

export interface IGegoennterKundeDetail {
    id: string;
    name: string;
    gegoennterName: string;
    gegoennterBoolean?: boolean;
    gegoennterDateTime?: Date;
    gegoennterDouble?: number;
    gegoennterGuid?: string;
    gegoennterInteger?: number;
    besteBank: IGegoennteBank;
}

export abstract class GegoennterKundeDetail {
    public static fromApiGegoennterKundeDetail(apiGegoennterKundeDetail: ApiGegoennterKundeDetail): IGegoennterKundeDetail {
        return {
            id: apiGegoennterKundeDetail.id,
            name: apiGegoennterKundeDetail.name,
            gegoennterName: apiGegoennterKundeDetail.gegoennterName,
            gegoennterBoolean: apiGegoennterKundeDetail.gegoennterBoolean,
            gegoennterDateTime: apiGegoennterKundeDetail.gegoennterDateTime,
            gegoennterDouble: apiGegoennterKundeDetail.gegoennterDouble,
            gegoennterGuid: apiGegoennterKundeDetail.gegoennterGuid,
            gegoennterInteger: apiGegoennterKundeDetail.gegoennterInteger,
            besteBank: GegoennteBank.fromApiGegoennteBank(apiGegoennterKundeDetail.besteBank),
        };
    }
}
