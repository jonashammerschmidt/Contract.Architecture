import { ApiGegoennterKunde } from './api/api-gegoennter-kunde';

export interface IGegoennterKunde {
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

export class GegoennterKunde {
    public static fromApiGegoennterKunde(apiGegoennterKunde: ApiGegoennterKunde): IGegoennterKunde {
        return {
            id: apiGegoennterKunde.id,
            name: apiGegoennterKunde.name,
            gegoennterName: apiGegoennterKunde.gegoennterName,
            gegoennterBoolean: apiGegoennterKunde.gegoennterBoolean,
            gegoennterDateTime: apiGegoennterKunde.gegoennterDateTime,
            gegoennterDouble: apiGegoennterKunde.gegoennterDouble,
            gegoennterGuid: apiGegoennterKunde.gegoennterGuid,
            gegoennterInteger: apiGegoennterKunde.gegoennterInteger,
            besteBankId: apiGegoennterKunde.besteBankId,
        };
    }
}
