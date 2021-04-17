import { ApiBankCreate } from './api/api-bank-create';

export interface IBankCreate {
    name: string;
    boolean: boolean;
    dateTime: Date;
    double: number;
    guid: string;
    integer: number;
}

export abstract class BankCreate {
    public static toApiBankCreate(iBankCreate: IBankCreate): ApiBankCreate {
        return {
            name: iBankCreate.name,
            boolean: iBankCreate.boolean,
            dateTime: iBankCreate.dateTime,
            double: iBankCreate.double,
            guid: iBankCreate.guid,
            integer: iBankCreate.integer,
        };
    }
}
