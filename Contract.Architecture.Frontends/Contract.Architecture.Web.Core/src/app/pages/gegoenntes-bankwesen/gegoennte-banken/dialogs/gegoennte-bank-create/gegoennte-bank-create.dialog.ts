import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { guidRegex, integerRegex } from 'src/app/helpers/regex.helper';
import { GegoennteBankenCrudService } from 'src/app/model/gegoenntes-bankwesen/gegoennte-banken/gegoennte-banken-crud.service';

@Component({
  selector: 'app-gegoennte-bank-create',
  templateUrl: './gegoennte-bank-create.dialog.html',
  styleUrls: ['./gegoennte-bank-create.dialog.scss']
})
export class GegoennteBankCreateDialog implements OnInit {

  gegoennteBankCreateForm: FormGroup;

  constructor(
    private gegoennteBankenCrudService: GegoennteBankenCrudService,
    private formBuilder: FormBuilder,
    private router: Router,
    private dialogRef: MatDialogRef<GegoennteBankCreateDialog>) {
  }

  async ngOnInit(): Promise<void> {
    this.gegoennteBankCreateForm = this.formBuilder.group({
      name: new FormControl('', [Validators.required, Validators.minLength(1), Validators.maxLength(256)]),
      gegoennterName: new FormControl('', [Validators.required, Validators.minLength(1), Validators.maxLength(256)]),
      gegoennterBoolean: new FormControl(false, [Validators.required]),
      gegoenntesDateTime: new FormControl(null, [Validators.required]),
      gegoennterDouble: new FormControl(null, [Validators.required]),
      gegoennteGuid: new FormControl(null, [Validators.required, Validators.pattern(guidRegex)]),
      gegoennterInteger: new FormControl(null, [Validators.required, Validators.pattern(integerRegex)]),
    });
  }

  async onCreateClicked(): Promise<void> {
    this.gegoennteBankCreateForm.markAllAsTouched();
    if (!this.gegoennteBankCreateForm.valid) {
      this.scrollToFirstInvalidControl();
      return;
    }

    const gegoennteBankId = await this.gegoennteBankenCrudService.createGegoennteBank(this.gegoennteBankCreateForm.getRawValue());
    this.dialogRef.close();
    await this.router.navigate(['/gegoenntes-bankwesen/gegoennte-banken/detail', gegoennteBankId]);
  }

  scrollToFirstInvalidControl(): void {
    const firstElementWithError = document.querySelector('.mat-form-field.ng-invalid');
    if (firstElementWithError) {
      firstElementWithError.scrollIntoView({ behavior: 'smooth', block: 'center' });
    }
  }

}
