import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: 'gegoennte-kunden',
    loadChildren: () => import('./gegoennte-kunden/gegoennte-kunden-pages.module').then(m => m.GegoennteKundenPagesModule)
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class GegoennterKundenstammPagesRouting { }
