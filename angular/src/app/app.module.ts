import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { ProductListComponent } from './products/product-list/product-list.component';
import { ShoppingCartComponent } from './cart/shopping-cart/shopping-cart.component';
import { ProductService } from './shared/services/product.service';
import { CartService } from './shared/services/cart.service';
import { SharedService } from './shared/services/shared.service';

@NgModule({
  declarations: [
    AppComponent,
    ProductListComponent,
    ShoppingCartComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule
  ],
  providers: [
    ProductService,
    CartService,
    SharedService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
