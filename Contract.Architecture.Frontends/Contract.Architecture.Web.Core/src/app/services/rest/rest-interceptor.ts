import { RestRequest } from './rest.service';
import { HttpResponse, HttpErrorResponse } from '@angular/common/http';

export interface IRestInterceptor {

    intercept(response?: HttpResponse<any> | HttpErrorResponse, request?: RestRequest): Promise<void>;

}
