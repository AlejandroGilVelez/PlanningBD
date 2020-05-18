import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CargarArchivoDto } from '../../dto/cargar-archivoDto';

@Injectable({
  providedIn: 'root'
})
export class CargararchivoService {
  baseUrl: string ="http://localhost:5000/api/CargarArchivo/";

  constructor(private http: HttpClient) { }

  cargarArchivo(archivo: CargarArchivoDto){
    return this.http.post<string>(this.baseUrl + "Cargar", archivo);
  }

}
