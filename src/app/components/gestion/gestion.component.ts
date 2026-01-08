import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ApiService } from '../../services/api.service';

@Component({
  selector: 'app-gestion',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './gestion.component.html',
  styleUrl: './gestion.component.css'
})
export class GestionComponent implements OnInit {

  // Listas de datos
  listaProductos: any[] = [];
  listaTipos: any[] = [];

  // Objetos para los formularios
  nuevoProducto = {
    idTipo: 0,
    descripcion: '',
    valor: 0,
    costo: 0
  };

  nuevoTipo = {
    tipo: ''
  };

  constructor(private api: ApiService) {}

  ngOnInit(): void {
    this.cargarDatos();
  }

  cargarDatos() {
    this.api.getTipos().subscribe(data => this.listaTipos = data);
    this.api.getProductos().subscribe(data => this.listaProductos = data);
  }

  // --- LÓGICA DE TIPOS ---
  guardarTipo() {
    if (!this.nuevoTipo.tipo) {
      alert("Escribe un nombre para el tipo");
      return;
    }
    this.api.saveTipo(this.nuevoTipo).subscribe(() => {
      alert("Tipo Agregado");
      this.cargarDatos(); // Recargar listas
      this.nuevoTipo.tipo = ''; // Limpiar campo
    });
  }

  eliminarTipo(id: number) {
    if(confirm("¿Borrar este tipo? (Esto podría fallar si hay productos usándolo)")) {
      this.api.deleteTipo(id).subscribe({
        next: () => this.cargarDatos(),
        error: (e) => alert("No se puede borrar: Probablemente hay productos de este tipo.")
      });
    }
  }

  // --- LÓGICA DE PRODUCTOS ---
  guardarProducto() {
    if (this.nuevoProducto.idTipo == 0) {
      alert("Selecciona un Tipo de Producto");
      return;
    }
    this.nuevoProducto.idTipo = Number(this.nuevoProducto.idTipo);

    this.api.saveProducto(this.nuevoProducto).subscribe(() => {
      alert("Producto Guardado");
      this.cargarDatos();
      this.nuevoProducto = { idTipo: 0, descripcion: '', valor: 0, costo: 0 };
    });
  }

  eliminarProducto(id: number) {
    if(confirm("¿Eliminar producto?")) {
      this.api.deleteProducto(id).subscribe(() => this.cargarDatos());
    }
  }
}