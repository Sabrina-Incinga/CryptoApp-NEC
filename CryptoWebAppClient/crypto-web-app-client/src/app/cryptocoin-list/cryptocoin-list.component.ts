import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { CryptocoinService, cryptocoin, quote } from '../cryptocoin.service';
import { currencies } from '../currencies';

@Component({
  selector: 'app-cryptocoin-list',
  templateUrl: './cryptocoin-list.component.html',
  styleUrls: ['./cryptocoin-list.component.css']
})
export class CryptocoinListComponent implements OnInit{
  cryptocoinList : cryptocoin[] = [];
  currencies = currencies;
  currencyChangeform: FormGroup;
  currencyConvertData: quote = {"": {
    price: 0,
  }};

  constructor(public cryptocoinService: CryptocoinService, private formBuilder: FormBuilder){
    this.currencyChangeform = this.formBuilder.group({
      fromSymbol: ['BTC', Validators.required],
      amount: [1, [Validators.required, Validators.min(0.01)]]
    });
  };

  ngOnInit(): void {
    this.getCryptocoins();
    
  }

  Object = Object;

  private getCryptocoins() {
    this.cryptocoinService.getCurrencies('BTC,ETH,BNB,USDT,ADA').subscribe(
      (data) => {
        this.cryptocoinList = data;
        setInterval(() => {
          this.cryptocoinService.getCurrencies('BTC,ETH,BNB,USDT,ADA').subscribe(
            (data) => {
              this.cryptocoinList = data;
            },
            (error) => console.log(error)
          );
        }, 5000);
      },
      (error) => console.log(error)
    );
  }

  onSubmit() {
    if (this.currencyChangeform.valid) {
      const fromSymbol = this.currencyChangeform?.get('fromSymbol')?.value;
      const amount = this.currencyChangeform?.get('amount')?.value;
      const toSymbols = currencies.filter(curr => curr.symbol != fromSymbol).map(curr => curr.symbol).join(',');
      
      this.cryptocoinService.getCurrenciesConvert(fromSymbol, toSymbols, amount).subscribe(result => {
        this.currencyConvertData = result.data;
        
      });
    }

    this.currencyChangeform.get('fromSymbol')?.disable();
    this.currencyChangeform.get('amount')?.disable();
  }

  resetForm() {
    this.getCryptocoins();
    this.currencyConvertData = {"": {
      price: 0,
    }};
    this.currencyChangeform.reset();
    this.currencyChangeform.get('fromSymbol')?.enable();
    this.currencyChangeform.get('amount')?.enable();
  }
}
