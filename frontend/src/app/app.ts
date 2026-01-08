import { Component } from '@angular/core';
// Borramos RouterOutlet para quitar la advertencia amarilla
import { GestionComponent } from './components/gestion/gestion.component';

@Component({
  selector: 'app-root',
  standalone: true,
  // Solo importamos el componente de gestión
  imports: [GestionComponent], 
  templateUrl: './app.html',
  styleUrl: './app.css'
})
// CAMBIO IMPORTANTE: La clase debe llamarse "App", no "AppComponent"
export class App {
  title = 'TiendaFrontend';
}