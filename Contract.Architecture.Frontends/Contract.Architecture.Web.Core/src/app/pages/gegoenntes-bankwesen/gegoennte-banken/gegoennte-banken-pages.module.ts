import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatNativeDateModule } from '@angular/material/core';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatDialogModule } from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatSelectModule } from '@angular/material/select';
import { MatSortModule } from '@angular/material/sort';
import { MatTableModule } from '@angular/material/table';
import { MatTabsModule } from '@angular/material/tabs';
import { UiComponentsModule } from 'src/app/components/ui/ui-components.module';
import { GegoennteBankenModule } from 'src/app/model/gegoenntes-bankwesen/gegoennte-banken/gegoennte-banken.module';
import { GegoennteBankCreateDialog } from './dialogs/gegoennte-bank-create/gegoennte-bank-create.dialog';
import { GegoennteBankDetailPage } from './sub-pages/gegoennte-bank-detail/gegoennte-bank-detail.page';
import { GegoennteBankUpdateDialog } from './dialogs/gegoennte-bank-update/gegoennte-bank-update.dialog';
import { GegoennteBankenPagesRouting } from './gegoennte-banken-pages.routing';
import { GegoennteBankenPage } from './gegoennte-banken.page';

@NgModule({
  declarations: [
    GegoennteBankenPage,
    GegoennteBankCreateDialog,
    GegoennteBankDetailPage,
    GegoennteBankUpdateDialog,
  ],
  imports: [
    // Routing Modules
    GegoennteBankenPagesRouting,

    // Model Modules
    GegoennteBankenModule,

    // UI Components
    UiComponentsModule,

    // Angular Material Modules
    MatButtonModule,
    MatCardModule,
    MatCheckboxModule,
    MatDatepickerModule,
    MatDialogModule,
    MatNativeDateModule,
    MatFormFieldModule,
    MatIconModule,
    MatInputModule,
    MatPaginatorModule,
    MatProgressSpinnerModule,
    MatSelectModule,
    MatSortModule,
    MatTableModule,
    MatTabsModule,

    // Misc Modules
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
  ]
})
export class GegoennteBankenPagesModule { }
