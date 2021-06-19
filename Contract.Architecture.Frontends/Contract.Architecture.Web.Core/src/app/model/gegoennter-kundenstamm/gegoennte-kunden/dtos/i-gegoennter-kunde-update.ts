import { ApiGegoennterKundeUpdate } from './api/api-gegoennter-kunde-update';
import { IGegoennterKundeDetail } from './i-gegoennter-kunde-detail';

export interface IGegoennterKundeUpdate {
    id: string;
    name: string;
    gegoennterName: string;
    gegoennterBoolean?: boolean;
    gegoennterDateTime?: Date;
    gegoennterDouble?: number;
    gegoennterGuid?: string;
    gegoennterInteger?: number;
    besteBankId: string;
}

export abstract class GegoennterKundeUpdate {
    public static toApiGegoennterKundeUpdate(iGegoennterKundeUpdate: IGegoennterKundeUpdate): ApiGegoennterKundeUpdate {
        return {
            id: iGegoennterKundeUpdate.id,
            name: iGegoennterKundeUpdate.name,
            gegoennterName: iGegoennterKundeUpdate.gegoennterName,
            gegoennterBoolean: iGegoennterKundeUpdate.gegoennterBoolean,
            gegoennterDateTime: iGegoennterKundeUpdate.gegoennterDateTime,
            gegoennterDouble: iGegoennterKundeUpdate.gegoennterDouble,
            gegoennterGuid: iGegoennterKundeUpdate.gegoennterGuid,
            gegoennterInteger: iGegoennterKundeUpdate.gegoennterInteger,
            besteBankId: iGegoennterKundeUpdate.besteBankId,
        };
    }

    public static fromGegoennterKundeDetail(iGegoennterKundeDetail: IGegoennterKundeDetail): IGegoennterKundeUpdate {
        return {
            id: iGegoennterKundeDetail.id,
            name: iGegoennterKundeDetail.name,
            gegoennterName: iGegoennterKundeDetail.gegoennterName,
            gegoennterBoolean: iGegoennterKundeDetail.gegoennterBoolean,
            gegoennterDateTime: iGegoennterKundeDetail.gegoennterDateTime,
            gegoennterDouble: iGegoennterKundeDetail.gegoennterDouble,
            gegoennterGuid: iGegoennterKundeDetail.gegoennterGuid,
            gegoennterInteger: iGegoennterKundeDetail.gegoennterInteger,
            besteBankId: iGegoennterKundeDetail.besteBank.id,
        };
    }
}