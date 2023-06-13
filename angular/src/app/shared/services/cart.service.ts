import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

import { CartItem } from '../models/cart-item.model';
import { API_CONFIG } from '../../../config';

@Injectable({ providedIn: 'root' })
export class CartService {
  constructor(private http: HttpClient) { }

  getCartItems(): Observable<CartItem[]> {
    return this.http.get<CartItem[]>(`${API_CONFIG.baseUrl}${API_CONFIG.cartUrl}`);
  }

  addProductToCart(productId: number): Observable<CartItem> {
    return this.http.post<CartItem>(`${API_CONFIG.baseUrl}${API_CONFIG.cartUrl}?productId=${productId}`, {});
  }

  removeProductFromCart(productId: number): Observable<any> {
    return this.http.delete(`${API_CONFIG.baseUrl}${API_CONFIG.cartUrl}/${productId}`);
  }

  totalPriceCheckout() : Observable<number> {
    return this.http.get<number>(`${API_CONFIG.baseUrl}${API_CONFIG.checkoutUrl}`);
  }
}
