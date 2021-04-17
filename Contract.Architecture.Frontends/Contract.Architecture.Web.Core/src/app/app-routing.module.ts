import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: 'login',
    loadChildren: () => import('./pages/login/login.module').then(m => m.LoginModule)
  },
  {
    path: 'home',
    loadChildren: () => import('./pages/home/home.module').then(m => m.HomeModule)
  },
  {
    path: 'change-password',
    loadChildren: () => import('./pages/change-password/change-password.module').then(m => m.ChangePasswordModule)
  },
  {
    path: 'bankwesen',
    loadChildren: () => import('./pages/bankwesen/bankwesen-pages.module').then(m => m.BankwesenPagesModule)
  },
  {
    path: 'kundenstamm',
    loadChildren: () => import('./pages/kundenstamm/kundenstamm-pages.module').then(m => m.KundenstammPagesModule)
  },
  {
    path: '**',
    redirectTo: '/home'
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
