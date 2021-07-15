import { Component, OnInit } from '@angular/core';
import {MatMenuTrigger} from '@angular/material/menu'

@Component({
  selector: 'app-sidenav',
  templateUrl: './sidenav.component.html',
  styleUrls: ['./sidenav.component.scss']
})
export class SidenavComponent implements OnInit {
  countries: any[] = [
    {value: 1, name: 'America'},
    {value: 2, name: 'India'},
  ];
  foods: any[] = [
    {value: 1, name: 'Pizza', state: 'California'},
    {value: 2, name: 'Burger', state: 'California'},
    {value: 3, name: 'McDonald', state: 'Missisippi'},
    {value: 4, name: 'Daal Baafle', state: 'Rajasthan'},
    {value: 5, name: 'Rice & Fish', state: 'Odisha'},
    {value: 6, name: 'Chicken Curry', state: 'Odisha'},
  ];


   states: any[] = [
    {value: 1, name: 'New York', countryId: 'America'},
    {value: 2, name: 'California', countryId: 'America'},
    {value: 3, name: 'Missisippi', countryId: 'America'},
    {value: 4, name: 'Nevada', countryId: 'America'},
    {value: 5, name: 'Maharashtra', countryId: 'India'},
    {value: 6, name: 'Odisha', countryId: 'India'},
    {value: 7, name: 'Rajasthan', countryId: 'India'},
    {value: 8, name: 'Madhya Pradesh', countryId: 'India'},

  ];

  openMyMenu() {
    this.trigger.toggleMenu();
  }
  closeMyMenu() {
    this.trigger.closeMenu();
    console.log('close')
  }
  constructor() { }

  ngOnInit(): void {
  }

}
