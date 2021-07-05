import { AfterViewInit, Component, Input, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { MatSelect } from '@angular/material/select';
import { Subject, Subscription } from 'rxjs';
import { debounceTime, distinct, tap } from 'rxjs/operators';
import { distinctByField } from 'src/app/helpers/distinct';
import { MultiDataSource } from '../table-filter-bar/table-filter-bar-dropdown-multi/multi-data-source';

@Component({
  selector: 'app-search-dropdown-form',
  templateUrl: './search-dropdown-form.component.html',
  styleUrls: ['./search-dropdown-form.component.scss']
})
export class SearchDropdownFormComponent<T> implements AfterViewInit, OnDestroy {

  @Input() formGroupInstance: FormGroup;
  @Input() formControlNameInstance: string;

  @Input() label: string;
  @Input() required = false;

  selectedItem: T;
  @Input('initialItem') set _initialItem(initialItem: T) {
    if (initialItem) {
      this.selectedItem = initialItem;
      this.updateDataSource();
    }
  }

  data: T[];
  dataSource: MultiDataSource<T>;
  @Input('dataSource') set _dataSource(dataSource: MultiDataSource<T>) {
    if (dataSource) {
      this.dataSource = dataSource;
      this.updateDataSource();
    }
  }

  idExpr: any;
  @Input('idExpr') set _idExpr(idExpr: any) {
    this.idExpr = idExpr;
    this.updateDataSource();
  }

  displayExpr: any;
  @Input('displayExpr') set _displayExpr(displayExpr: any) {
    this.displayExpr = displayExpr;
    this.updateDataSource();
  }

  public filterCtrl: FormControl = new FormControl();

  @ViewChild(MatSelect) matSelect: MatSelect;
  scrollElement: any;

  dataSubscription: Subscription;
  valueChangeSubscription: Subscription;
  filterSubscription: Subscription;
  protected onDestroy = new Subject<void>();

  constructor() { }

  getDisplayname(value: T): string {
    if (this.displayExpr) {
      return value[this.displayExpr];
    } else {
      return JSON.stringify(value);
    }
  }

  getId(value: T): string {
    if (this.idExpr) {
      return value[this.idExpr];
    } else {
      return JSON.stringify(value);
    }
  }

  updateDataSource(): void {
    if (this.dataSubscription) {
      this.dataSubscription.unsubscribe();
      this.dataSubscription = null;
    }

    if (this.valueChangeSubscription) {
      this.valueChangeSubscription.unsubscribe();
      this.valueChangeSubscription = null;
    }

    if (this.filterSubscription) {
      this.filterSubscription.unsubscribe();
      this.filterSubscription = null;
    }

    if (this.dataSource && this.formGroupInstance && this.formControlNameInstance) {
      this.dataSubscription = this.dataSource.data$.subscribe((data: T[]) => {
        const scrollTop = this.scrollElement?.scrollTop;
        if (this.selectedItem) {
          this.data = distinctByField([this.selectedItem].concat(data), this.idExpr);
        } else {
          this.data = distinctByField(data, this.idExpr);
        }

        if (scrollTop) {
          setTimeout(() => {
            setTimeout(() => {
              this.scrollElement.scrollTop = scrollTop;
            }, 0);
          }, 0);
        }
      });

      this.valueChangeSubscription = this.formGroupInstance.controls[this.formControlNameInstance].valueChanges
        .subscribe((value) => {
          this.selectedItem = this.data.find(dataItem => dataItem[this.idExpr] === value);
        });

      this.filterSubscription = this.filterCtrl.valueChanges
        .pipe(
          tap(() => this.data = [this.selectedItem]),
          debounceTime(500),
        )
        .subscribe(value => this.dataSource.filter(value));
    }
  }

  ngAfterViewInit(): void {
    this.matSelect.openedChange
      .pipe(distinct())
      .subscribe((isOpen) => {
        if (isOpen) {
          this.scrollElement = this.matSelect.panel.nativeElement;
          this.scrollElement.addEventListener('scroll', event => {
            if (!this.dataSource.loading && event.target.scrollTop > event.target.scrollHeight - event.target.clientHeight - 48) {
              this.dataSource.loadNext();
            }
          });
        } else if (this.filterSubscription) {
          this.filterSubscription.unsubscribe();
          this.filterSubscription = null;
        }
      });
  }

  ngOnDestroy(): void {
    this.onDestroy.next();
    this.onDestroy.complete();
  }

}
