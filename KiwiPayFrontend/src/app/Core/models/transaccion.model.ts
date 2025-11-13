export interface Transaccion {
  transaccionId?: number;
  cuentaId: number;
  tipo: 'Deposito' | 'Retiro';
  monto: number;
  fecha?: string;
}
