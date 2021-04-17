import { IBank } from 'src/app/model/bankwesen/banken/dtos/i-bank';
import { BankenCrudService } from 'src/app/model/bankwesen/banken/banken-crud.service';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { guidRegex, integerRegex } from 'src/app/helpers/regex.helper';
import { KundeUpdate } from 'src/app/model/kundenstamm/kunden/dtos/i-kunde-update';
import { KundenCrudService } from 'src/app/model/kundenstamm/kunden/kunden-crud.service';

@Component({
  selector: 'app-kunde-update',
  templateUrl: './kunde-update.page.html',
  styleUrls: ['./kunde-update.page.scss']
})
export class KundeUpdatePage implements OnInit {

  kundeId: string;
  kundeUpdateForm: FormGroup;

  banken: IBank[];

  constructor(
    private kundenCrudService: KundenCrudService,
    private formBuilder: FormBuilder,
    private activatedRoute: ActivatedRoute,
    private bankenCrudService: BankenCrudService,
    private router: Router) {
  }

  async ngOnInit(): Promise<void> {
    this.kundeUpdateForm = this.formBuilder.group({
      id: new FormControl({ value: '', disabled: true }, [Validators.required]),
      name: new FormControl('', [Validators.maxLength(256)]),
      boolean: new FormControl(null, []),
      dateTime: new FormControl(null, []),
      double: new FormControl(null, []),
      guid: new FormControl(null, [Validators.pattern(guidRegex)]),
      integer: new FormControl(null, [Validators.pattern(integerRegex)]),
      bankId: new FormControl(null, [Validators.required]),
    });

    this.activatedRoute.params.subscribe((params) => {
      if (params.id) {
        this.kundeId = params.id;
        this.loadKunde(this.kundeId).then().catch((error) => {
          console.error(error);
        });
      }
    });

    this.banken = await this.bankenCrudService.getBanken();
  }

  async onUpdateClicked(): Promise<void> {
    this.kundeUpdateForm.markAllAsTouched();
    if (!this.kundeUpdateForm.valid) {
      return;
    }

    const kundeUpdate = this.kundeUpdateForm.getRawValue();
    await this.kundenCrudService.updateKunde(kundeUpdate);
    await this.router.navigate(['/kundenstamm/kunden/detail', this.kundeId]);
  }

  async onCancelClicked(): Promise<void> {
    await this.router.navigate(['/kundenstamm/kunden/detail', this.kundeId]);
  }

  private async loadKunde(kundeId: string): Promise<void> {
    const kundeDetail = await this.kundenCrudService.getKundeDetail(kundeId);
    this.kundeUpdateForm.patchValue(KundeUpdate.fromKundeDetail(kundeDetail));
  }

}
