import { Component, OnInit } from '@angular/core';
import { Product } from '../../shared/models/product.model';
import { ProductService } from '../../shared/services/product.service';
import { CartService } from '../../shared/services/cart.service';
import { SharedService } from 'src/app/shared/services/shared.service';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit {
  products: Product[];

  constructor(private productService: ProductService,
    private cartService: CartService,
    private sharedService: SharedService) { }

  ngOnInit(): void {
    this.productService.getProducts().subscribe(products => {
      this.products = products;
    });
  }

  onAddProductToCart(productId: number): void {
    this.cartService.addProductToCart(productId).subscribe(() => {
      this.sharedService.triggerCartUpdate();
    }, error => {
      alert('Failed to add product to cart!');
    });
  }

  onRemoveProductFromCart(productId: number) {
    this.cartService.removeProductFromCart(productId).subscribe(() => {
      this.sharedService.triggerCartUpdate();
    });
  }
}
