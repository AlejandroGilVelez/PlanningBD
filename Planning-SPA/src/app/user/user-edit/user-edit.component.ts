import { Component, OnInit } from "@angular/core";
import { User } from "../../models/user.model";
import { HttpClient } from "@angular/common/http";
import { Router } from "@angular/router";
import { MessageService } from "primeng/api";
import { UserService } from "../../shared/services/user.service";
import { LoaderService } from "../../shared/services/loader.service";

@Component({
  selector: "app-user-edit",
  templateUrl: "./user-edit.component.html",
  styleUrls: ["./user-edit.component.css"]
})
export class UserEditComponent implements OnInit {  
  usuarioSeleccionado: User;
  esNuevoUsuario: boolean;
  emailRegex = /^([A-Za-z0-9_\-.])+@([A-Za-z0-9_\-.])+\.([A-Za-z]{2,4})$/;

  constructor(    
    private route: Router,
    private userService: UserService,
    private messageService: MessageService,
    private loaderService:LoaderService
  ) {}
  ngOnInit(): void {
    this.esNuevoUsuario = true;
    this.usuarioSeleccionado = new User();

    const idUsuario = localStorage.getItem("idUsuarioEditar");
    if (idUsuario != null) {
      // Editando
      this.usuarioAntiguo(idUsuario);
      this.esNuevoUsuario = false;
    }
  }

  usuarioAntiguo(id: string) {
    this.loaderService.showLoader();
    this.userService.obtenerUsuario(id).subscribe(
      result => {
        this.loaderService.hideLoader();
        this.usuarioSeleccionado = result;
        // console.log("Resultado", this.usuarioSeleccionado);
      },
      error => {
        this.loaderService.hideLoader();
        this.messageService.add({
          severity: "error",
          summary: "Error al consultar",
          detail: "Erro al consultar el usuario"
        });
      }
    );
    /* 
    1. Llamar al backend para obtener el usuario
    2. En el response usuarioSelecionado = a respuesta
    */
  }

  guardar() {
    if (!this.emailRegex.test(this.usuarioSeleccionado.correo)) {
      this.messageService.add({
        severity: "warn",
        summary: "Correo Inválido",
        detail: "Por favor ingrese un correo válido"
      });

      return;
    }
    if (this.esNuevoUsuario) {  
      this.loaderService.showLoader();    
      this.userService.crearUsuario(this.usuarioSeleccionado)
        .subscribe(
          next => {
            this.loaderService.hideLoader();
            this.messageService.add({
              severity: "success",
              summary: "Guadado exitoso",
              detail: "El usuario se creo correctamente"
            });
            this.route.navigate(["/user"]);
          },
          error => {
            this.loaderService.hideLoader();
            this.messageService.add({
              severity: "error",
              summary: "Error al guardar",
              detail: `Ocurrió un error al momento de guardar. Detalle error: ${error.error}`
            });
          }
        );
    } else {    
      this.loaderService.showLoader()  
      this.userService.editarUsuario(this.usuarioSeleccionado)
        .subscribe(
          next => {
            this.loaderService.hideLoader();
            this.messageService.add({
              severity: "success",
              summary: "Guadado exitoso",
              detail: "El usuario se actualizó correctamente"
            });
            this.route.navigate(["/user"]);
          },
          error => {
            this.loaderService.hideLoader();
            this.messageService.add({
              severity: "error",
              summary: "Error al guardar",
              detail: "Ocurrió un error al momento de guardar"
            });
          }
        );
    }

    /* 
    1. Llamar al backend para guardar el usuario
    2. Mostrar mensaje que guardo bien o que ocurrio un error
    3. redireccionar a la pagina de usuarios.
    */
  }
  cancelar() {
    // Redireccionar a pagina de usuario.
    this.route.navigate(["/user"]);
  }
}
