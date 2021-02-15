import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { validatePassword } from 'src/app/helpers/validation.helper';
import { EmailUserPasswordChangeService } from 'src/app/model/users/email-user-password-change.service';

@Component({
  selector: 'app-change-password',
  templateUrl: './change-password.component.html',
  styleUrls: ['./change-password.component.scss']
})
export class ChangePasswordComponent {

  public oldPassword = '';
  public password = '';
  public password2 = '';

  public validatePassword = validatePassword;

  public submitted = false;

  public errorMessage = '';

  constructor(
    private router: Router,
    private passwordChangeService: EmailUserPasswordChangeService) { }

  public async onSubmitButtonClicked(): Promise<void> {
    this.submitted = true;
    if (this.validatePassword(this.password) && this.password === this.password2) {
      try {
        await this.passwordChangeService.changePassword(this.oldPassword, this.password);
        await this.router.navigate(['/home']);
      } catch (e) {
        this.submitted = false;
        this.errorMessage = 'Das Passwort konnte nicht geändert werden.';
      }
    }
  }
}
