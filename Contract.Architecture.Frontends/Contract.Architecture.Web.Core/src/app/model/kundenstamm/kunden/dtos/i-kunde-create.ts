import { ApiKundeCreate } from './api/api-kunde-create';

export interface IKundeCreate {
    name?: string;
    boolean?: boolean;
    dateTime?: Date;
    double?: number;
    guid?: string;
    integer?: number;
    bankId: string;
}

export abstract class KundeCreate {
    public static toApiKundeCreate(iKundeCreate: IKundeCreate): ApiKundeCreate {
        return {
            name: iKundeCreate.name,
            boolean: iKundeCreate.boolean,
            dateTime: iKundeCreate.dateTime,
            double: iKundeCreate.double,
            guid: iKundeCreate.guid,
            integer: iKundeCreate.integer,
            bankId: iKundeCreate.bankId,
        };
    }
}
