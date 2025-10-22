import { Component, inject } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Weatherforecast } from './weatherforecast';


@Component({
  selector: 'app-root',
  imports: [],
  templateUrl: './app.html',
  styleUrl: './app.scss'
})
export class App {
 Weatherforecast = inject(Weatherforecast);

 Empleados: any[] = [];

 constructor(){
  this.Weatherforecast.obtenerEmpleado().subscribe(datos =>{

    this.Empleados = datos;

  });
 }
}
