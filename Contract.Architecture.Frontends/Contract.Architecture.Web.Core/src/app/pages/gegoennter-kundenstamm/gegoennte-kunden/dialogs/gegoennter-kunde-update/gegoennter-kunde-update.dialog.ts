import { IGegoennteBank } from 'src/app/model/gegoenntes-bankwesen/gegoennte-banken/dtos/i-gegoennte-bank';
import { GegoennteBankenCrudService } from 'src/app/model/gegoenntes-bankwesen/gegoennte-banken/gegoennte-banken-crud.service';
import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { guidRegex, integerRegex } from 'src/app/helpers/regex.helper';
import { GegoennterKundeUpdate } from 'src/app/model/gegoennter-kundenstamm/gegoennte-kunden/dtos/i-gegoennter-kunde-update';
import { GegoennteKundenCrudService } from 'src/app/model/gegoennter-kundenstamm/gegoennte-kunden/gegoennte-kunden-crud.service';
import { MultiDataSource } from 'src/app/components/ui/table-filter-bar/table-filter-bar-dropdown-multi/multi-data-source';
import { IGegoennteBankDetail } from 'src/app/model/gegoenntes-bankwesen/gegoennte-banken/dtos/i-gegoennte-bank-detail';

@Component({
  selector: 'app-gegoennter-kunde-update',
  templateUrl: './gegoennter-kunde-update.dialog.html',
  styleUrls: ['./gegoennter-kunde-update.dialog.scss']
})
export class GegoennterKundeUpdateDialog implements OnInit {

  gegoennterKundeUpdateForm: FormGroup;

  gegoennteBankenDataSource: MultiDataSource<IGegoennteBank>;
  selectedBesteBank: IGegoennteBank;

  constructor(
    private gegoennteKundenCrudService: GegoennteKundenCrudService,
    private gegoennteBankenCrudService: GegoennteBankenCrudService,
    private formBuilder: FormBuilder,
    private dialogRef: MatDialogRef<GegoennterKundeUpdateDialog>,
    @Inject(MAT_DIALOG_DATA) public gegoennterKundeId: string) {
  }

  async ngOnInit(): Promise<void> {
    const gegoennterKundeDetail = await this.gegoennteKundenCrudService.getGegoennterKundeDetail(this.gegoennterKundeId);
    this.selectedBesteBank = gegoennterKundeDetail.besteBank;

    this.gegoennterKundeUpdateForm = this.formBuilder.group({
      id: new FormControl({ value: '', disabled: true }, [Validators.required]),
      name: new FormControl('', [Validators.required, Validators.minLength(1), Validators.maxLength(256)]),
      gegoennterName: new FormControl('', [Validators.required, Validators.minLength(1), Validators.maxLength(256)]),
      gegoennterBoolean: new FormControl(false, []),
      gegoennterDateTime: new FormControl(null, []),
      gegoennterDouble: new FormControl(null, []),
      gegoennterGuid: new FormControl(null, [Validators.pattern(guidRegex)]),
      gegoennterInteger: new FormControl(null, [Validators.pattern(integerRegex)]),
      besteBankId: new FormControl(null, [Validators.required]),
    });

    this.gegoennterKundeUpdateForm.patchValue(GegoennterKundeUpdate.fromGegoennterKundeDetail(gegoennterKundeDetail));

    this.gegoennteBankenDataSource = new MultiDataSource(
      (pageSize: number, pageIndex: number, filterTerm: string) => {
        return this.gegoennteBankenCrudService.getGegoennteBanken({
          limit: pageSize,
          offset: pageSize * pageIndex,
          filters: [
            {
              filterField: 'name',
              containsFilters: [filterTerm]
            }
          ]
        });
      });
  }

  async onUpdateClicked(): Promise<void> {
    this.gegoennterKundeUpdateForm.markAllAsTouched();
    if (!this.gegoennterKundeUpdateForm.valid) {
      this.scrollToFirstInvalidControl();
      return;
    }

    const gegoennterKundeUpdate = this.gegoennterKundeUpdateForm.getRawValue();
    await this.gegoennteKundenCrudService.updateGegoennterKunde(gegoennterKundeUpdate);
    this.dialogRef.close(true);
  }

  scrollToFirstInvalidControl(): void {
    const firstElementWithError = document.querySelector('.mat-form-field.ng-invalid');
    if (firstElementWithError) {
      firstElementWithError.scrollIntoView({ behavior: 'smooth', block: 'center' });
    }
  }

}
