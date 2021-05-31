import { ApiGegoennterKunde } from 'src/app/model/gegoennter-kundenstamm/gegoennte-kunden/dtos/api/api-gegoennter-kunde';

export interface ApiGegoennteBankDetail {
    id: string;
    name: string;
    gegoennterName: string;
    gegoennterBoolean: boolean;
    gegoenntesDateTime: Date;
    gegoennterDouble: number;
    gegoennteGuid: string;
    gegoennterInteger: number;
    besteKunden: ApiGegoennterKunde[];
}
