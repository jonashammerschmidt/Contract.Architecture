import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { SessionService } from 'src/app/model/sessions/sessions.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent {

  public email: string;
  public password: string;

  public errorMessage: string;

  public isLoggingIn = false;

  constructor(private router: Router, private sessionService: SessionService) { }

  // ---------------------- EmailUser Login ----------------------

  public async onLoginButtonClicked(): Promise<void> {
    this.errorMessage = null;
    this.isLoggingIn = true;
    try {
      await this.sessionService.login(this.email, this.password);
      await this.router.navigate(['/home']);
    } catch (e) {
      this.createEmailUserLoginErrorMessage(e);
    }
    this.isLoggingIn = false;
  }

  // ---------------------- Error Message ----------------------

  private createEmailUserLoginErrorMessage(e: any): void {
    if (e.status === 0) {
      this.errorMessage = 'Die Verbindung zum Server ist fehlgeschlagen.';
    } else if (e.status === 400 || e.status === 404) {
      this.errorMessage = 'E-Mail Adresse oder Passwort inkorrekt';
    } else if (e.status === 403) {
      this.errorMessage = 'Der Mandant ist deaktiviert.';
    } else {
      this.errorMessage = 'Unbekannter Fehler';
    }
  }
}
