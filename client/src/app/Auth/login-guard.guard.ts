import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export default class LoginGuardGuard implements CanActivate {
  constructor(private _router: Router) { }

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
    let auth = localStorage.getItem('authenticated');
    let name = localStorage.getItem('user');
    if (name == '') {
      this._router.navigate(['/register']);
      return false;
    }

    if(!auth || auth === 'false') {
      return true;
    }
    this._router.navigate(['/register']);
    return false;
  }
}
