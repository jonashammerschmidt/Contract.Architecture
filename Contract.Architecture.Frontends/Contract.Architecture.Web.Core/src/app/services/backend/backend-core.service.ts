import { Injectable } from '@angular/core';
import { SessionService } from 'src/app/model/sessions/sessions.service';
import { environment } from 'src/environments/environment';
import { RestBodyOptions, RestOptions, RestService } from './rest.service';

@Injectable()
export class BackendCoreService {

    private BASEPATH: string;

    constructor(
        private restService: RestService,
        private sessionService: SessionService) {
        this.BASEPATH = environment.apiEndpoint;
    }

    public async get<T>(urlPath: string, options?: RestOptions): Promise<T> {
        options = this.adjustOptions(options);
        return await this.restService.get<T>(this.BASEPATH + urlPath, options);
    }

    public async post<T>(urlPath: string, options?: RestBodyOptions): Promise<T> {
        options = this.adjustOptions(options);
        return await this.restService.post<T>(this.BASEPATH + urlPath, options);
    }

    public async put<T>(urlPath: string, options?: RestBodyOptions): Promise<T> {
        options = this.adjustOptions(options);
        return await this.restService.put<T>(this.BASEPATH + urlPath, options);
    }

    public async delete<T>(urlPath: string, options?: RestOptions): Promise<T> {
        options = this.adjustOptions(options);
        return await this.restService.delete<T>(this.BASEPATH + urlPath, options);
    }

    adjustOptions(options?: RestOptions): RestOptions {
        if (!this.sessionService.hasToken()) {
            return { ...options };
        }

        return {
            header: {
                Authorization: 'Token ' + this.sessionService.getToken()
            },
            ...options
        };
    }
}
