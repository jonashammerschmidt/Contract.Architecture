import { IGegoennteBank } from 'src/app/model/gegoenntes-bankwesen/gegoennte-banken/dtos/i-gegoennte-bank';
import { GegoennteBankenCrudService } from 'src/app/model/gegoenntes-bankwesen/gegoennte-banken/gegoennte-banken-crud.service';
import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { TableFilterBarDropdownItem } from 'src/app/components/ui/table-filter-bar/table-filter-bar-dropdown-item';
import { GegoennteKundenCrudService } from 'src/app/model/gegoennter-kundenstamm/gegoennte-kunden/gegoennte-kunden-crud.service';
import { IGegoennterKunde } from 'src/app/model/gegoennter-kundenstamm/gegoennte-kunden/dtos/i-gegoennter-kunde';
import { GegoennterKundeCreateDialog } from './dialogs/gegoennter-kunde-create/gegoennter-kunde-create.dialog';

@Component({
  selector: 'app-gegoennte-kunden',
  templateUrl: './gegoennte-kunden.page.html',
  styleUrls: ['./gegoennte-kunden.page.scss']
})
export class GegoennteKundenPage implements OnInit, AfterViewInit {

  filterItems: TableFilterBarDropdownItem[] = [];

  filterComparators: ((value: any) => boolean)[] = [];
  filterValues: any[][] = [];
  filterTerm = '';

  gegoennteKunden: IGegoennterKunde[];
  public gegoennteKundenTableDataSource = new MatTableDataSource<IGegoennterKunde>([]);
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

  @ViewChild(MatSort) sort: MatSort;

  gegoennteBanken: IGegoennteBank[];

  constructor(
    private gegoennteBankenCrudService: GegoennteBankenCrudService,
    private gegoennteKundenCrudService: GegoennteKundenCrudService,
    private matDialog: MatDialog) { }

  async ngOnInit(): Promise<void> {
    await this.setupGegoennteBankenFilter();

    this.gegoennteKunden = await this.gegoennteKundenCrudService.getGegoennteKunden();
    this.updateDataSource();
  }

  ngAfterViewInit(): void {
    if (this.sort) {
      this.gegoennteKundenTableDataSource.sort = this.sort;
    }
  }

  onFilterValuesChange(values: any[][]): void {
    this.filterValues = values;
    this.updateDataSource();
  }

  onFilterTermChange(filterTerm: string): void {
    this.filterTerm = filterTerm;
    this.updateDataSource();
  }

  updateDataSource(): void {
    this.gegoennteKundenTableDataSource.data = this.gegoennteKunden.slice()
      .filter(gegoennterKunde => this.filterComparators.length < 1 || this.filterComparators.every(filterComparator => filterComparator(gegoennterKunde)))
      .filter(gegoennterKunde => gegoennterKunde.name.toString().toLowerCase().includes(this.filterTerm.trim().toLowerCase()));
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
    this.gegoennteBanken = await this.gegoennteBankenCrudService.getGegoennteBanken();

    this.filterItems.push({
      dataName: 'Beste Bank',
      dataSource: this.gegoennteBanken,
      valueExpr: 'id',
      displayExpr: 'name',
    });

    const filterValuesIndex = this.filterValues.length;
    this.filterValues.push([]);

    this.filterComparators.push((gegoennterKunde) => {
      return this.filterValues[filterValuesIndex].length < 1 ||
        this.filterValues[filterValuesIndex].includes(gegoennterKunde.besteBankId);
    });
  }
}
