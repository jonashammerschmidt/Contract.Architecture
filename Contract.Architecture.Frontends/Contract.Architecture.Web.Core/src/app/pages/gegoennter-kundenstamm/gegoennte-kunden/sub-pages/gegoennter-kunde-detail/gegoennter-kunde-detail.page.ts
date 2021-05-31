import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ActivatedRoute, Router } from '@angular/router';
import { ConfirmationDialogService } from 'src/app/components/ui/confirmation-dialog/confirmation-dialog.service';
import { GegoennteKundenCrudService } from 'src/app/model/gegoennter-kundenstamm/gegoennte-kunden/gegoennte-kunden-crud.service';
import { IGegoennterKundeDetail } from 'src/app/model/gegoennter-kundenstamm/gegoennte-kunden/dtos/i-gegoennter-kunde-detail';
import { GegoennterKundeUpdateDialog } from '../../dialogs/gegoennter-kunde-update/gegoennter-kunde-update.dialog';

@Component({
  selector: 'app-gegoennter-kunde-detail',
  templateUrl: './gegoennter-kunde-detail.page.html',
  styleUrls: ['./gegoennter-kunde-detail.page.scss']
})
export class GegoennterKundeDetailPage implements OnInit {

  gegoennterKundeId: string;
  gegoennterKunde: IGegoennterKundeDetail;

  constructor(
    private gegoennteKundenCrudService: GegoennteKundenCrudService,
    private activatedRoute: ActivatedRoute,
    private router: Router,
    private matDialog: MatDialog,
    private confirmationDialogService: ConfirmationDialogService) {
  }

  async ngOnInit(): Promise<void> {
    this.activatedRoute.params.subscribe((params) => {
      if (params.id) {
        this.gegoennterKundeId = params.id;
        this.loadGegoennterKunde().then().catch((error) => {
          console.error(error);
        });
      }
    });
  }

  async onUpdateClicked(): Promise<void> {
    const dialog = this.matDialog.open(GegoennterKundeUpdateDialog, {
        data: this.gegoennterKundeId,
        minWidth: '320px',
    });

    if (await dialog.afterClosed().toPromise()) {
      await this.loadGegoennterKunde();
    }
  }

  async onDeleteClicked(): Promise<void> {
    if (await this.confirmationDialogService.askForConfirmation('Wollen Sie wirklich Gegönnter Kunde \'' + this.gegoennterKunde.name + '\' löschen?')) {
        await this.gegoennteKundenCrudService.deleteGegoennterKunde(this.gegoennterKunde.id);
        await this.router.navigate(['/gegoennter-kundenstamm/gegoennte-kunden']);
    }
  }

  private async loadGegoennterKunde(): Promise<void> {
    this.gegoennterKunde = null;
    this.gegoennterKunde = await this.gegoennteKundenCrudService.getGegoennterKundeDetail(this.gegoennterKundeId);
  }

}
