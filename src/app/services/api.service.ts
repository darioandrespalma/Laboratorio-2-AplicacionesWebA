import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ApiService {
  private urlApi = 'http://localhost:5146/api'; 

  constructor(private http: HttpClient) { }

  // --- GESTIÓN DE TIPOS ---
  getTipos(): Observable<any[]> {
    return this.http.get<any[]>(`${this.urlApi}/TipoProductos`);
  }

  saveTipo(tipo: any): Observable<any> {
    return this.http.post(`${this.urlApi}/TipoProductos`, tipo);
  }

  deleteTipo(id: number): Observable<any> {
    return this.http.delete(`${this.urlApi}/TipoProductos/${id}`);
  }

  // --- GESTIÓN DE PRODUCTOS ---
  getProductos(): Observable<any[]> {
    return this.http.get<any[]>(`${this.urlApi}/Productos`);
  }

  saveProducto(producto: any): Observable<any> {
    return this.http.post(`${this.urlApi}/Productos`, producto);
  }

  deleteProducto(id: number): Observable<any> {
    return this.http.delete(`${this.urlApi}/Productos/${id}`);
  }
}