import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ConnectionService {
  serviceRest:string='http://localhost:5029/api/';

  constructor(
    private _HttpClient:HttpClient
  ) { }

  FN_Get(Controller:string, Request:string){
    const headers = {
      // 'Authorization': this._CollectionService.getToken()
    };
    
    let promise = new Promise((resolve, reject) =>{
      this._HttpClient.get(this.serviceRest + Controller + Request, {'headers':headers}).toPromise().then(res =>{
        resolve(res);
      },error =>{
        reject(error);
      });
    });
    return promise;
  }
  FN_Post(Controller:string, Request:any){
    const headers = {
      //'Authorization': this._CollectionService.getToken()
    };
    
    let promise = new Promise((resolve, reject) =>{
      this._HttpClient.post(this.serviceRest + Controller, Request).toPromise().then(res =>{
        resolve(res);
      },error =>{
        reject(error);
      });
    });
    return promise;
  }

  FN_Put(Controller:string, Request:any){
    const headers = {
      //'Authorization': this._CollectionService.getToken()
    };

    let promise = new Promise((resolve, reject) =>{
      this._HttpClient.put(this.serviceRest + Controller, Request, {'headers':headers}).toPromise().then(res =>{
        resolve(res);
      },error =>{
        reject(error);
      });
    });
    return promise;
  }
}
