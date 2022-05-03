import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-overview',
  templateUrl: './overview.component.html',
  styleUrls: ['./overview.component.scss']
})
export class OverviewComponent implements OnInit {

  data: string = "Sample Text";
  title: string = "My Title";
  price: number = 0;
  isActive: boolean = false;
  items: string[] = ["Item1", "Item2", "Item3", "Item4"];
  myColor: string = "red";
  bgColor: string = "green";
  
  constructor() { }

  ngOnInit(): void {
  }

  changeData(): void {
    this.data = 'new data';
  }

  changePrice() {
    this.price++;
  }

  resetPrice() {
    this.price = 0;
  }

  setTitle(title: string) {
    this.title = title;
  }
}
