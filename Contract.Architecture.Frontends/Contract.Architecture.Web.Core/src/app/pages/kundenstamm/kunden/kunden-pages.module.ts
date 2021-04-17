import { BankenModule } from 'src/app/model/bankwesen/banken/banken.module';
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
import { KundenModule } from 'src/app/model/kundenstamm/kunden/kunden.module';
import { KundeCreatePage } from './sub-pages/kunde-create/kunde-create.page';
import { KundeDetailPage } from './sub-pages/kunde-detail/kunde-detail.page';
import { KundeUpdatePage } from './sub-pages/kunde-update/kunde-update.page';
import { KundenPagesRouting } from './kunden-pages.routing';
import { KundenPage } from './kunden.page';

@NgModule({
  declarations: [
    KundenPage,
    KundeCreatePage,
    KundeDetailPage,
    KundeUpdatePage,
  ],
  imports: [
    // Routing Modules
    KundenPagesRouting,

    // Model Modules
    KundenModule,
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
export class KundenPagesModule { }
