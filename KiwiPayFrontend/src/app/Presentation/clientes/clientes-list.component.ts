import { Component, OnInit } from '@angular/core';
import { ClientesService } from '../../core/services/clientes.service';
import { Cliente } from '../../core/models/cliente.model';
import { Router } from '@angular/router';

@Component({
  selector: 'app-clientes-list',
  templateUrl: './clientes-list.component.html'
})
export class ClientesListComponent implements OnInit {
  clientes: Cliente[] = [];
  error = '';

  constructor(private service: ClientesService, private router: Router) {}

  ngOnInit() { this.refresh(); }

  refresh() {  this.service.listar().subscribe({
    next: data => {
      console.log('Clientes recibidos:', data, Array.isArray(data));
      this.clientes = Array.isArray(data) ? data : [];
    },
    error: err => this.error = err.message || err.statusText
  });
  }

  borrar(id: number | undefined) {
    if (!id) return;
    if (!confirm('Eliminar cliente?')) return;
    this.service.eliminar(id).subscribe({ next: () => this.refresh() });
  }

  editar(id?: number) { if (id) this.router.navigate(['/clientes/edit', id]); }
  crear() { this.router.navigate(['/clientes/new']); }
}
