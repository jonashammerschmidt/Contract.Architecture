import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatToolbarModule } from '@angular/material/toolbar';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { UiComponentsModule } from './components/ui/ui-components.module';
import { SessionServicesModule } from './model/sessions/sessions-services.module';
import { BackendCoreService } from './services/backend/backend-core.service';
import { RestService } from './services/backend/rest.service';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    HttpClientModule,
    UiComponentsModule,
    SessionServicesModule,
    AppRoutingModule,

    MatButtonModule,
    MatIconModule,
    MatSidenavModule,
    MatToolbarModule,
  ],
  providers: [
    RestService,
    BackendCoreService,
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
