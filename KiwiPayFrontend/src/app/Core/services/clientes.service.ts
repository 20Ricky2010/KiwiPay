import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Cliente } from '../models/cliente.model';
import { API_BASE } from './api.config';
import { Observable } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class ClientesService {
  private url = `${API_BASE}/clientes`;
  constructor(private http: HttpClient) {}
  listar(): Observable<Cliente[]> { return this.http.get<Cliente[]>(this.url); }
  crear(cliente: Cliente) { return this.http.post<Cliente>(this.url, cliente); }
  actualizar(id: number, cliente: Cliente) { return this.http.put(`${this.url}/${id}`, cliente); }
  eliminar(id: number) { return this.http.delete(`${this.url}/${id}`); }
}
