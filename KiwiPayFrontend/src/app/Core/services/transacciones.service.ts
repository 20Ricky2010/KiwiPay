import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Transaccion } from '../models/transaccion.model';
import { API_BASE } from './api.config';
import { Observable } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class TransaccionesService {
  private url = `${API_BASE}/transacciones`;
  constructor(private http: HttpClient) {}
  realizar(trans: Transaccion): Observable<Transaccion> {
    const tipoMap: any = { 'Deposito': 1, 'Retiro': 2 };
    const dto = {
      CuentaId: trans.cuentaId,
      Tipo: tipoMap[trans.tipo],
      Monto: trans.monto
    };
    console.log('CuentaId enviado:', trans.cuentaId);
    return this.http.post<Transaccion>(this.url, dto );
  }
}
