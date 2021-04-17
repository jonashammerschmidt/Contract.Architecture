import { IBank } from 'src/app/model/bankwesen/banken/dtos/i-bank';
import { BankenCrudService } from 'src/app/model/bankwesen/banken/banken-crud.service';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { guidRegex, integerRegex } from 'src/app/helpers/regex.helper';
import { KundenCrudService } from 'src/app/model/kundenstamm/kunden/kunden-crud.service';

@Component({
  selector: 'app-kunde-create',
  templateUrl: './kunde-create.page.html',
  styleUrls: ['./kunde-create.page.scss']
})
export class KundeCreatePage implements OnInit {

  kundeCreateForm: FormGroup;

  banken: IBank[];

  constructor(
    private kundenCrudService: KundenCrudService,
    private formBuilder: FormBuilder,
    private bankenCrudService: BankenCrudService,
    private router: Router) {
  }

  async ngOnInit(): Promise<void> {
    this.kundeCreateForm = this.formBuilder.group({
      name: new FormControl('', [Validators.maxLength(256)]),
      boolean: new FormControl(null, []),
      dateTime: new FormControl(null, []),
      double: new FormControl(null, []),
      guid: new FormControl(null, [Validators.pattern(guidRegex)]),
      integer: new FormControl(null, [Validators.pattern(integerRegex)]),
      bankId: new FormControl(null, [Validators.required]),
    });

    this.banken = await this.bankenCrudService.getBanken();
  }

  async onCreateClicked(): Promise<void> {
    this.kundeCreateForm.markAllAsTouched();
    if (!this.kundeCreateForm.valid) {
      return;
    }

    const kundeId = await this.kundenCrudService.createKunde(this.kundeCreateForm.getRawValue());
    await this.router.navigate(['/kundenstamm/kunden/detail', kundeId]);
  }

  async onCancelClicked(): Promise<void> {
    await this.router.navigate(['/kundenstamm/kunden']);
  }

}
