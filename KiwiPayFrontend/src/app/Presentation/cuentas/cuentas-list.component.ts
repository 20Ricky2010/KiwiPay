import { Component, OnInit } from '@angular/core';
import { CuentasService } from '../../core/services/cuentas.service';
import { ClientesService } from '../../core/services/clientes.service';
import { Cuenta } from '../../core/models/cuenta.model';
import { Cliente } from '../../core/models/cliente.model';
import { Router } from '@angular/router';

@Component({
  selector: 'app-cuentas-list',
  templateUrl: './cuentas-list.component.html'
})
export class CuentasListComponent implements OnInit {
  clientes: Cliente[] = [];
  cuentas: Cuenta[] = [];
  selectedClienteId?: number;

  constructor(
    private clientesSrv: ClientesService,
    private cuentasSrv: CuentasService,
    private router: Router
  ) {}

  ngOnInit() { this.refreshClientes(); }

  refreshClientes() {
    this.clientesSrv.listar().subscribe(data => this.clientes = data);
  }

  cargarCuentas() {
    if (!this.selectedClienteId) return;
    this.cuentasSrv.listarPorCliente(this.selectedClienteId).subscribe(c => this.cuentas = c);
  }

  crearCuenta() {
    if (!this.selectedClienteId) return alert('Seleccione cliente');
    this.cuentasSrv.crearCuenta(this.selectedClienteId).subscribe(() => this.cargarCuentas());
  }

  abrirTransaccion(cuentaId?: number) {
    if (!cuentaId) return;
    this.router.navigate(['/transacciones'], { state: { cuentaId } });
  }
}
