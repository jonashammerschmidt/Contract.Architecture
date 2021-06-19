import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { GegoennteBankDetailPage } from './sub-pages/gegoennte-bank-detail/gegoennte-bank-detail.page';
import { GegoennteBankenPage } from './gegoennte-banken.page';

const routes: Routes = [
  { path: '', component: GegoennteBankenPage },
  { path: 'detail/:id', component: GegoennteBankDetailPage },
  { path: '**', redirectTo: ''}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class GegoennteBankenPagesRouting { }
