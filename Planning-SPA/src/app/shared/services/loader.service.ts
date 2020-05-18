import { Injectable } from "@angular/core";
import { BehaviorSubject } from "rxjs";
import { NgxSpinnerService } from "ngx-spinner";

@Injectable({
  providedIn: "root",
})
export class LoaderService {


  constructor(private ngxSpinnerService: NgxSpinnerService) {
    
  }  

  showLoader() {
    this.ngxSpinnerService.show();
  }

  hideLoader() {
    this.ngxSpinnerService.hide();
  }
}
