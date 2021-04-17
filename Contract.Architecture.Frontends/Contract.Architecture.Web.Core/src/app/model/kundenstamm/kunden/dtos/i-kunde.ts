import { ApiKunde } from './api/api-kunde';

export interface IKunde {
    id: string;
    name?: string;
    boolean?: boolean;
    dateTime?: Date;
    double?: number;
    guid?: string;
    integer?: number;
    bankId: string;
}

export class Kunde {
    public static fromApiKunde(apiKunde: ApiKunde): IKunde {
        return {
            id: apiKunde.id,
            name: apiKunde.name,
            boolean: apiKunde.boolean,
            dateTime: apiKunde.dateTime,
            double: apiKunde.double,
            guid: apiKunde.guid,
            integer: apiKunde.integer,
            bankId: apiKunde.bankId,
        };
    }
}
