import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { GegoennteKundenCrudService } from './gegoennte-kunden-crud.service';

@NgModule({
  imports: [
    CommonModule
  ],
  providers: [
    GegoennteKundenCrudService
  ]
})
export class GegoennteKundenModule { }
