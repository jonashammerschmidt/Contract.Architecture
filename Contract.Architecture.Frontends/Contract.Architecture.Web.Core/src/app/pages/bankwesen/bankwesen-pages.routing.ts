import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: 'banken',
    loadChildren: () => import('./banken/banken-pages.module').then(m => m.BankenPagesModule)
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class BankwesenPagesRouting { }
