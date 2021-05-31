import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { TableFilterBarDropdownItem } from 'src/app/components/ui/table-filter-bar/table-filter-bar-dropdown-item';
import { GegoennteBankenCrudService } from 'src/app/model/gegoenntes-bankwesen/gegoennte-banken/gegoennte-banken-crud.service';
import { IGegoennteBank } from 'src/app/model/gegoenntes-bankwesen/gegoennte-banken/dtos/i-gegoennte-bank';
import { GegoennteBankCreateDialog } from './dialogs/gegoennte-bank-create/gegoennte-bank-create.dialog';

@Component({
  selector: 'app-gegoennte-banken',
  templateUrl: './gegoennte-banken.page.html',
  styleUrls: ['./gegoennte-banken.page.scss']
})
export class GegoennteBankenPage implements OnInit, AfterViewInit {

  filterItems: TableFilterBarDropdownItem[] = [];

  filterComparators: ((value: any) => boolean)[] = [];
  filterValues: any[][] = [];
  filterTerm = '';

  gegoennteBanken: IGegoennteBank[];
  public gegoennteBankenTableDataSource = new MatTableDataSource<IGegoennteBank>([]);
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

  @ViewChild(MatSort) sort: MatSort;

  constructor(
    private gegoennteBankenCrudService: GegoennteBankenCrudService,
    private matDialog: MatDialog) { }

  async ngOnInit(): Promise<void> {
    this.gegoennteBanken = await this.gegoennteBankenCrudService.getGegoennteBanken();
    this.updateDataSource();
  }

  ngAfterViewInit(): void {
    if (this.sort) {
      this.gegoennteBankenTableDataSource.sort = this.sort;
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
    this.gegoennteBankenTableDataSource.data = this.gegoennteBanken.slice()
      .filter(gegoennteBank => this.filterComparators.length < 1 || this.filterComparators.every(filterComparator => filterComparator(gegoennteBank)))
      .filter(gegoennteBank => gegoennteBank.name.toString().toLowerCase().includes(this.filterTerm.trim().toLowerCase()));
  }

  openCreateDialog(): void {
    this.matDialog.open(GegoennteBankCreateDialog, {
      maxHeight: '90vh'
    });
  }

}
