import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SharedService {
  cartUpdated = new Subject<void>();

  triggerCartUpdate(): void {
    this.cartUpdated.next();
  }
}
