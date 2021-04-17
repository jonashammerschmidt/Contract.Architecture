import { Bank, IBank } from 'src/app/model/bankwesen/banken/dtos/i-bank';
import { ApiKundeDetail } from './api/api-kunde-detail';

export interface IKundeDetail {
    id: string;
    name?: string;
    boolean?: boolean;
    dateTime?: Date;
    double?: number;
    guid?: string;
    integer?: number;
    bank: IBank;
}

export abstract class KundeDetail {
    public static fromApiKundeDetail(apiKundeDetail: ApiKundeDetail): IKundeDetail {
        return {
            id: apiKundeDetail.id,
            name: apiKundeDetail.name,
            boolean: apiKundeDetail.boolean,
            dateTime: apiKundeDetail.dateTime,
            double: apiKundeDetail.double,
            guid: apiKundeDetail.guid,
            integer: apiKundeDetail.integer,
            bank: Bank.fromApiBank(apiKundeDetail.bank),
        };
    }
}
