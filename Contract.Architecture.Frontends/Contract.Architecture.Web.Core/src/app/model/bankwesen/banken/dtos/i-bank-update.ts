import { ApiBankUpdate } from './api/api-bank-update';
import { IBankDetail } from './i-bank-detail';

export interface IBankUpdate {
    id: string;
    name: string;
    boolean: boolean;
    dateTime: Date;
    double: number;
    guid: string;
    integer: number;
}

export abstract class BankUpdate {
    public static toApiBankUpdate(iBankUpdate: IBankUpdate): ApiBankUpdate {
        return {
            id: iBankUpdate.id,
            name: iBankUpdate.name,
            boolean: iBankUpdate.boolean,
            dateTime: iBankUpdate.dateTime,
            double: iBankUpdate.double,
            guid: iBankUpdate.guid,
            integer: iBankUpdate.integer,
        };
    }

    public static fromBankDetail(iBankDetail: IBankDetail): IBankUpdate {
        return {
            id: iBankDetail.id,
            name: iBankDetail.name,
            boolean: iBankDetail.boolean,
            dateTime: iBankDetail.dateTime,
            double: iBankDetail.double,
            guid: iBankDetail.guid,
            integer: iBankDetail.integer,
        };
    }
}