import { Component, OnInit } from "@angular/core";
import { MessageService } from "primeng/api";
import { LoginDto } from "../dto/LoginDto";
import { ActivatedRoute, Router } from "@angular/router";
import { CambiopasswordService } from "../shared/services/cambiopassword.service";
import { CambioPasswordDto } from "../dto/cambio-passwordDto";
import { NewPasswordDto } from "../dto/new-passwordDto";
import { LoaderService } from "../shared/services/loader.service";

@Component({
  selector: "app-cambio-password",
  templateUrl: "./cambio-password.component.html",
  styleUrls: ["./cambio-password.component.css"],
})
export class CambioPasswordComponent implements OnInit {
  objCambioPassword = new LoginDto();
  passwordRegex = new RegExp(
    "^(((?=.*[a-z])(?=.*[A-Z]))|((?=.*[a-z])(?=.*[0-9]))|((?=.*[A-Z])(?=.*[0-9])))(?=.{6,})"
  );
  obj = new CambioPasswordDto();
  objnewpassword = new NewPasswordDto();

  constructor(
    private messageService: MessageService,
    private route: ActivatedRoute,
    private cambiopasswordService: CambiopasswordService,
    private router: Router,
    private loaderService:LoaderService
  ) {
    this.obj.id = this.route.snapshot.queryParamMap.get("id");
    this.validarId();
  }

  ngOnInit(): void {}

  validarId() {
    this.loaderService.showLoader();
    this.cambiopasswordService.validarIdExp(this.obj).subscribe(
      (result) => {
        this.loaderService.hideLoader();
        if (!result) {         
          this.messageService.add({
            severity: "error",
            summary: "Error al consultar",
            detail: "Error al validar la restauración del password",
          });
          this.router.navigate(["/"]);
        }
      },
      (error) => {
        this.loaderService.hideLoader();
        this.messageService.add({
          severity: "error",
          summary: "Error al id",
          detail: "Error al validar la restauración del password",
        });
        this.router.navigate(["/"]);
      }
    );
  }

  guardar() {
    if (!this.passwordRegex.test(this.objCambioPassword.password)) {
      this.messageService.add({
        severity: "warn",
        summary: "Password Inválido",
        detail: "Por favor ingrese un password seguro",
      });

      return;
    }

    if (!this.passwordRegex.test(this.objCambioPassword.confirmarPassword)) {
      this.messageService.add({
        severity: "warn",
        summary: "Confirmar Password Inválido",
        detail: "Por favor ingrese un password seguro",
      });

      return;
    }

    if (
      this.objCambioPassword.password !=
      this.objCambioPassword.confirmarPassword
    ) {
      this.messageService.add({
        severity: "warn",
        summary: "Verificar Password",
        detail: "No coinciden los password",
      });

      return;
    }

    this.objnewpassword.id = this.obj.id;
    this.objnewpassword.nuevopassword = this.objCambioPassword.password;
    this.loaderService.showLoader();
    this.cambiopasswordService.restaurarPassword(this.objnewpassword).subscribe(
      (next) => {
        this.loaderService.hideLoader();
        this.messageService.add({
          severity: "success",
          summary: "Guadado exitoso",
          detail: "El password se restablecio correctamente",
        });
        this.router.navigate(["/"]);
      },
      (error) => {
        this.loaderService.hideLoader();
        this.messageService.add({
          severity: "error",
          summary: "Error al guardar",
          detail: "Ocurrió un error al momento de guardar",
        });
      }
    );
  }
}
