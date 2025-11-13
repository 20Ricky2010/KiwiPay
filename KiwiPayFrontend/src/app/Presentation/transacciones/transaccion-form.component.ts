import { Component } from '@angular/core';
import { TransaccionesService } from '../../core/services/transacciones.service';
import { Router } from '@angular/router';
import { Transaccion } from '../../core/models/transaccion.model';

@Component({
  selector: 'app-transaccion-form',
  templateUrl: './transaccion-form.component.html'
})
export class TransaccionFormComponent {
  cuentaId?: number;
  tipo: 'Deposito'|'Retiro' = 'Deposito';
  monto: number = 0;
  error = '';
  success = '';

  constructor(private srv: TransaccionesService, private router: Router) {
    const st = history.state;
    if (st && st.cuentaId) this.cuentaId = st.cuentaId;
  }

  submit() {
    if (!this.cuentaId) { this.error = 'Seleccione cuenta'; return; }
    const trans: Transaccion = { cuentaId: this.cuentaId, tipo: this.tipo, monto: this.monto };
    console.log('Transacción a enviar:', trans);
    this.srv.realizar(trans).subscribe({
      next: res => { this.success = 'Transacción realizada'; this.error = ''; },
      error: err => {
        this.success = '';
        if (typeof err.error === 'string' && err.error) {
          this.error = err.error;
        } else if (err.error?.message) {
          this.error = err.error.message;
        } else if (err.error?.error) { // <-- aquí busca el campo 'error'
          this.error = err.error.error;
        } else if (err.status === 400) {
          this.error = 'Error de validación o saldo insuficiente';
        } else {
          this.error = 'Error desconocido';
        }
      }
    });
  }
}
