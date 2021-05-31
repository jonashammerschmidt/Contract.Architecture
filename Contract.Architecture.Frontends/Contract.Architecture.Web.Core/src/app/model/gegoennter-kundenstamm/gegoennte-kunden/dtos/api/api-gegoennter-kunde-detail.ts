import { ApiGegoennteBank } from 'src/app/model/gegoenntes-bankwesen/gegoennte-banken/dtos/api/api-gegoennte-bank';

export interface ApiGegoennterKundeDetail {
    id: string;
    name: string;
    gegoennterName: string;
    gegoennterBoolean?: boolean;
    gegoennterDateTime?: Date;
    gegoennterDouble?: number;
    gegoennterGuid?: string;
    gegoennterInteger?: number;
    besteBank: ApiGegoennteBank;
}
