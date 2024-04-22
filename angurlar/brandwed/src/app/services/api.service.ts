import { HttpClient, HttpEvent, HttpRequest } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class ApiService {
  public url = "https://localhost:7138/api/Products"
  public inventory = "https://localhost:7138/api/OrderDetails"
  public sale = "https://localhost:7138/api/onSale"
  public cart = "https://localhost:7138/api/Orders"
  public Userlogin = "https://localhost:7138/api/UserLogin"


  constructor(
    private httpClient: HttpClient
  ) { }

  createUser(obj:any){
    return this.httpClient.post<any>(this.Userlogin+"/Signup",obj);
  }
  logUser(obj:any){
    return this.httpClient.post<any>(this.Userlogin+"/Login",obj);
  }
  getProducts() {
    return this.httpClient.get(this.url)
  }
  getcarts() {
    return this.httpClient.get(this.cart)
  }
  getOnSale() {
    return this.httpClient.get(this.sale)
  }
  createProducts(obj:any) {
      return this.httpClient.post<any>(this.url,obj);
    }
  Cart(obj:any) {
    return this.httpClient.post<any>(this.cart+"/Insert",obj);
  }
    // ProductImage(obj:any) {
    //   return this.httpClient.post<any>(this.url,obj);
    // }
  getProductById(id:any){
    return this.httpClient.get<any>(`${this.url}/${id}`);
  }
  // getProductImageById(id:any){
  //   return this.httpClient.get<any>(`${this.image}/${id}`);
  // }
  updateProductById(body:any,id:any) {
    return this.httpClient.put<any>(`${this.url}/${id}`,body);
  }
  deleteProductById(id:any){
    return this.httpClient.delete<any>(`${this.url}/${id}`);
  }
  deleteCartById(id:any){
    return this.httpClient.delete<any>(`${this.cart}/${id}`);
  }
  upload(file: File): Observable<HttpEvent<any>> {
    const formData: FormData = new FormData();

    formData.append('file', file);
    const req = new HttpRequest('POST', `${this.url}`, formData, {
      responseType: 'json'
    });

    return this.httpClient.request(req);
  }
  getImage(fileName: string): Observable<any> {
    // Assuming the fileName is the unique identifier for the image
    return this.httpClient.get(`${this.url}/${fileName}`);
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
