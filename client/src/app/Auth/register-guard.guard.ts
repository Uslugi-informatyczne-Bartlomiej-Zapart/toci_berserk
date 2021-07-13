import { GuardService } from './guard.service';
import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class RegisterGuardGuard implements CanActivate {
  constructor(private _router: Router, private guardService: GuardService) {}

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
    let name = localStorage.getItem('user');

    if(name == '') {
      return true;
    }
    this._router.navigate(['/login']);
    return false;
  }

}
