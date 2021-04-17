import { IKunde } from 'src/app/model/kundenstamm/kunden/dtos/i-kunde';
import { MatTableDataSource } from '@angular/material/table';
import { Location } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { BankenCrudService } from 'src/app/model/bankwesen/banken/banken-crud.service';
import { IBankDetail } from 'src/app/model/bankwesen/banken/dtos/i-bank-detail';

@Component({
  selector: 'app-bank-detail',
  templateUrl: './bank-detail.page.html',
  styleUrls: ['./bank-detail.page.scss']
})
export class BankDetailPage implements OnInit {

  public kundenTableDataSource = new MatTableDataSource<IKunde>([]);
  public kundenGridColumns: string[] = [
    'name',
    'detail',
  ];

  bank: IBankDetail;

  constructor(
    private bankenCrudService: BankenCrudService,
    private activatedRoute: ActivatedRoute,
    private location: Location,
    private router: Router) {
  }

  async ngOnInit(): Promise<void> {
    this.activatedRoute.params.subscribe((params) => {
      if (params.id) {
        this.loadBank(params.id).then().catch((error) => {
          console.error(error);
        });
      }
    });
  }

  async onCancelClicked(): Promise<void> {
    this.location.back();
  }

  async onUpdateClicked(): Promise<void> {
    await this.router.navigate(['/bankwesen/banken/update', this.bank.id]);
  }

  async onDeleteClicked(): Promise<void> {
    await this.bankenCrudService.deleteBank(this.bank.id);
    await this.router.navigate(['/bankwesen/banken']);
  }

  private async loadBank(bankId: string): Promise<void> {
    this.bank = await this.bankenCrudService.getBankDetail(bankId);

    this.kundenTableDataSource.data = this.bank.kunden;
  }

}
