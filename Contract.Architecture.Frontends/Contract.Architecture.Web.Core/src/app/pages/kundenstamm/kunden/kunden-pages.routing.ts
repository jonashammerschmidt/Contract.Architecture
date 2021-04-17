import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { KundeCreatePage } from './sub-pages/kunde-create/kunde-create.page';
import { KundeDetailPage } from './sub-pages/kunde-detail/kunde-detail.page';
import { KundeUpdatePage } from './sub-pages/kunde-update/kunde-update.page';
import { KundenPage } from './kunden.page';

const routes: Routes = [
  { path: '', component: KundenPage },
  { path: 'create', component: KundeCreatePage },
  { path: 'detail/:id', component: KundeDetailPage },
  { path: 'update/:id', component: KundeUpdatePage },
  { path: '**', redirectTo: ''}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class KundenPagesRouting { }
