import { Injectable } from '@angular/core';
import { User } from '../../models/user.model';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  baseUrl: string = "http://localhost:5000/api/";
  records: Array<User> = [];
  usuarioSeleccionado: User;

  constructor(private http: HttpClient) { }

  getUsers(){
    return this.http.get<User[]>(this.baseUrl + "User/List");  
  }
  delete(usuarioSeleccionado: User){
    return this.http.delete(this.baseUrl + "User/Delete/" + usuarioSeleccionado.id);
  }
  cambioEstado(usuarioSeleccionado: User){
    return this.http.post<User>(this.baseUrl + "User/CambioEstado", usuarioSeleccionado);
  }
  obtenerUsuario(id: string){
    return this.http.get<User>(this.baseUrl + "User/Get/" + id);
  }
  crearUsuario(usuarioSeleccionado: User){
    return this.http.post<User>(this.baseUrl + "User/Create", usuarioSeleccionado);
  }
  editarUsuario(usuarioSeleccionado: User){
    return this.http.put<string>(this.baseUrl + "User/Update", usuarioSeleccionado);
  }  
}
