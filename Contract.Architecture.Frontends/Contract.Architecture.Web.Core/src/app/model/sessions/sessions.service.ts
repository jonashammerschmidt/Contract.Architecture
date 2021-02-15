import { Injectable } from '@angular/core';
import { RestBodyOptions, RestService } from 'src/app/services/rest/rest.service';
import { environment } from 'src/environments/environment';
import { ISessionInformation } from './sessions';

@Injectable()
export class SessionService {

  private BASEPATH: string;

  private sessionInformationCache: ISessionInformation;

  constructor(private restService: RestService) {
    this.BASEPATH = environment.apiEndpoint;
  }

  // --------------- Login ---------------

  public async login(email: string, password: string): Promise<void> {
    const body: RestBodyOptions = {
      body: {
        email,
        password
      }
    };
    const response = await this.restService.post<{ data: string }>(this.BASEPATH + '/api/users/email-user/login', body);
    this.setToken(response.data);
  }

  // --------------- Logout ---------------

  public async logout(): Promise<any> {
    if (this.hasToken()) {
      const body: RestBodyOptions = {
        header: {
          Authorization: 'Token ' + this.getToken()
        }
      };

      try {
        await this.restService.delete(this.BASEPATH + '/api/session/logout', body);
      } catch (e) {
        if (e.status !== 401) {
          throw e;
        }
      }

      this.removeToken();
    }
  }

  // ------------ Session Token ------------

  public hasToken(): boolean {
    return this.getToken() != null;
  }

  public getToken(): string {
    return localStorage.getItem('sessionToken');
  }

  public removeToken(): void {
    localStorage.removeItem('sessionToken');
    this.sessionInformationCache = undefined;
  }

  private setToken(token: string): void {
    localStorage.setItem('sessionToken', token);
  }

  // -------- Session Information --------

  public async getEmailUserId(): Promise<string> {
    const sessionInformation = await this.getCachedSessionInfo();
    return sessionInformation.emailUserId;
  }

  public async getName(): Promise<string> {
    const sessionInformation = await this.getCachedSessionInfo();
    return sessionInformation.name;
  }

  public async isSessionActive(): Promise<boolean> {
    if (!this.hasToken()) {
      return false;
    }

    try {
      await this.retrieveSessionInformation();
    } catch {
      return false;
    }
    return true;
  }

  private async getCachedSessionInfo(): Promise<ISessionInformation> {
    if (!this.sessionInformationCache) {
      await this.retrieveSessionInformation();
    }

    return { ...this.sessionInformationCache };
  }

  private async retrieveSessionInformation(): Promise<void> {
    const options: RestBodyOptions = {
      header: {
        Authorization: 'Token ' + this.getToken()
      },
      errorInterceptor: {
        intercept: async () => { }
      }
    };
    this.sessionInformationCache = await this.restService.get<ISessionInformation>(this.BASEPATH + '/api/session', options);
  }

}
