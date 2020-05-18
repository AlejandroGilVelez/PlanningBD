import { BrowserModule } from "@angular/platform-browser";
import { NgModule } from "@angular/core";
import { HttpClientModule, HTTP_INTERCEPTORS } from "@angular/common/http";
import { RouterModule } from "@angular/router";
import { FormsModule } from "@angular/forms";
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import { NgxSpinnerModule } from "ngx-spinner";

import { InputTextModule } from "primeng/inputtext";
import { ToastModule } from "primeng/toast";
import { MessageService } from "primeng/api";
import { ButtonModule } from "primeng/button";
import { InputSwitchModule } from "primeng/inputswitch";
import {BlockUIModule} from 'primeng/blockui';

import { AppComponent } from "./app.component";
import { UserComponent } from "./user/user.component";
import { UserEditComponent } from "./user/user-edit/user-edit.component";
import { appRoutes } from "./routes";
import { HomeComponent } from "./home/home.component";
import { NavComponent } from "./nav/nav.component";
import { CambioPasswordComponent } from "./cambio-password/cambio-password.component";
import { AuthInterceptorService } from "./shared/interceptors/auth-interceptor.service";
import { CargarArchivoComponent } from './cargar-archivo/cargar-archivo.component';

@NgModule({
  declarations: [
    AppComponent,
    UserComponent,
    UserEditComponent,
    HomeComponent,
    NavComponent,
    CambioPasswordComponent,
    CargarArchivoComponent,
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    BrowserAnimationsModule,
    ToastModule,
    ButtonModule,
    InputSwitchModule,
    BlockUIModule,
    NgxSpinnerModule,    
    InputTextModule,
    RouterModule.forRoot(appRoutes),
  ],
  providers: [
    MessageService,
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthInterceptorService,
      multi: true,
    },
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
