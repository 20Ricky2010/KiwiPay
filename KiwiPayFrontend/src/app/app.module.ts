import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';

import { ClientesListComponent } from './presentation/clientes/clientes-list.component';
import { ClienteFormComponent } from './presentation/clientes/cliente-form.component';
import { CuentasListComponent } from './presentation/cuentas/cuentas-list.component';
import { TransaccionFormComponent } from './presentation/transacciones/transaccion-form.component';

@NgModule({
  declarations: [
    AppComponent,
    ClientesListComponent,
    ClienteFormComponent,
    CuentasListComponent,
    TransaccionFormComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
