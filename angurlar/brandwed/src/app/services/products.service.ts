import { Injectable } from '@angular/core';
import { ApiService } from './api.service';

import { Observable } from 'rxjs';
import { Products } from '../../types';

@Injectable({
  providedIn: 'root'
})
export class ProductsService {

  constructor(private apiService: ApiService,
      ) { }


/*  getProducts =
   (
    url: string,
    ):Observable<Products> =>
    {
      return this.apiService.get(url,
      {

        responseType:'json',
      });
    };
  addingProducts=
    (
      url:string,
      body:any
    ):Observable<any>=>
  {
    return this.apiService.post(url,body,{});

  };*/
/*   edProducts=
    (
      url: string,
      body: any
      ):Observable<any>=> {return this.apiService.put(url,body,{});
    }; */

  /*   deleteProducts=(url:string):Observable<any>=>{
      return this.apiService.delete(url,{});
    } */
}
