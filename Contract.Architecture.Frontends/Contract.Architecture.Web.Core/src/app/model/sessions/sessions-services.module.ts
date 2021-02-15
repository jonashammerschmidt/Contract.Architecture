import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SessionService } from './sessions.service';

@NgModule({
  imports: [
    CommonModule
  ],
  providers: [
    SessionService
  ]
})
export class SessionServicesModule { }
