import { Injectable } from '@angular/core';
import { MagicTheGatheringCard } from './models/magic-the-gathering-card.model';
import {HttpClient} from "@angular/common/http"
import { BehaviorSubject } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class MagicTheGatheringDetailsService {

  private readonly baseURL:string = "http://localhost:5000/api/MagicTheGatheringCards";
  public formData:MagicTheGatheringCard;
  private mtgListSubject;
  public mtgList$;

  constructor(private http:HttpClient) {
    this.mtgListSubject =  new BehaviorSubject<MagicTheGatheringCard[]>([]);
    this.mtgList$ = this.mtgListSubject.asObservable();
    this.formData = new MagicTheGatheringCard();
  }



  //Post data to the backend
  postMagicTheGatheringCard(){
   return this.http.post(this.baseURL,this.formData);
  }

  //Gets data from the backend and refresh data on front
  refreshList(){
    this.http.get(this.baseURL)
    .toPromise()
    .then(res => {
      this.mtgListSubject.next(res as MagicTheGatheringCard[]);
    });
  }
}
