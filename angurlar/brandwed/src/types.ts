import { HttpContext, HttpHeaders, HttpParams } from "@angular/common/http";

export interface Options{
  headers?: HttpHeaders | {
      [header: string]: string | string[];
  };
  observe?: 'body';
  context?: HttpContext;
  params?: HttpParams | {
      [param: string]: string | number | boolean | ReadonlyArray<string | number | boolean>;
  };
  reportProgress?: boolean;
  responseType?: 'json';
  withCredentials?: boolean;
  transferCache?: {
      includeHeaders?: string[];
  } | boolean;
}
export interface Products{

    items: Product;
    total: number;
  
}
export interface Product{
  product_id?:number;
  product_Name:string;
  productprice: string;
  product_Description:string;
  product_Category:string;
  product_Quantity:string;   
  image:string; 

}


