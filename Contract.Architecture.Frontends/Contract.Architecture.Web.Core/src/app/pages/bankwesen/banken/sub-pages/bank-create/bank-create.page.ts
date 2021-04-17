import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { guidRegex, integerRegex } from 'src/app/helpers/regex.helper';
import { BankenCrudService } from 'src/app/model/bankwesen/banken/banken-crud.service';

@Component({
  selector: 'app-bank-create',
  templateUrl: './bank-create.page.html',
  styleUrls: ['./bank-create.page.scss']
})
export class BankCreatePage implements OnInit {

  bankCreateForm: FormGroup;

  constructor(
    private bankenCrudService: BankenCrudService,
    private formBuilder: FormBuilder,
    private router: Router) {
  }

  async ngOnInit(): Promise<void> {
    this.bankCreateForm = this.formBuilder.group({
      name: new FormControl('', [Validators.required, Validators.minLength(1), Validators.maxLength(256)]),
      boolean: new FormControl(null, [Validators.required]),
      dateTime: new FormControl(null, [Validators.required]),
      double: new FormControl(null, [Validators.required]),
      guid: new FormControl(null, [Validators.required, Validators.pattern(guidRegex)]),
      integer: new FormControl(null, [Validators.required, Validators.pattern(integerRegex)]),
    });
  }

  async onCreateClicked(): Promise<void> {
    this.bankCreateForm.markAllAsTouched();
    if (!this.bankCreateForm.valid) {
      return;
    }

    const bankId = await this.bankenCrudService.createBank(this.bankCreateForm.getRawValue());
    await this.router.navigate(['/bankwesen/banken/detail', bankId]);
  }

  async onCancelClicked(): Promise<void> {
    await this.router.navigate(['/bankwesen/banken']);
  }

}
