import { ApiGegoennteBankCreate } from './api/api-gegoennte-bank-create';

export interface IGegoennteBankCreate {
    name: string;
    gegoennterName: string;
    gegoennterBoolean: boolean;
    gegoenntesDateTime: Date;
    gegoennterDouble: number;
    gegoennteGuid: string;
    gegoennterInteger: number;
}

export abstract class GegoennteBankCreate {
    public static toApiGegoennteBankCreate(iGegoennteBankCreate: IGegoennteBankCreate): ApiGegoennteBankCreate {
        return {
            name: iGegoennteBankCreate.name,
            gegoennterName: iGegoennteBankCreate.gegoennterName,
            gegoennterBoolean: iGegoennteBankCreate.gegoennterBoolean,
            gegoenntesDateTime: iGegoennteBankCreate.gegoenntesDateTime,
            gegoennterDouble: iGegoennteBankCreate.gegoennterDouble,
            gegoennteGuid: iGegoennteBankCreate.gegoennteGuid,
            gegoennterInteger: iGegoennteBankCreate.gegoennterInteger,
        };
    }
}
