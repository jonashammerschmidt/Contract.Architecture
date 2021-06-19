export interface ApiGegoennterKunde {
    id: string;
    name: string;
    gegoennterName: string;
    gegoennterBoolean?: boolean;
    gegoennterDateTime?: Date;
    gegoennterDouble?: number;
    gegoennterGuid?: string;
    gegoennterInteger?: number;
    besteBankId: string;
}
