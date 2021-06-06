import { IGegoennteBank } from 'src/app/model/gegoenntes-bankwesen/gegoennte-banken/dtos/i-gegoennte-bank';
import { GegoennteBankenCrudService } from 'src/app/model/gegoenntes-bankwesen/gegoennte-banken/gegoennte-banken-crud.service';
import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { guidRegex, integerRegex } from 'src/app/helpers/regex.helper';
import { GegoennterKundeUpdate } from 'src/app/model/gegoennter-kundenstamm/gegoennte-kunden/dtos/i-gegoennter-kunde-update';
import { GegoennteKundenCrudService } from 'src/app/model/gegoennter-kundenstamm/gegoennte-kunden/gegoennte-kunden-crud.service';

@Component({
  selector: 'app-gegoennter-kunde-update',
  templateUrl: './gegoennter-kunde-update.dialog.html',
  styleUrls: ['./gegoennter-kunde-update.dialog.scss']
})
export class GegoennterKundeUpdateDialog implements OnInit {

  gegoennterKundeUpdateForm: FormGroup;

  gegoennteBanken: IGegoennteBank[];

  constructor(
    private gegoennteKundenCrudService: GegoennteKundenCrudService,
    private formBuilder: FormBuilder,
    private dialogRef: MatDialogRef<GegoennterKundeUpdateDialog>,
    private gegoennteBankenCrudService: GegoennteBankenCrudService,
    @Inject(MAT_DIALOG_DATA) public gegoennterKundeId: string) {
  }

  async ngOnInit(): Promise<void> {
    const gegoennterKundeDetail = await this.gegoennteKundenCrudService.getGegoennterKundeDetail(this.gegoennterKundeId);

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

    const gegoennteBankenResult = await this.gegoennteBankenCrudService.getGegoennteBanken({ limit: 500, offset: 0 });
    this.gegoennteBanken = gegoennteBankenResult.data;
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
