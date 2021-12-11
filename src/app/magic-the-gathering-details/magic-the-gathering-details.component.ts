import { Component, OnInit } from '@angular/core';
import { MagicTheGatheringDetailsService } from '../shared/magic-the-gathering-details.service';

@Component({
  selector: 'app-magic-the-gathering-details',
  templateUrl: './magic-the-gathering-details.component.html',
  styles: [
  ]
})
export class MagicTheGatheringDetailsComponent implements OnInit {

  constructor(public magicTheGatheringDetailsService:MagicTheGatheringDetailsService) { }

  ngOnInit(): void {
    //Referesh data on construction
    this.magicTheGatheringDetailsService.refreshList();
  }

}
