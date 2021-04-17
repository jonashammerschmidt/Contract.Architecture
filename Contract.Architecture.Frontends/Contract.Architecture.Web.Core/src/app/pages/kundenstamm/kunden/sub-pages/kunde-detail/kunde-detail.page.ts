import { Location } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { KundenCrudService } from 'src/app/model/kundenstamm/kunden/kunden-crud.service';
import { IKundeDetail } from 'src/app/model/kundenstamm/kunden/dtos/i-kunde-detail';

@Component({
  selector: 'app-kunde-detail',
  templateUrl: './kunde-detail.page.html',
  styleUrls: ['./kunde-detail.page.scss']
})
export class KundeDetailPage implements OnInit {

  kunde: IKundeDetail;

  constructor(
    private kundenCrudService: KundenCrudService,
    private activatedRoute: ActivatedRoute,
    private location: Location,
    private router: Router) {
  }

  async ngOnInit(): Promise<void> {
    this.activatedRoute.params.subscribe((params) => {
      if (params.id) {
        this.loadKunde(params.id).then().catch((error) => {
          console.error(error);
        });
      }
    });
  }

  async onCancelClicked(): Promise<void> {
    this.location.back();
  }

  async onUpdateClicked(): Promise<void> {
    await this.router.navigate(['/kundenstamm/kunden/update', this.kunde.id]);
  }

  async onDeleteClicked(): Promise<void> {
    await this.kundenCrudService.deleteKunde(this.kunde.id);
    await this.router.navigate(['/kundenstamm/kunden']);
  }

  private async loadKunde(kundeId: string): Promise<void> {
    this.kunde = await this.kundenCrudService.getKundeDetail(kundeId);
  }

}
