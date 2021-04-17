import { ApiKunde } from 'src/app/model/kundenstamm/kunden/dtos/api/api-kunde';

export interface ApiBankDetail {
    id: string;
    name: string;
    boolean: boolean;
    dateTime: Date;
    double: number;
    guid: string;
    integer: number;
    kunden: ApiKunde[];
}
