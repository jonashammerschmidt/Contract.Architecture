import { Injectable } from '@angular/core';
import { RestBodyOptions, RestService } from 'src/app/services/backend/rest.service';
import { environment } from 'src/environments/environment';

@Injectable()
export class EmailUserRegisterService {

  private BASEPATH: string;

  constructor(private restService: RestService) {
    this.BASEPATH = environment.apiEndpoint;
  }

  public async register(email: string, password: string): Promise<void> {
    const body: RestBodyOptions = { body: { email, password } };
    await this.restService.post(this.BASEPATH + '/api/users/email-user/regoster', body);
  }

}
