import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-loading-spinner',
  templateUrl: './loading-spinner.component.html',
  styleUrls: ['./loading-spinner.component.scss']
})
export class LoadingSpinnerComponent {

  widthAll = '50px';
  widthProng = '4px';
  @Input() set size(value: 'normal' | 'small') {
    if (value === 'normal') {
      this.widthAll = '50px';
      this.widthProng = '4px';
    } else if (value === 'small') {
      this.widthAll = '26px';
      this.widthProng = '2px';
    }
  }

  constructor() { }

}
