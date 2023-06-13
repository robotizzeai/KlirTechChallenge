import { Component, OnInit } from '@angular/core';
import { CartService } from '../../shared/services/cart.service';
import { SharedService } from 'src/app/shared/services/shared.service';

@Component({
  selector: 'app-added-products',
  templateUrl: './added-products.component.html',
  styleUrls: ['./added-products.component.css']
})
export class AddedProductsComponent implements OnInit {
  cartItems = [];

  constructor(private cartService: CartService,
    private sharedService: SharedService) { }

  ngOnInit() {
    this.sharedService.cartUpdated.subscribe(() => this.updateTotal());
  }
  updateTotal(): void {
    this.cartService.getCartItems().subscribe(items => {
      this.cartItems = items;
    });
  }
}
