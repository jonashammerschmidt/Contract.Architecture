import { ApiBank } from './api/api-bank';

export interface IBank {
    id: string;
    name: string;
    boolean: boolean;
    dateTime: Date;
    double: number;
    guid: string;
    integer: number;
}

export class Bank {
    public static fromApiBank(apiBank: ApiBank): IBank {
        return {
            id: apiBank.id,
            name: apiBank.name,
            boolean: apiBank.boolean,
            dateTime: apiBank.dateTime,
            double: apiBank.double,
            guid: apiBank.guid,
            integer: apiBank.integer,
        };
    }
}
