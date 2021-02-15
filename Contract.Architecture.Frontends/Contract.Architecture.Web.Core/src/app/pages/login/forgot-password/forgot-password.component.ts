import { Component } from '@angular/core';
import { validateEmail } from 'src/app/helpers/validation.helper';
import { EmailUserPasswordResetService } from 'src/app/model/users/email-user-password-reset.service';

@Component({
  selector: 'app-forgot-password',
  templateUrl: './forgot-password.component.html',
  styleUrls: ['./forgot-password.component.scss']
})
export class ForgotPasswordComponent {

  public email = '';
  public validateEmail = validateEmail;

  public submitted = false;

  constructor(private passwordResetService: EmailUserPasswordResetService) { }

  public async onSubmitButtonClicked(): Promise<void> {
    if (this.validateEmail(this.email)) {
      await this.passwordResetService.forgotPassword(this.email);
      this.submitted = true;
    }
  }

}
