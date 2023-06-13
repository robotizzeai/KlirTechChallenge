import { Component, OnInit } from '@angular/core';

import { CartItem } from '../../shared/models/cart-item.model';
import { CartService } from '../../shared/services/cart.service';
import { SharedService } from 'src/app/shared/services/shared.service';

@Component({
  selector: 'app-cart',
  templateUrl: './shopping-cart.component.html',
  styleUrls: ['./shopping-cart.component.css']
})
export class ShoppingCartComponent implements OnInit {
  cartItems: CartItem[] = [];
  totalPrice: number = 0;
  totalDiscount: number = 0;
  constructor(private cartService: CartService,
    private sharedService: SharedService) { }

  ngOnInit(): void {
    this.cartService.getCartItems().subscribe(items => {
      this.cartItems = items;
      this.updateTotalPrice();
    });
    this.sharedService.cartUpdated.subscribe(() => this.updateTotalPrice());
  }

  updateTotalPrice(): void {
    let sumOriginalPrices = 0;

    for (let item of this.cartItems) {
      sumOriginalPrices += item.productPrice * item.quantity;
    }
    this.cartService.totalPriceCheckout().subscribe((total) => {
      this.totalPrice = total;
      this.totalDiscount = sumOriginalPrices - total;
    });
  }
}
