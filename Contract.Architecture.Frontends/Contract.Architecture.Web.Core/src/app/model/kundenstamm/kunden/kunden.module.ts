import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { KundenCrudService } from './kunden-crud.service';

@NgModule({
  imports: [
    CommonModule
  ],
  providers: [
    KundenCrudService
  ]
})
export class KundenModule { }
