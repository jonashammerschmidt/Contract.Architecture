import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { validatePassword } from 'src/app/helpers/validation.helper';
import { EmailUserPasswordResetService } from 'src/app/model/users/email-user-password-reset.service';

@Component({
  selector: 'app-reset-password',
  templateUrl: './reset-password.component.html',
  styleUrls: ['./reset-password.component.scss']
})
export class ResetPasswordComponent implements OnInit {

  public password = '';
  public password2 = '';
  private token: string;

  public validatePassword = validatePassword;

  public submitted = false;

  public errorMessage = '';

  constructor(
    private activatedRoute: ActivatedRoute,
    private router: Router,
    private passwordResetService: EmailUserPasswordResetService) { }

  public ngOnInit(): void {
    this.activatedRoute.params.subscribe(async params => {
      this.token = params.token;
    });
  }

  public async onSubmitButtonClicked(): Promise<void> {
    if (this.validatePassword(this.password) && this.password === this.password2) {
      try {
        await this.passwordResetService.resetPassword(this.token, this.password);
        await this.router.navigate(['/login']);
      } catch (e) {
        this.errorMessage = 'Das Passwort kann nicht zurückgesetzt werden, da der Link abgelaufen ist.';
      }
    }
  }

}
