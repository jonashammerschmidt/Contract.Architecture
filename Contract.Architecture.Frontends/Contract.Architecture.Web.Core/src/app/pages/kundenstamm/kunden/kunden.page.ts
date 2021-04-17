import { IBank } from 'src/app/model/bankwesen/banken/dtos/i-bank';
import { BankenCrudService } from 'src/app/model/bankwesen/banken/banken-crud.service';
import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { TableFilterBarDropdownItem } from 'src/app/components/ui/table-filter-bar/table-filter-bar-dropdown-item';
import { KundenCrudService } from 'src/app/model/kundenstamm/kunden/kunden-crud.service';
import { IKunde } from 'src/app/model/kundenstamm/kunden/dtos/i-kunde';

@Component({
  selector: 'app-kunden',
  templateUrl: './kunden.page.html',
  styleUrls: ['./kunden.page.scss']
})
export class KundenPage implements OnInit, AfterViewInit {

  filterItems: TableFilterBarDropdownItem[] = [];

  filterComparators: ((value: any) => boolean)[] = [];
  filterValues: any[][] = [];
  filterTerm = '';

  kunden: IKunde[];
  public kundenTableDataSource = new MatTableDataSource<IKunde>([]);
  public kundenGridColumns: string[] = [
    'name',
    'boolean',
    'dateTime',
    'double',
    'guid',
    'integer',
    'bank',
    'detail',
  ];

  @ViewChild(MatSort) sort: MatSort;

  banken: IBank[];

  constructor(
    private bankenCrudService: BankenCrudService,
    private kundenCrudService: KundenCrudService) { }

  async ngOnInit(): Promise<void> {
    await this.setupBankenFilter();

    this.kunden = await this.kundenCrudService.getKunden();
    this.updateDataSource();
  }

  ngAfterViewInit(): void {
    if (this.sort) {
      this.kundenTableDataSource.sort = this.sort;
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
    this.kundenTableDataSource.data = this.kunden.slice()
      .filter(kunde => this.filterComparators.length < 1 || this.filterComparators.every(filterComparator => filterComparator(kunde)))
      .filter(kunde => kunde.name.toString().toLowerCase().includes(this.filterTerm.trim().toLowerCase()));
  }


  public getBankName(bankId: string): string {
    return this.banken.find(bank => bank.id === bankId).name;
  }

  private async setupBankenFilter(): Promise<void> {
    this.banken = await this.bankenCrudService.getBanken();

    this.filterItems.push({
      dataName: 'Banken',
      dataSource: this.banken,
      valueExpr: 'id',
      displayExpr: 'name',
    });

    const filterValuesIndex = this.filterValues.length;
    this.filterValues.push([]);

    this.filterComparators.push((kunde) => {
      return this.filterValues[filterValuesIndex].length < 1 ||
        this.filterValues[filterValuesIndex].includes(kunde.bankId);
    });
  }
}
