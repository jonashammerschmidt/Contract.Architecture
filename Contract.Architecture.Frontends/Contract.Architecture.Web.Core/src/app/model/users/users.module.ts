import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { EmailUserPasswordResetService } from './email-user-password-reset.service';
import { EmailUserPasswordChangeService } from './email-user-password-change.service';
import { EmailUserRegisterService } from './email-user-register.service';
import { SessionServicesModule } from '../sessions/sessions-services.module';

@NgModule({
  imports: [
    CommonModule,
    SessionServicesModule
  ],
  providers: [
    EmailUserPasswordResetService,
    EmailUserPasswordChangeService,
    EmailUserRegisterService
  ]
})
export class UsersServicesModule { }
