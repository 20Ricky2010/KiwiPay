import { Component } from '@angular/core';
import { ClientesService } from '../../core/services/clientes.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Cliente } from '../../core/models/cliente.model';

@Component({
  selector: 'app-cliente-form',
  templateUrl: './cliente-form.component.html'
})
export class ClienteFormComponent {
  cliente: Cliente = { nombre: '', apellido: '', dni: '' };
  editingId?: number;
  error = '';

  constructor(
    public service: ClientesService,
    public route: ActivatedRoute,
    public router: Router
  ) {
    const id = this.route.snapshot.paramMap.get('id');
    if (id) {
      this.editingId = +id;
      this.service.listar().subscribe(list => {
        const found = list.find(x => x.clienteId === this.editingId);
        if (found) this.cliente = found;
      });
    }
  }

  save() {
    if (this.editingId) {
      this.service.actualizar(this.editingId, this.cliente).subscribe({
        next: () => this.router.navigate(['/clientes']),
        error: e => this.error = e.message || 'Error'
      });
    } else {
      this.service.crear(this.cliente).subscribe({
        next: () => this.router.navigate(['/clientes']),
        error: e => this.error = e.message || 'Error'
      });
    }
  }
}
