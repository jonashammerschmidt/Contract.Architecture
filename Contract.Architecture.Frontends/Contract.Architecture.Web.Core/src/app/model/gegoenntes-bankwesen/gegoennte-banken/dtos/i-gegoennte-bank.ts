import { ApiGegoennteBank } from './api/api-gegoennte-bank';

export interface IGegoennteBank {
    id: string;
    name: string;
    gegoennterName: string;
    gegoennterBoolean: boolean;
    gegoenntesDateTime: Date;
    gegoennterDouble: number;
    gegoennteGuid: string;
    gegoennterInteger: number;
}

export class GegoennteBank {
    public static fromApiGegoennteBank(apiGegoennteBank: ApiGegoennteBank): IGegoennteBank {
        return {
            id: apiGegoennteBank.id,
            name: apiGegoennteBank.name,
            gegoennterName: apiGegoennteBank.gegoennterName,
            gegoennterBoolean: apiGegoennteBank.gegoennterBoolean,
            gegoenntesDateTime: apiGegoennteBank.gegoenntesDateTime,
            gegoennterDouble: apiGegoennteBank.gegoennterDouble,
            gegoennteGuid: apiGegoennteBank.gegoennteGuid,
            gegoennterInteger: apiGegoennteBank.gegoennterInteger,
        };
    }
}
