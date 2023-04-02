import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';
import { HttpClientModule } from "@angular/common/http";
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { TopBarComponent } from './top-bar/top-bar.component';
import { CryptocoinListComponent } from './cryptocoin-list/cryptocoin-list.component';
import { CryptocoinService } from './cryptocoin.service';
import { BottomFooterComponent } from './bottom-footer/bottom-footer.component';

@NgModule({
  declarations: [
    AppComponent,
    TopBarComponent,
    CryptocoinListComponent,
    BottomFooterComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    RouterModule.forRoot([
      { path: '', component: CryptocoinListComponent },
    ]),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [CryptocoinService],
  bootstrap: [AppComponent]
})
export class AppModule { }
