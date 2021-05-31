import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { guidRegex, integerRegex } from 'src/app/helpers/regex.helper';
import { GegoennteBankUpdate } from 'src/app/model/gegoenntes-bankwesen/gegoennte-banken/dtos/i-gegoennte-bank-update';
import { GegoennteBankenCrudService } from 'src/app/model/gegoenntes-bankwesen/gegoennte-banken/gegoennte-banken-crud.service';

@Component({
  selector: 'app-gegoennte-bank-update',
  templateUrl: './gegoennte-bank-update.dialog.html',
  styleUrls: ['./gegoennte-bank-update.dialog.scss']
})
export class GegoennteBankUpdateDialog implements OnInit {

  gegoennteBankUpdateForm: FormGroup;

  constructor(
    private gegoennteBankenCrudService: GegoennteBankenCrudService,
    private formBuilder: FormBuilder,
    private dialogRef: MatDialogRef<GegoennteBankUpdateDialog>,
    @Inject(MAT_DIALOG_DATA) public gegoennteBankId: string) {
  }

  async ngOnInit(): Promise<void> {
    const gegoennteBankDetail = await this.gegoennteBankenCrudService.getGegoennteBankDetail(this.gegoennteBankId);

    this.gegoennteBankUpdateForm = this.formBuilder.group({
      id: new FormControl({ value: '', disabled: true }, [Validators.required]),
      name: new FormControl('', [Validators.required, Validators.minLength(1), Validators.maxLength(256)]),
      gegoennterName: new FormControl('', [Validators.required, Validators.minLength(1), Validators.maxLength(256)]),
      gegoennterBoolean: new FormControl(false, [Validators.required]),
      gegoenntesDateTime: new FormControl(null, [Validators.required]),
      gegoennterDouble: new FormControl(null, [Validators.required]),
      gegoennteGuid: new FormControl(null, [Validators.required, Validators.pattern(guidRegex)]),
      gegoennterInteger: new FormControl(null, [Validators.required, Validators.pattern(integerRegex)]),
    });

    this.gegoennteBankUpdateForm.patchValue(GegoennteBankUpdate.fromGegoennteBankDetail(gegoennteBankDetail));
  }

  async onUpdateClicked(): Promise<void> {
    this.gegoennteBankUpdateForm.markAllAsTouched();
    if (!this.gegoennteBankUpdateForm.valid) {
      this.scrollToFirstInvalidControl();
      return;
    }

    const gegoennteBankUpdate = this.gegoennteBankUpdateForm.getRawValue();
    await this.gegoennteBankenCrudService.updateGegoennteBank(gegoennteBankUpdate);
    this.dialogRef.close(true);
  }

  scrollToFirstInvalidControl(): void {
    const firstElementWithError = document.querySelector('.mat-form-field.ng-invalid');
    if (firstElementWithError) {
      firstElementWithError.scrollIntoView({ behavior: 'smooth', block: 'center' });
    }
  }

}
