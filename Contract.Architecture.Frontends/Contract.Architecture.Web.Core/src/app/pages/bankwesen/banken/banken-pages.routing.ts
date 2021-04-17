import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BankCreatePage } from './sub-pages/bank-create/bank-create.page';
import { BankDetailPage } from './sub-pages/bank-detail/bank-detail.page';
import { BankUpdatePage } from './sub-pages/bank-update/bank-update.page';
import { BankenPage } from './banken.page';

const routes: Routes = [
  { path: '', component: BankenPage },
  { path: 'create', component: BankCreatePage },
  { path: 'detail/:id', component: BankDetailPage },
  { path: 'update/:id', component: BankUpdatePage },
  { path: '**', redirectTo: ''}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class BankenPagesRouting { }
