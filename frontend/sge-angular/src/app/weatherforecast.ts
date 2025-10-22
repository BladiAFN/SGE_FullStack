import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { environment } from '../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class Weatherforecast {
  constructor(){

  }
  private http = inject(HttpClient);
  private URLbase = environment.apiUrl + '/api/Empleados';

  public obtenerEmpleado(){
    return this.http.get<any>(this.URLbase);
  }

}
