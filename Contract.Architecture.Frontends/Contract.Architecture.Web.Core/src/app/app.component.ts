import { AfterViewChecked, Component, ElementRef, HostListener, OnInit, ViewChild } from '@angular/core';
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
export class AppComponent implements OnInit, AfterViewChecked {

  loading = true;

  menu: MenuItem[] = [
    { name: 'Home', url: '/home' },
    { name: 'Banken', url: 'gegoenntes-bankwesen/gegoennte-banken'},
    { name: 'Kunden', url: 'gegoennter-kundenstamm/gegoennte-kunden'},
  ];

  @ViewChild('content') content: ElementRef;
  calculatedContentWidthInPx = 0;
  calculatedContentHeightInPx = 0;

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

  ngAfterViewChecked(): void {
    this.calculateContentSize();
  }

  @HostListener('window:resize')
  onResize(): void {
    this.calculateContentSize();
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

  private calculateContentSize(): void {
    setTimeout(() => {
      const contentElement = this.content.nativeElement as HTMLElement;

      // Content-Element-Width - Content-Element-Padding
      this.calculatedContentWidthInPx = contentElement.clientWidth - 24;

      // Content-Element-Height - Content-Element-Padding
      this.calculatedContentHeightInPx = contentElement.clientHeight - 24;
    }, 0);
  }

}
