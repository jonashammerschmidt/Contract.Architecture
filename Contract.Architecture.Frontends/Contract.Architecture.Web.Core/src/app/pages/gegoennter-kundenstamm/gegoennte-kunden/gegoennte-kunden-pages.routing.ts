import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { GegoennterKundeDetailPage } from './sub-pages/gegoennter-kunde-detail/gegoennter-kunde-detail.page';
import { GegoennteKundenPage } from './gegoennte-kunden.page';

const routes: Routes = [
  { path: '', component: GegoennteKundenPage },
  { path: 'detail/:id', component: GegoennterKundeDetailPage },
  { path: '**', redirectTo: ''}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class GegoennteKundenPagesRouting { }
