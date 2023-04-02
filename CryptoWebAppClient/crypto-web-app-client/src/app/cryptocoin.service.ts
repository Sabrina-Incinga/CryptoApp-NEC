import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";

export interface convertResponse{
  status: {
    timestamp: string;
    errorCode: number;
    errorMessage: string | null;
  };
  data: {
    [key: string]: {
      price: number;
    };
  };
}

export interface cryptocoin{
  name: string;
  symbol: string,
  quote: quote
}

export interface quote{
  [key: string]: {
    price: number;
  };
}

@Injectable({
  providedIn: 'root'
})
export class CryptocoinService {

  constructor(private http: HttpClient) { }

  getCurrencies(symbols:string): Observable<cryptocoin[]>{
    return this.http.get<cryptocoin[]>(`http://localhost:57641/api/crypto?coinSymbols=${symbols}`);
  }

  getCurrenciesConvert(fromSymbol:string, toSymbols:string, amount:Number): Observable<convertResponse>{
    return this.http.get<convertResponse>(`http://localhost:57641/api/crypto/convert?fromSymbol=${fromSymbol}&toSymbol=${toSymbols}&amount=${amount}`);
  }
}
