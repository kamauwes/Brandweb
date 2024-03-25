import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';


@Injectable({
  providedIn: 'root'
})
export class ApiService {
  public url = "https://localhost:7138/api/Products"
  public inventory = "https://localhost:7138/api/OrderDetails"


  constructor(
    private httpClient: HttpClient
  ) { }
  getInventory(){
    return this.httpClient.get(this.inventory+'')
  }
  getProducts() {
    return this.httpClient.get(this.url+'/products')
  }
  createProducts(obj:any) {
      return this.httpClient.post<any>(this.url+'/Insert',obj);
    }
  getProductById(id:any){
    return this.httpClient.get<any>(`${this.url}/${id}`);
  }
  updateProductById(body:any,id:any) {
    return this.httpClient.put<any>(`${this.url}/${id}`,body);
  }
  deleteProductById(id:any){
    return this.httpClient.delete<any>(`${this.url}/${id}`);
  }

    //ANOTHER WAY TO CONNECT TO THE BACKEND

 /* get<T>(url:string , options:Options):Observable<T>{
    return this.httpClient.get<T>(url,options) as Observable<T>;
  }
  post<T>(url:string,body:Product , options:Options):Observable<T>{
    return this.httpClient.post<T>(url,body,options) as Observable<T>;
  }*/
/*   put<T>(url:string ,body:Product, options:Options):Observable<T>{
    return this.httpClient.put<T>(url,body,options) as Observable<T>;
  }
  delete<T>(url:string , options:Options):Observable<T>{
    return this.httpClient.delete<T>(url,options) as Observable<T>;
  } */
}
