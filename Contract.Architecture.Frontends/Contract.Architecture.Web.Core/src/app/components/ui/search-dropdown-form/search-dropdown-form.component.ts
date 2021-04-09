import { Component, Input, OnDestroy, OnInit } from '@angular/core';
import { FormControl, FormGroup, FormGroupDirective, NgForm } from '@angular/forms';
import { ErrorStateMatcher } from '@angular/material/core';
import { ReplaySubject, Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';

/** Error when invalid control is dirty, touched, or submitted. */
export class MyErrorStateMatcher implements ErrorStateMatcher {
  isErrorState(control: FormControl | null, form: FormGroupDirective | NgForm | null): boolean {
    const isSubmitted = form && form.submitted;
    return !!(control && control.invalid && (control.dirty || control.touched || isSubmitted));
  }
}

@Component({
  selector: 'app-search-dropdown-form',
  templateUrl: './search-dropdown-form.component.html',
  styleUrls: ['./search-dropdown-form.component.scss']
})
export class SearchDropdownFormComponent<T> implements OnInit, OnDestroy {

  matcher = new MyErrorStateMatcher();

  @Input() formGroupInstance: FormGroup;
  @Input() formControlNameInstance: string;

  @Input() label: string;

  dataSource: T[];
  @Input('dataSource') set _dataSource(dataSource: T[]) {
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

  // ----------- TAKEN FROM EXAMPLE -----------

  /** control for the MatSelect filter keyword */
  public filterCtrl: FormControl = new FormControl();

  /** list of dataSource filtered by search keyword */
  public filteredDataSource: ReplaySubject<T[]> = new ReplaySubject<T[]>(1);

  /** Subject that emits when the component has been destroyed. */
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
    if (this.dataSource && this.displayExpr) {
      this.dataSource = this.dataSource
        .sort((a, b) => this.getDisplayname(a).localeCompare(this.getDisplayname(b)));
    }

    this.filterDataSource();
  }

  // ----------- TAKEN FROM EXAMPLE -----------

  ngOnInit(): void {
    // listen for search field value changes
    this.filterCtrl.valueChanges
      .pipe(takeUntil(this.onDestroy))
      .subscribe(() => {
        this.filterDataSource();
      });
  }

  ngOnDestroy(): void {
    this.onDestroy.next();
    this.onDestroy.complete();
  }

  protected filterDataSource(): void {
    if (!this.dataSource || !this.displayExpr) {
      return;
    }

    // get the search keyword
    let search = this.filterCtrl.value;
    if (!search) {
      this.filteredDataSource.next(this.dataSource.slice());
      return;
    } else {
      search = search.toLowerCase();
    }

    // filter the dataSource
    this.filteredDataSource.next(
      this.dataSource.filter(item => this.getDisplayname(item).toLowerCase().indexOf(search) > -1)
    );
  }
}
