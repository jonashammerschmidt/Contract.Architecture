import { ApiGegoennterKundeCreate } from './api/api-gegoennter-kunde-create';

export interface IGegoennterKundeCreate {
    name: string;
    gegoennterName: string;
    gegoennterBoolean?: boolean;
    gegoennterDateTime?: Date;
    gegoennterDouble?: number;
    gegoennterGuid?: string;
    gegoennterInteger?: number;
    besteBankId: string;
}

export abstract class GegoennterKundeCreate {
    public static toApiGegoennterKundeCreate(iGegoennterKundeCreate: IGegoennterKundeCreate): ApiGegoennterKundeCreate {
        return {
            name: iGegoennterKundeCreate.name,
            gegoennterName: iGegoennterKundeCreate.gegoennterName,
            gegoennterBoolean: iGegoennterKundeCreate.gegoennterBoolean,
            gegoennterDateTime: iGegoennterKundeCreate.gegoennterDateTime,
            gegoennterDouble: iGegoennterKundeCreate.gegoennterDouble,
            gegoennterGuid: iGegoennterKundeCreate.gegoennterGuid,
            gegoennterInteger: iGegoennterKundeCreate.gegoennterInteger,
            besteBankId: iGegoennterKundeCreate.besteBankId,
        };
    }
}
