import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { TableFilterBarDropdownItem } from 'src/app/components/ui/table-filter-bar/table-filter-bar-dropdown-item';
import { BankenCrudService } from 'src/app/model/bankwesen/banken/banken-crud.service';
import { IBank } from 'src/app/model/bankwesen/banken/dtos/i-bank';

@Component({
  selector: 'app-banken',
  templateUrl: './banken.page.html',
  styleUrls: ['./banken.page.scss']
})
export class BankenPage implements OnInit, AfterViewInit {

  filterItems: TableFilterBarDropdownItem[] = [];

  filterComparators: ((value: any) => boolean)[] = [];
  filterValues: any[][] = [];
  filterTerm = '';

  banken: IBank[];
  public bankenTableDataSource = new MatTableDataSource<IBank>([]);
  public bankenGridColumns: string[] = [
    'name',
    'boolean',
    'dateTime',
    'double',
    'guid',
    'integer',
    'detail',
  ];

  @ViewChild(MatSort) sort: MatSort;

  constructor(
    private bankenCrudService: BankenCrudService) { }

  async ngOnInit(): Promise<void> {
    this.banken = await this.bankenCrudService.getBanken();
    this.updateDataSource();
  }

  ngAfterViewInit(): void {
    if (this.sort) {
      this.bankenTableDataSource.sort = this.sort;
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
    this.bankenTableDataSource.data = this.banken.slice()
      .filter(bank => this.filterComparators.length < 1 || this.filterComparators.every(filterComparator => filterComparator(bank)))
      .filter(bank => bank.name.toString().toLowerCase().includes(this.filterTerm.trim().toLowerCase()));
  }

}
