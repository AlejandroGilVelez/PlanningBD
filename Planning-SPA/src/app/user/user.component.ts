import { Component, OnInit } from "@angular/core";
import { HttpClient} from "@angular/common/http";
import { User } from "../models/user.model";
import { Router } from "@angular/router";

import { MessageService } from "primeng/api";
import { UserService } from "../shared/services/user.service";
import { LoaderService } from "../shared/services/loader.service";

@Component({
  selector: "app-user",
  templateUrl: "./user.component.html",
  styleUrls: ["./user.component.css"]
})
export class UserComponent implements OnInit {  
  records: Array<User> = [];
  usuarioSeleccionado: User;  

  constructor(    
    private route: Router,
    private userService: UserService,
    private messageService: MessageService,
    private loaderService: LoaderService
  ) {}
  ngOnInit(): void {
    this.getUsers();
  }

  getUsers() {
    this.loaderService.showLoader();
    this.userService.getUsers().subscribe(
    result => {
      this.loaderService.hideLoader();
      this.records = [...result];      
    },
    err => {
      this.loaderService.hideLoader();
      this.onReject();
      this.messageService.add({
        severity: "error",
        summary: "Error al cargar",
        detail: "Ocurrió un error al momento de cargar lista de usuarios"
      });
    }
  )    
  }  
  agregarUsuario() {
    localStorage.removeItem("idUsuarioEditar");
    this.route.navigate(["/user-edit"]);
  }
  editar(row: User) {
    localStorage.setItem("idUsuarioEditar", row.id);
    this.route.navigate(["/user-edit"]);
  }

  delete(row: User) {
    this.usuarioSeleccionado = row;
    this.messageService.clear();
    this.messageService.add({
      key: "c",
      sticky: true,
      severity: "warn",
      summary: "Eliminar el Usuario?",
      detail: "Esta seguro que desea eliminar el usuario"
    });
  }
  onConfirm() {
    this.loaderService.showLoader();
    this.userService.delete(this.usuarioSeleccionado)    
      .subscribe(
        result => {
          this.loaderService.hideLoader();
          this.onReject();
          this.getUsers();
        },
        err => {
          this.loaderService.hideLoader();
          this.onReject();
          this.messageService.add({
            severity: "error",
            summary: "Error al guardar",
            detail: "Ocurrió un error al momento de guardar"
          });
        }
      );
  }
  onReject() {
    this.messageService.clear("c");
  }

  cambioEstado(e, row: User) {
    let isChecked = e.checked;
    this.usuarioSeleccionado = row;
    this.loaderService.showLoader();
          this.userService.cambioEstado(this.usuarioSeleccionado).subscribe(
          next => {
            this.loaderService.hideLoader();
            this.messageService.add({
              severity: "success",
              summary: "Guadado exitoso",
              detail: `El usuario se ${isChecked?"activo":"inactivo"} correctamente`
            });
            this.getUsers();
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

  }
}
