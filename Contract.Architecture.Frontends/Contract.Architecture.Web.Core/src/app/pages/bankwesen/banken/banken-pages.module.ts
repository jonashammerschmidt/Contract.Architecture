import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatNativeDateModule } from '@angular/material/core';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatSortModule } from '@angular/material/sort';
import { MatTableModule } from '@angular/material/table';
import { MatTabsModule } from '@angular/material/tabs';
import { UiComponentsModule } from 'src/app/components/ui/ui-components.module';
import { BankenModule } from 'src/app/model/bankwesen/banken/banken.module';
import { BankCreatePage } from './sub-pages/bank-create/bank-create.page';
import { BankDetailPage } from './sub-pages/bank-detail/bank-detail.page';
import { BankUpdatePage } from './sub-pages/bank-update/bank-update.page';
import { BankenPagesRouting } from './banken-pages.routing';
import { BankenPage } from './banken.page';

@NgModule({
  declarations: [
    BankenPage,
    BankCreatePage,
    BankDetailPage,
    BankUpdatePage,
  ],
  imports: [
    // Routing Modules
    BankenPagesRouting,

    // Model Modules
    BankenModule,

    // UI Components
    UiComponentsModule,

    // Angular Material Modules
    MatButtonModule,
    MatCardModule,
    MatCheckboxModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MatFormFieldModule,
    MatIconModule,
    MatInputModule,
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
export class BankenPagesModule { }
