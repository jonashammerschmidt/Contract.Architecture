import { GegoennterKunde, IGegoennterKunde } from 'src/app/model/gegoennter-kundenstamm/gegoennte-kunden/dtos/i-gegoennter-kunde';
import { ApiGegoennteBankDetail } from './api/api-gegoennte-bank-detail';

export interface IGegoennteBankDetail {
    id: string;
    name: string;
    gegoennterName: string;
    gegoennterBoolean: boolean;
    gegoenntesDateTime: Date;
    gegoennterDouble: number;
    gegoennteGuid: string;
    gegoennterInteger: number;
    besteKunden: IGegoennterKunde[];
}

export abstract class GegoennteBankDetail {
    public static fromApiGegoennteBankDetail(apiGegoennteBankDetail: ApiGegoennteBankDetail): IGegoennteBankDetail {
        return {
            id: apiGegoennteBankDetail.id,
            name: apiGegoennteBankDetail.name,
            gegoennterName: apiGegoennteBankDetail.gegoennterName,
            gegoennterBoolean: apiGegoennteBankDetail.gegoennterBoolean,
            gegoenntesDateTime: apiGegoennteBankDetail.gegoenntesDateTime,
            gegoennterDouble: apiGegoennteBankDetail.gegoennterDouble,
            gegoennteGuid: apiGegoennteBankDetail.gegoennteGuid,
            gegoennterInteger: apiGegoennteBankDetail.gegoennterInteger,
            besteKunden: apiGegoennteBankDetail.besteKunden.map(apiGegoennterKunde => GegoennterKunde.fromApiGegoennterKunde(apiGegoennterKunde)),
        };
    }
}
