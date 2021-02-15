import { Injectable } from '@angular/core';
import { RestBodyOptions, RestService } from 'src/app/services/rest/rest.service';
import { environment } from 'src/environments/environment';
import { SessionService } from '../sessions/sessions.service';

@Injectable()
export class EmailUserPasswordChangeService {

  private BASEPATH: string;

  constructor(
    private sessionService: SessionService,
    private restService: RestService) {
    this.BASEPATH = environment.apiEndpoint;
  }

  public async changePassword(oldPassword: string, newPassword: string): Promise<void> {
    const body: RestBodyOptions = {
      header: {
        Authorization: 'Token ' + this.sessionService.getToken()
      },
      body: {
        oldPassword,
        newPassword
      }
    };
    await this.restService.put(this.BASEPATH + '/api/users/email-user/change-password', body);
  }

}
