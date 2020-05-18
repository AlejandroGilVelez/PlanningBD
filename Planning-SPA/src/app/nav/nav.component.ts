import { Component, OnInit } from "@angular/core";
import { LoginDto } from "../dto/LoginDto";
import { MessageService } from "primeng/api";
import { HttpClient } from "@angular/common/http";
import { AuthService } from "../shared/services/auth.service";
import * as jwt_decode from "jwt-decode";
import { Router } from "@angular/router";

@Component({
  selector: "app-nav",
  templateUrl: "./nav.component.html",
  styleUrls: ["./nav.component.css"]
})
export class NavComponent implements OnInit {
  nombreUsuario: string;
  objLogin = new LoginDto();
  

  constructor(
    private http: HttpClient,
    private messageService: MessageService,
    private authService: AuthService,
    private route: Router             
  ) {}

  ngOnInit(): void {
    
  }

  estaLogueado() : boolean {
    return this.authService.estaLogueado();    
  }

  logout() {
     this.authService.deleteKey();
     this.route.navigateByUrl("/");
  }

  login() {
    if (this.objLogin.email == null) {
      this.messageService.add({
        severity: "warn",
        summary: "Login",
        detail: "Por favor Ingrese un usuario"
      });
      return;
    }
    if (this.objLogin.password == null) {
      this.messageService.add({
        severity: "warn",
        summary: "Login",
        detail: "Por favor Ingrese un password"
      });
      return;
    }
    this.authService.loginToken(this.objLogin)
      .subscribe(
        response => {
          localStorage.setItem("autkey", response.token);
          const tokenDecode = jwt_decode(response.token);
          this.nombreUsuario = tokenDecode.unique_name;
        },
        error => {
          this.messageService.add({
            severity: "error",
            summary: "Error al login",
            detail: "Las credenciales ingresadas no son válidas"
          });
        }
      );
  }
}
