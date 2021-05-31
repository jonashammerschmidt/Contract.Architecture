import { IGegoennteBank } from 'src/app/model/gegoenntes-bankwesen/gegoennte-banken/dtos/i-gegoennte-bank';
import { GegoennteBankenCrudService } from 'src/app/model/gegoenntes-bankwesen/gegoennte-banken/gegoennte-banken-crud.service';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { guidRegex, integerRegex } from 'src/app/helpers/regex.helper';
import { GegoennteKundenCrudService } from 'src/app/model/gegoennter-kundenstamm/gegoennte-kunden/gegoennte-kunden-crud.service';

@Component({
  selector: 'app-gegoennter-kunde-create',
  templateUrl: './gegoennter-kunde-create.dialog.html',
  styleUrls: ['./gegoennter-kunde-create.dialog.scss']
})
export class GegoennterKundeCreateDialog implements OnInit {

  gegoennterKundeCreateForm: FormGroup;

  gegoennteBanken: IGegoennteBank[];

  constructor(
    private gegoennteKundenCrudService: GegoennteKundenCrudService,
    private formBuilder: FormBuilder,
    private gegoennteBankenCrudService: GegoennteBankenCrudService,
    private router: Router,
    private dialogRef: MatDialogRef<GegoennterKundeCreateDialog>) {
  }

  async ngOnInit(): Promise<void> {
    this.gegoennterKundeCreateForm = this.formBuilder.group({
      name: new FormControl('', [Validators.required, Validators.minLength(1), Validators.maxLength(256)]),
      gegoennterName: new FormControl('', [Validators.required, Validators.minLength(1), Validators.maxLength(256)]),
      gegoennterBoolean: new FormControl(false, []),
      gegoennterDateTime: new FormControl(null, []),
      gegoennterDouble: new FormControl(null, []),
      gegoennterGuid: new FormControl(null, [Validators.pattern(guidRegex)]),
      gegoennterInteger: new FormControl(null, [Validators.pattern(integerRegex)]),
      besteBankId: new FormControl(null, [Validators.required]),
    });

    this.gegoennteBanken = await this.gegoennteBankenCrudService.getGegoennteBanken();
  }

  async onCreateClicked(): Promise<void> {
    this.gegoennterKundeCreateForm.markAllAsTouched();
    if (!this.gegoennterKundeCreateForm.valid) {
      this.scrollToFirstInvalidControl();
      return;
    }

    const gegoennterKundeId = await this.gegoennteKundenCrudService.createGegoennterKunde(this.gegoennterKundeCreateForm.getRawValue());
    this.dialogRef.close();
    await this.router.navigate(['/gegoennter-kundenstamm/gegoennte-kunden/detail', gegoennterKundeId]);
  }

  scrollToFirstInvalidControl(): void {
    const firstElementWithError = document.querySelector('.mat-form-field.ng-invalid');
    if (firstElementWithError) {
      firstElementWithError.scrollIntoView({ behavior: 'smooth', block: 'center' });
    }
  }

}
