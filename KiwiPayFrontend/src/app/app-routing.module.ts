import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ClientesListComponent } from './presentation/clientes/clientes-list.component';
import { ClienteFormComponent } from './presentation/clientes/cliente-form.component';
import { CuentasListComponent } from './presentation/cuentas/cuentas-list.component';
import { TransaccionFormComponent } from './presentation/transacciones/transaccion-form.component';

const routes: Routes = [
  { path: '', redirectTo: 'clientes', pathMatch: 'full' },
  { path: 'clientes', component: ClientesListComponent },
  { path: 'clientes/new', component: ClienteFormComponent },
  { path: 'clientes/edit/:id', component: ClienteFormComponent },
  { path: 'cuentas', component: CuentasListComponent },
  { path: 'transacciones', component: TransaccionFormComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
