import { Kunde, IKunde } from 'src/app/model/kundenstamm/kunden/dtos/i-kunde';
import { ApiBankDetail } from './api/api-bank-detail';

export interface IBankDetail {
    id: string;
    name: string;
    boolean: boolean;
    dateTime: Date;
    double: number;
    guid: string;
    integer: number;
    kunden: IKunde[];
}

export abstract class BankDetail {
    public static fromApiBankDetail(apiBankDetail: ApiBankDetail): IBankDetail {
        return {
            id: apiBankDetail.id,
            name: apiBankDetail.name,
            boolean: apiBankDetail.boolean,
            dateTime: apiBankDetail.dateTime,
            double: apiBankDetail.double,
            guid: apiBankDetail.guid,
            integer: apiBankDetail.integer,
            kunden: apiBankDetail.kunden.map(apiKunde => Kunde.fromApiKunde(apiKunde)),
        };
    }
}
