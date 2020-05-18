import { Routes } from "@angular/router";
import { UserComponent } from "./user/user.component";
import { UserEditComponent } from "./user/user-edit/user-edit.component";
import { HomeComponent } from "./home/home.component";
import { CambioPasswordComponent } from "./cambio-password/cambio-password.component";
import { CargarArchivoComponent } from "./cargar-archivo/cargar-archivo.component";


export const appRoutes: Routes = [
    { path:"user", component: UserComponent},
    { path:"user-edit", component: UserEditComponent},
    { path:"home", component: HomeComponent},
    { path:"cambio-password", component: CambioPasswordComponent},
    { path:"cargar-archivo", component: CargarArchivoComponent},
    { path:"**", redirectTo: "home", pathMatch: "full"},
];