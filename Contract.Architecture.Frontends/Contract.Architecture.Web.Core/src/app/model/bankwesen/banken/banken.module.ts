import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { BankenCrudService } from './banken-crud.service';

@NgModule({
  imports: [
    CommonModule
  ],
  providers: [
    BankenCrudService
  ]
})
export class BankenModule { }
