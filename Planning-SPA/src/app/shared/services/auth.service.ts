import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { AuthDto } from "../../dto/authDto";
import { LoginDto } from "../../dto/LoginDto";

@Injectable({
  providedIn: "root",
})
export class AuthService {
  baseUrl: string = "http://localhost:5000/api/";
  nombreUsuario: string;

  constructor(private http: HttpClient) {}

  loginToken(objLogin: LoginDto) {
    return this.http.post<AuthDto>(this.baseUrl + "Auth/Login", objLogin);
  }

  estaLogueado(): boolean{
    return localStorage.getItem("autkey")!= null && localStorage.getItem("autkey").length > 1;
  }

  deleteKey(){
    localStorage.removeItem("autkey");
  }

}
