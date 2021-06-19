import { IGegoennterKunde } from 'src/app/model/gegoennter-kundenstamm/gegoennte-kunden/dtos/i-gegoennter-kunde';
import { MatTableDataSource } from '@angular/material/table';
import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ActivatedRoute, Router } from '@angular/router';
import { ConfirmationDialogService } from 'src/app/components/ui/confirmation-dialog/confirmation-dialog.service';
import { GegoennteBankenCrudService } from 'src/app/model/gegoenntes-bankwesen/gegoennte-banken/gegoennte-banken-crud.service';
import { IGegoennteBankDetail } from 'src/app/model/gegoenntes-bankwesen/gegoennte-banken/dtos/i-gegoennte-bank-detail';
import { GegoennteBankUpdateDialog } from '../../dialogs/gegoennte-bank-update/gegoennte-bank-update.dialog';

@Component({
  selector: 'app-gegoennte-bank-detail',
  templateUrl: './gegoennte-bank-detail.page.html',
  styleUrls: ['./gegoennte-bank-detail.page.scss']
})
export class GegoennteBankDetailPage implements OnInit {

  public gegoennteKundenTableDataSource = new MatTableDataSource<IGegoennterKunde>([]);
  public gegoennteKundenGridColumns: string[] = [
    'name',
    'detail',
  ];

  gegoennteBankId: string;
  gegoennteBank: IGegoennteBankDetail;

  constructor(
    private gegoennteBankenCrudService: GegoennteBankenCrudService,
    private activatedRoute: ActivatedRoute,
    private router: Router,
    private matDialog: MatDialog,
    private confirmationDialogService: ConfirmationDialogService) {
  }

  async ngOnInit(): Promise<void> {
    this.activatedRoute.params.subscribe((params) => {
      if (params.id) {
        this.gegoennteBankId = params.id;
        this.loadGegoennteBank().then().catch((error) => {
          console.error(error);
        });
      }
    });
  }

  async onUpdateClicked(): Promise<void> {
    const dialog = this.matDialog.open(GegoennteBankUpdateDialog, {
        data: this.gegoennteBankId,
        minWidth: '320px',
    });

    if (await dialog.afterClosed().toPromise()) {
      await this.loadGegoennteBank();
    }
  }

  async onDeleteClicked(): Promise<void> {
    if (await this.confirmationDialogService.askForConfirmation('Wollen Sie wirklich Gegönnte Bank \'' + this.gegoennteBank.name + '\' löschen?')) {
        await this.gegoennteBankenCrudService.deleteGegoennteBank(this.gegoennteBank.id);
        await this.router.navigate(['/gegoenntes-bankwesen/gegoennte-banken']);
    }
  }

  private async loadGegoennteBank(): Promise<void> {
    this.gegoennteBank = null;
    this.gegoennteBank = await this.gegoennteBankenCrudService.getGegoennteBankDetail(this.gegoennteBankId);

    this.gegoennteKundenTableDataSource.data = this.gegoennteBank.besteKunden;
  }

}
