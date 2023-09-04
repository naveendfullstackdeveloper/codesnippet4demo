import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { CouriersService } from './couriers.service';
import { Couriers } from './Couriers';
import { PriceResult } from './PriceResult';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

export class AppComponent implements OnInit {


  courier = new Couriers();

  customessge: string | undefined;
  // Dependency Injection
  constructor(http: HttpClient, private couriersService: CouriersService) { }

  ngOnInit(): void {
    // TODO document why this method 'ngOnInit' is empty
  }

  checkPrice() {
    this.couriersService.checkPrice(this.courier)
      .subscribe(data => {
        this.displayPrice(data);
      })
  }

  // eslint-disable-next-line @typescript-eslint/no-explicit-any
  displayPrice(status: PriceResult | undefined) {
    this.customessge = status?.customMessage;
  }

  title = 'PageUp Courier System';



}

