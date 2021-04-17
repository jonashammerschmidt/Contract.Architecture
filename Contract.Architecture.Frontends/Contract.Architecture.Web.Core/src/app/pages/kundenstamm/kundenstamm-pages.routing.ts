import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: 'kunden',
    loadChildren: () => import('./kunden/kunden-pages.module').then(m => m.KundenPagesModule)
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class KundenstammPagesRouting { }
