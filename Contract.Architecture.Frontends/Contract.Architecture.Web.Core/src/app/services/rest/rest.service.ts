import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpResponse, HttpErrorResponse } from '@angular/common/http';
import { IRestInterceptor } from './rest-interceptor';

export enum RestRequestMethod {
  Get,
  Post,
  Put,
  Delete
}

export interface RestOptions {
  bearerToken?: string;
  header?: {
    [key: string]: string;
  };
  withCredentials?: boolean;
  successInterceptor?: IRestInterceptor;
  errorInterceptor?: IRestInterceptor;
}

export interface RestBodyOptions extends RestOptions {
  body?: any;
  file?: File;
}

export interface RestRequest extends RestBodyOptions {
  method: RestRequestMethod;
  url: string;
}

@Injectable()
export class RestService {

  private successInterceptorGlobal: IRestInterceptor;
  private errorInterceptorGlobal: IRestInterceptor;

  constructor(private http: HttpClient) { }

  /**
   * Constructs a `GET` request that interprets the body as a JSON object and
   * returns the response body as a JSON object.
   *
   * @param url     The endpoint URL.
   * @param options Some http options wrapped (like BearerToken).
   *
   * @return A `Promise` of the response body as a JSON object.
   */
  public async get<T>(url: string, options?: RestOptions): Promise<T> {
    const headers = this.getHttpHeaders(options);
    const withCredentials = (options) ? options.withCredentials : false;

    const request: RestRequest = {
      ...options,
      url,
      method: RestRequestMethod.Get
    };

    try {
      const response: HttpResponse<T> = await this.http.get<T>(url, { headers, withCredentials, observe: 'response' }).toPromise();
      const customSuccessInterceptor = (options) ? options.successInterceptor : null;
      await this.interceptSuccess(response, request, customSuccessInterceptor);
      return response.body;
    } catch (errorResponse) {
      const customErrorInterceptor = (options) ? options.errorInterceptor : null;
      await this.interceptAndThrowError(errorResponse, request, customErrorInterceptor);
    }
  }

  /**
   * Constructs a `POST` request based on the provided 'url' and non-mandatory options.
   *
   * @param url     The endpoint URL.
   * @param options Some http options wrapped (like JSON-Body, File-Attachment and BearerToken).
   *
   * @return A `Promise` of the response body as a JSON object.
   */
  public async post<T>(url: string, options?: RestBodyOptions): Promise<T> {
    const headers = this.getHttpHeaders(options);
    const withCredentials = (options) ? options.withCredentials : false;

    let body = (options && options.body) ? options.body : null;
    if (options && options.file) {
      body = new FormData();
      body.append(options.file.name, options.file);
    }

    const request: RestRequest = {
      ...options,
      url,
      method: RestRequestMethod.Post
    };

    try {
      const response: HttpResponse<T> = await this.http.post<T>(url, body, { headers, withCredentials, observe: 'response' }).toPromise();
      const customSuccessInterceptor = (options) ? options.successInterceptor : null;
      await this.interceptSuccess(response, request, customSuccessInterceptor);
      return response.body;
    } catch (e) {
      const customErrorInterceptor = (options) ? options.errorInterceptor : null;
      await this.interceptAndThrowError(e, request, customErrorInterceptor);
    }
  }

  /**
   * Constructs a `PUT` request based on the provided 'url' and non-mandatory options.
   *
   * @param url     The endpoint URL.
   * @param options Some http options wrapped (like JSON-Body, File-Attachment and BearerToken).
   *
   * @return A `Promise` of the response body as a JSON object.
   */
  public async put<T>(url: string, options?: RestBodyOptions): Promise<T> {
    const headers = this.getHttpHeaders(options);
    const withCredentials = (options) ? options.withCredentials : false;

    let body = (options && options.body) ? options.body : null;
    if (options && options.file) {
      body = new FormData();
      body.append(options.file.name, options.file);
    }

    const request: RestRequest = {
      ...options,
      url,
      method: RestRequestMethod.Put
    };

    try {
      const response: HttpResponse<T> = await this.http.put<T>(url, body, { headers, withCredentials, observe: 'response' }).toPromise();
      const customSuccessInterceptor = (options) ? options.successInterceptor : null;
      await this.interceptSuccess(response, request, customSuccessInterceptor);
      return response.body;
    } catch (e) {
      const customErrorInterceptor = (options) ? options.errorInterceptor : null;
      await this.interceptAndThrowError(e, request, customErrorInterceptor);
    }
  }

  /**
   * Constructs a `DELETE` request that interprets the body as a JSON object and
   * returns the response body as a JSON object.
   *
   * @param url     The endpoint URL.
   * @param options Some http options wrapped (like BearerToken).
   *
   * @return A `Promise` of the response body as a JSON object.
   */
  public async delete<T>(url: string, options?: RestOptions): Promise<T> {
    const headers = this.getHttpHeaders(options);
    const withCredentials = (options) ? options.withCredentials : false;

    const request: RestRequest = {
      ...options,
      url,
      method: RestRequestMethod.Delete
    };

    try {
      const response: HttpResponse<T> = await this.http.delete<T>(url, { headers, withCredentials, observe: 'response'  }).toPromise();
      const customSuccessInterceptor = (options) ? options.successInterceptor : null;
      await this.interceptSuccess(response, request, customSuccessInterceptor);
      return response.body;
    } catch (e) {
      const customErrorInterceptor = (options) ? options.errorInterceptor : null;
      await this.interceptAndThrowError(e, request, customErrorInterceptor);
    }
  }

  /**
   * Sets a global success interceptor for each HTTP-Request
   *
   * @param successInterceptor Interceptor method that is called every time an successful HTTP-Request is handled
   */
  public setGlobalSuccessInterceptor(successInterceptor: IRestInterceptor): void {
    this.successInterceptorGlobal = successInterceptor;
  }

  /**
   * Sets a global error interceptor for each HTTP-Request
   *
   * @param errorInterceptor Interceptor method that is called every time an error occours in the HTTP-Request
   */
  public setGlobalErrorInterceptor(errorInterceptor: IRestInterceptor): void {
    this.errorInterceptorGlobal = errorInterceptor;
  }

  private getHttpHeaders(options?: RestOptions): HttpHeaders {
    let httpHeaders = new HttpHeaders();

    if (options) {
      if (options.bearerToken) {
        httpHeaders = httpHeaders.append('Authorization', 'Bearer ' + options.bearerToken);
      }
      if (options.header) {
        Object.keys(options.header).forEach((key) => {
          httpHeaders = httpHeaders.append(key, options.header[key]);
        });
      }
    }

    return httpHeaders;
  }

  private async interceptSuccess(
    response: HttpResponse<any>,
    request: RestRequest,
    successInterceptorCustom: IRestInterceptor): Promise<void> {

    const successInterceptor = successInterceptorCustom || this.successInterceptorGlobal;
    if (successInterceptor) {
      try {
        await successInterceptor.intercept(response, request);
      } catch (errorInInterception) {
        console.error('Error in success interception of  rest service');
        console.error(errorInInterception);
      }
    }
  }

  private async interceptAndThrowError(
    errorResponse: HttpErrorResponse,
    request: RestRequest,
    errorInterceptorCustom: IRestInterceptor): Promise<void> {

    const errorInterceptor = errorInterceptorCustom || this.errorInterceptorGlobal;
    if (errorInterceptor) {
      try {
        await errorInterceptor.intercept(errorResponse, request);
      } catch (errorInInterception) {
        console.error('Error in error interception of  rest service');
        console.error(errorInInterception);
      }
    }

    throw errorResponse;
  }
}
