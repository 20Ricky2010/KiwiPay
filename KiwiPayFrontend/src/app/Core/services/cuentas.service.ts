import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Cuenta } from '../models/cuenta.model';
import { API_BASE } from './api.config';
import { Observable } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class CuentasService {
  private base = `${API_BASE}/cuentas`;
  constructor(private http: HttpClient) {}
  crearCuenta(clienteId: number) { return this.http.post<Cuenta>(`${this.base}/${clienteId}`, {}); }
  listarPorCliente(clienteId: number): Observable<Cuenta[]> { return this.http.get<Cuenta[]>(`${this.base}/${clienteId}`); }
}
