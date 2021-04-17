import { Injectable } from '@angular/core';
import { RestBodyOptions, RestService } from 'src/app/services/backend/rest.service';
import { environment } from 'src/environments/environment';

@Injectable()
export class EmailUserPasswordResetService {

  private BASEPATH: string;

  constructor(private restService: RestService) {
    this.BASEPATH = environment.apiEndpoint;
  }

  public async forgotPassword(email: string): Promise<void> {
    const body: RestBodyOptions = { body: { email } };
    await this.restService.post(this.BASEPATH + '/api/users/email-user/forgot-password', body);
  }

  public async resetPassword(token: string, newPassword: string): Promise<void> {
    const body: RestBodyOptions = { body: { token, newPassword } };
    await this.restService.put(this.BASEPATH + '/api/users/email-user/reset-password', body);
  }

}
