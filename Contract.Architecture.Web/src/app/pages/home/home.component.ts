import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { SessionService } from 'src/app/model/sessions/sessions.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  name: string;

  constructor(
    private router: Router,
    private sessionService: SessionService) { }

  public async ngOnInit(): Promise<void> {
    await this.validateLocation();

    this.name = await this.sessionService.getName();
  }

  async logout(): Promise<void> {
    await this.sessionService.logout();
    await this.router.navigate(['/login']);
  }

  // ---------------------- Misc ----------------------

  private async validateLocation(): Promise<void> {
    const hasSession = this.sessionService.hasToken();
    const hasActiveSession = await this.sessionService.isSessionActive();

    if (!hasActiveSession) {
      await this.sessionService.removeToken();
      await this.router.navigate(['/login']);
    }

    if (!hasSession) {
      await this.router.navigate(['/login']);
      return;
    }
  }
}
