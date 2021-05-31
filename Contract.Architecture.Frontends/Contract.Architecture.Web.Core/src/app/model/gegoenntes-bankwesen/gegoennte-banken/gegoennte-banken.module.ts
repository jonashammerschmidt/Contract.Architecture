import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { GegoennteBankenCrudService } from './gegoennte-banken-crud.service';

@NgModule({
  imports: [
    CommonModule
  ],
  providers: [
    GegoennteBankenCrudService
  ]
})
export class GegoennteBankenModule { }
