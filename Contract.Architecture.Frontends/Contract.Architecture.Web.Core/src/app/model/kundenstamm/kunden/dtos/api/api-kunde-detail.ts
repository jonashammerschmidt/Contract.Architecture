import { ApiBank } from 'src/app/model/bankwesen/banken/dtos/api/api-bank';

export interface ApiKundeDetail {
    id: string;
    name?: string;
    boolean?: boolean;
    dateTime?: Date;
    double?: number;
    guid?: string;
    integer?: number;
    bank: ApiBank;
}
