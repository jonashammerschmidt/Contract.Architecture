import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: 'gegoennte-banken',
    loadChildren: () => import('./gegoennte-banken/gegoennte-banken-pages.module').then(m => m.GegoennteBankenPagesModule)
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class GegoenntesBankwesenPagesRouting { }
