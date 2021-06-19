import { ApiGegoennteBankUpdate } from './api/api-gegoennte-bank-update';
import { IGegoennteBankDetail } from './i-gegoennte-bank-detail';

export interface IGegoennteBankUpdate {
    id: string;
    name: string;
    gegoennterName: string;
    gegoennterBoolean: boolean;
    gegoenntesDateTime: Date;
    gegoennterDouble: number;
    gegoennteGuid: string;
    gegoennterInteger: number;
}

export abstract class GegoennteBankUpdate {
    public static toApiGegoennteBankUpdate(iGegoennteBankUpdate: IGegoennteBankUpdate): ApiGegoennteBankUpdate {
        return {
            id: iGegoennteBankUpdate.id,
            name: iGegoennteBankUpdate.name,
            gegoennterName: iGegoennteBankUpdate.gegoennterName,
            gegoennterBoolean: iGegoennteBankUpdate.gegoennterBoolean,
            gegoenntesDateTime: iGegoennteBankUpdate.gegoenntesDateTime,
            gegoennterDouble: iGegoennteBankUpdate.gegoennterDouble,
            gegoennteGuid: iGegoennteBankUpdate.gegoennteGuid,
            gegoennterInteger: iGegoennteBankUpdate.gegoennterInteger,
        };
    }

    public static fromGegoennteBankDetail(iGegoennteBankDetail: IGegoennteBankDetail): IGegoennteBankUpdate {
        return {
            id: iGegoennteBankDetail.id,
            name: iGegoennteBankDetail.name,
            gegoennterName: iGegoennteBankDetail.gegoennterName,
            gegoennterBoolean: iGegoennteBankDetail.gegoennterBoolean,
            gegoenntesDateTime: iGegoennteBankDetail.gegoenntesDateTime,
            gegoennterDouble: iGegoennteBankDetail.gegoennterDouble,
            gegoennteGuid: iGegoennteBankDetail.gegoennteGuid,
            gegoennterInteger: iGegoennteBankDetail.gegoennterInteger,
        };
    }
}