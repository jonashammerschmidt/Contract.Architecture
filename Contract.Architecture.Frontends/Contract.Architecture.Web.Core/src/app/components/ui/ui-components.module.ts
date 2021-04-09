import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatSelectModule } from '@angular/material/select';
import { NgxMatSelectSearchModule } from 'ngx-mat-select-search';
import { LoadingSpinnerComponent } from './loading-spinner/loading-spinner.component';
import { SearchDropdownFormComponent } from './search-dropdown-form/search-dropdown-form.component';
import { SearchDropdownComponent } from './search-dropdown/search-dropdown.component';
import { TableFilterBarDropdownMultipleComponent } from './table-filter-bar/table-filter-bar-dropdown-multiple/table-filter-bar-dropdown-multiple.component';
import { TableFilterBarDropdownComponent } from './table-filter-bar/table-filter-bar-dropdown/table-filter-bar-dropdown.component';
import { TableFilterBarComponent } from './table-filter-bar/table-filter-bar.component';

@NgModule({
    declarations: [
        LoadingSpinnerComponent,
        SearchDropdownComponent,
        SearchDropdownFormComponent,
        TableFilterBarComponent,
        TableFilterBarDropdownComponent,
        TableFilterBarDropdownMultipleComponent,
    ],
    exports: [
        LoadingSpinnerComponent,
        SearchDropdownComponent,
        SearchDropdownFormComponent,
        TableFilterBarComponent,
    ],
    imports: [
        CommonModule,
        FormsModule,
        ReactiveFormsModule,
        MatFormFieldModule,
        MatSelectModule,
        MatIconModule,
        NgxMatSelectSearchModule,
    ]
})
export class UiComponentsModule { }
