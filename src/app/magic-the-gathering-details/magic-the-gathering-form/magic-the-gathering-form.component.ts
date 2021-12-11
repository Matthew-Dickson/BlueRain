import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { MagicTheGatheringDetailsService } from 'src/app/shared/magic-the-gathering-details.service';
import { MagicTheGatheringCard } from 'src/app/shared/models/magic-the-gathering-card.model';

@Component({
  selector: 'app-magic-the-gathering-form',
  templateUrl: './magic-the-gathering-form.component.html',
  styles: [
  ]
})
export class MagicTheGatheringFormComponent implements OnInit {

  constructor(public magicTheGatheringDetailsService:MagicTheGatheringDetailsService, private toastr:ToastrService) { }

  ngOnInit(): void {
  }


  //Submits magic card to the backend, then resets and references magic card list
  onSubmit(form:NgForm){
    this.magicTheGatheringDetailsService.postMagicTheGatheringCard().subscribe(
      res => {
       this.resetForm(form);
       this.magicTheGatheringDetailsService.refreshList();
       this.toastr.success("Submitted successfully", "Magic the gathering card input")
      },
      err => {console.log(err);}
    )
  }

  //Resets form and creates a new empty magic card
  private resetForm(form:NgForm){
    form.reset();
    this.magicTheGatheringDetailsService.formData = new MagicTheGatheringCard();
  }

}
