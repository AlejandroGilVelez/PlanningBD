import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CambioPasswordDto } from '../../dto/cambio-passwordDto';
import { NewPasswordDto } from '../../dto/new-passwordDto';

@Injectable({
  providedIn: 'root'
})
export class CambiopasswordService {
  baseUrl: string = "http://localhost:5000/api/CambioPassword/";

  constructor(private http: HttpClient) { }

  validarIdExp(objExpiracionId: CambioPasswordDto){    
    return this.http.post<boolean>(this.baseUrl + "ExpiracionId" , objExpiracionId);
  }

  restaurarPassword(objNewPassword: NewPasswordDto){
    return this.http.post<string>(this.baseUrl + "RestaurarPassword", objNewPassword);
  }

}
