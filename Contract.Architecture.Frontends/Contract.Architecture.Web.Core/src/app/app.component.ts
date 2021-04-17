import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { SessionService } from './model/sessions/sessions.service';
import { RestService } from './services/backend/rest.service';

interface MenuItem {
  name: string;
  url: string;
}

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {

  loading = true;

  menu: MenuItem[] = [
    { name: 'Home', url: '/home' }
  ];

  constructor(
    private restService: RestService,
    private sessionService: SessionService,
    private router: Router) {
  }

  async ngOnInit(): Promise<void> {
    await this.validateLocation(location.pathname);

    this.restService.setGlobalErrorInterceptor({
      intercept: async (response) => {
        if (response.status === 401) {
          location.reload();
        }
      }
    });

    this.loading = false;
  }

  goBack(): void {
    window.history.back();
  }

  async validateLocation(url: string = this.router.url): Promise<void> {
    const hasSession = this.sessionService.hasToken();
    const hasActiveSession = await this.sessionService.isSessionActive();

    if (!url.startsWith('/login') && !hasSession) {
      await this.router.navigate(['/login']);
    } else if (!url.startsWith('/login') && !hasActiveSession) {
      await this.sessionService.removeToken();
      await this.router.navigate(['/login']);
    } else if (url.startsWith('/login') && hasActiveSession) {
      await this.router.navigate(['/home']);
    }
  }

  async logout(): Promise<void> {
    await this.sessionService.logout();
    await this.router.navigate(['/login']);
  }

}
