import { ApiKundeUpdate } from './api/api-kunde-update';
import { IKundeDetail } from './i-kunde-detail';

export interface IKundeUpdate {
    id: string;
    name?: string;
    boolean?: boolean;
    dateTime?: Date;
    double?: number;
    guid?: string;
    integer?: number;
    bankId: string;
}

export abstract class KundeUpdate {
    public static toApiKundeUpdate(iKundeUpdate: IKundeUpdate): ApiKundeUpdate {
        return {
            id: iKundeUpdate.id,
            name: iKundeUpdate.name,
            boolean: iKundeUpdate.boolean,
            dateTime: iKundeUpdate.dateTime,
            double: iKundeUpdate.double,
            guid: iKundeUpdate.guid,
            integer: iKundeUpdate.integer,
            bankId: iKundeUpdate.bankId,
        };
    }

    public static fromKundeDetail(iKundeDetail: IKundeDetail): IKundeUpdate {
        return {
            id: iKundeDetail.id,
            name: iKundeDetail.name,
            boolean: iKundeDetail.boolean,
            dateTime: iKundeDetail.dateTime,
            double: iKundeDetail.double,
            guid: iKundeDetail.guid,
            integer: iKundeDetail.integer,
            bankId: iKundeDetail.bank.id,
        };
    }
}