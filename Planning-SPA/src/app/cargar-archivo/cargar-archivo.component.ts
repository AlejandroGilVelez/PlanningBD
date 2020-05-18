import { Component, OnInit } from '@angular/core';
import { CargararchivoService } from '../shared/services/cargararchivo.service';
import { MessageService } from 'primeng/api';
import { CargarArchivoDto } from '../dto/cargar-archivoDto';

@Component({
  selector: 'app-cargar-archivo',
  templateUrl: './cargar-archivo.component.html',
  styleUrls: ['./cargar-archivo.component.css']
})
export class CargarArchivoComponent implements OnInit {

  archivo: File;  

  constructor(private cargararchivoService: CargararchivoService,
              private messageService: MessageService) { }

  ngOnInit(): void {
  } 

  cargar(){    
    console.log("Archivo de excel", this.archivo);
    const objCargarArchivo = new CargarArchivoDto();
    objCargarArchivo.nombre = this.archivo.name;
    objCargarArchivo.extension = this.archivo.type;
    objCargarArchivo.archivo = this.archivo;    
    this.cargararchivoService.cargarArchivo(objCargarArchivo).subscribe(
      response => {
        this.messageService.add({
          severity: "success",
          summary: "Cargar Archivo",
          detail: response
        });
      },
      error => {
        this.messageService.add({
          severity: "error",
          summary: "Cargar Archivo",
          detail: "Ocurrio un error al cargar el archivo"
        });
      }
    )
  }

}
