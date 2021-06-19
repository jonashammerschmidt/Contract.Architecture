import { AfterViewInit, Component, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { TableFilterBarComponent } from 'src/app/components/ui/table-filter-bar/table-filter-bar.component';
import { MultiDataSource } from 'src/app/components/ui/table-filter-bar/table-filter-bar-dropdown-multi/multi-data-source';
import { TableFilterBarDropdownItem } from 'src/app/components/ui/table-filter-bar/table-filter-bar-dropdown-item';
import { GegoennteBankenCrudService } from 'src/app/model/gegoenntes-bankwesen/gegoennte-banken/gegoennte-banken-crud.service';
import { IGegoennteBank } from 'src/app/model/gegoenntes-bankwesen/gegoennte-banken/dtos/i-gegoennte-bank';
import { PaginationDataSource } from 'src/app/services/backend/pagination.data-source';
import { GegoennteBankCreateDialog } from './dialogs/gegoennte-bank-create/gegoennte-bank-create.dialog';

@Component({
  selector: 'app-gegoennte-banken',
  templateUrl: './gegoennte-banken.page.html',
  styleUrls: ['./gegoennte-banken.page.scss']
})
export class GegoennteBankenPage implements AfterViewInit {

  // FilterBar
  @ViewChild(TableFilterBarComponent) tableFilterBarComponent: TableFilterBarComponent;
  filterItems: TableFilterBarDropdownItem[] = [];
  filterValues: any[][] = [];

  // Table
  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;
  public gegoennteBankenDataSource: PaginationDataSource<IGegoennteBank>;
  public gegoennteBankenGridColumns: string[] = [
    'name',
    'gegoennterName',
    'gegoennterBoolean',
    'gegoenntesDateTime',
    'gegoennterDouble',
    'gegoennteGuid',
    'gegoennterInteger',
    'detail',
  ];
  
  constructor(
    private gegoennteBankenCrudService: GegoennteBankenCrudService,
    private matDialog: MatDialog) {
    
    this.gegoennteBankenDataSource = new PaginationDataSource<IGegoennteBank>(
      (options) => this.gegoennteBankenCrudService.getGegoennteBanken(options),
      () => [
        {
          filterField: 'name',
          containsFilters: [this.tableFilterBarComponent.currentFilterTerm]
        },
      ]);
  }
  
  async ngAfterViewInit(): Promise<void> {
    this.gegoennteBankenDataSource.initialize(this.tableFilterBarComponent, this.paginator, this.sort);
  }

  openCreateDialog(): void {
    this.matDialog.open(GegoennteBankCreateDialog, {
      maxHeight: '90vh'
    });
  }

}
