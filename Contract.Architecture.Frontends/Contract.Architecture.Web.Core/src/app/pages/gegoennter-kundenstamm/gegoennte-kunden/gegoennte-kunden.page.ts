import { IGegoennteBank } from 'src/app/model/gegoenntes-bankwesen/gegoennte-banken/dtos/i-gegoennte-bank';
import { GegoennteBankenCrudService } from 'src/app/model/gegoenntes-bankwesen/gegoennte-banken/gegoennte-banken-crud.service';
import { AfterViewInit, Component, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { TableFilterBarComponent } from 'src/app/components/ui/table-filter-bar/table-filter-bar.component';
import { MultiDataSource } from 'src/app/components/ui/table-filter-bar/table-filter-bar-dropdown-multi/multi-data-source';
import { TableFilterBarDropdownItem } from 'src/app/components/ui/table-filter-bar/table-filter-bar-dropdown-item';
import { GegoennteKundenCrudService } from 'src/app/model/gegoennter-kundenstamm/gegoennte-kunden/gegoennte-kunden-crud.service';
import { IGegoennterKunde } from 'src/app/model/gegoennter-kundenstamm/gegoennte-kunden/dtos/i-gegoennter-kunde';
import { PaginationDataSource } from 'src/app/services/backend/pagination.data-source';
import { GegoennterKundeCreateDialog } from './dialogs/gegoennter-kunde-create/gegoennter-kunde-create.dialog';

@Component({
  selector: 'app-gegoennte-kunden',
  templateUrl: './gegoennte-kunden.page.html',
  styleUrls: ['./gegoennte-kunden.page.scss']
})
export class GegoennteKundenPage implements AfterViewInit {

  // FilterBar
  @ViewChild(TableFilterBarComponent) tableFilterBarComponent: TableFilterBarComponent;
  filterItems: TableFilterBarDropdownItem[] = [];
  filterValues: any[][] = [];

  // Table
  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;
  public gegoennteKundenDataSource: PaginationDataSource<IGegoennterKunde>;
  public gegoennteKundenGridColumns: string[] = [
    'name',
    'gegoennterName',
    'gegoennterBoolean',
    'gegoennterDateTime',
    'gegoennterDouble',
    'gegoennterGuid',
    'gegoennterInteger',
    'besteBank',
    'detail',
  ];
  
  gegoennteBanken: IGegoennteBank[];

  constructor(
    private gegoennteBankenCrudService: GegoennteBankenCrudService,
    private gegoennteKundenCrudService: GegoennteKundenCrudService,
    private matDialog: MatDialog) {
    
    this.gegoennteKundenDataSource = new PaginationDataSource<IGegoennterKunde>(
      (options) => this.gegoennteKundenCrudService.getGegoennteKunden(options),
      () => [
        {
          filterField: 'name',
          containsFilters: [this.tableFilterBarComponent.currentFilterTerm]
        },
      ]);
  }
  
  async ngAfterViewInit(): Promise<void> {
    await this.setupGegoennteBankenFilter();

    this.gegoennteKundenDataSource.initialize(this.tableFilterBarComponent, this.paginator, this.sort);
  }

  openCreateDialog(): void {
    this.matDialog.open(GegoennterKundeCreateDialog, {
      maxHeight: '90vh'
    });
  }


  public getGegoennteBankName(gegoennteBankId: string): string {
    return this.gegoennteBanken.find(gegoennteBank => gegoennteBank.id === gegoennteBankId).name;
  }

  private async setupGegoennteBankenFilter(): Promise<void> {
    const gegoennteBankenResult = await this.gegoennteBankenCrudService.getGegoennteBanken({ limit: 500, offset: 0 });
    this.gegoennteBanken = gegoennteBankenResult.data;

    this.filterItems.push({
      dataName: 'Beste Bank',
      dataSource: new MultiDataSource((pageSize: number, pageIndex: number, filterTerm: string) => {
        return this.gegoennteBankenCrudService.getGegoennteBanken({
          limit: pageSize,
          offset: pageSize* pageIndex,
          filters: [
            {
                filterField: 'name',
                containsFilters: [filterTerm]
            }
          ]
        });
      }),
      valueExpr: 'id',
      displayExpr: 'name',
    });

    this.filterValues.push([]);
  }
}
