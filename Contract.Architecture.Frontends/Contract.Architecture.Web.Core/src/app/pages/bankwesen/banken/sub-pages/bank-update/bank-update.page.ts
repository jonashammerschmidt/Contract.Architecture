import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { guidRegex, integerRegex } from 'src/app/helpers/regex.helper';
import { BankUpdate } from 'src/app/model/bankwesen/banken/dtos/i-bank-update';
import { BankenCrudService } from 'src/app/model/bankwesen/banken/banken-crud.service';

@Component({
  selector: 'app-bank-update',
  templateUrl: './bank-update.page.html',
  styleUrls: ['./bank-update.page.scss']
})
export class BankUpdatePage implements OnInit {

  bankId: string;
  bankUpdateForm: FormGroup;

  constructor(
    private bankenCrudService: BankenCrudService,
    private formBuilder: FormBuilder,
    private activatedRoute: ActivatedRoute,
    private router: Router) {
  }

  async ngOnInit(): Promise<void> {
    this.bankUpdateForm = this.formBuilder.group({
      id: new FormControl({ value: '', disabled: true }, [Validators.required]),
      name: new FormControl('', [Validators.required, Validators.minLength(1), Validators.maxLength(256)]),
      boolean: new FormControl(null, [Validators.required]),
      dateTime: new FormControl(null, [Validators.required]),
      double: new FormControl(null, [Validators.required]),
      guid: new FormControl(null, [Validators.required, Validators.pattern(guidRegex)]),
      integer: new FormControl(null, [Validators.required, Validators.pattern(integerRegex)]),
    });

    this.activatedRoute.params.subscribe((params) => {
      if (params.id) {
        this.bankId = params.id;
        this.loadBank(this.bankId).then().catch((error) => {
          console.error(error);
        });
      }
    });
  }

  async onUpdateClicked(): Promise<void> {
    this.bankUpdateForm.markAllAsTouched();
    if (!this.bankUpdateForm.valid) {
      return;
    }

    const bankUpdate = this.bankUpdateForm.getRawValue();
    await this.bankenCrudService.updateBank(bankUpdate);
    await this.router.navigate(['/bankwesen/banken/detail', this.bankId]);
  }

  async onCancelClicked(): Promise<void> {
    await this.router.navigate(['/bankwesen/banken/detail', this.bankId]);
  }

  private async loadBank(bankId: string): Promise<void> {
    const bankDetail = await this.bankenCrudService.getBankDetail(bankId);
    this.bankUpdateForm.patchValue(BankUpdate.fromBankDetail(bankDetail));
  }

}
