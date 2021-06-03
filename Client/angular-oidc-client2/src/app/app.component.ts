import { Component } from '@angular/core';
import { OAuthService } from 'angular-oauth2-oidc';
import { JwksValidationHandler } from 'angular-oauth2-oidc-jwks';
import { authConfig } from './sso.config';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'angular-oidc-client2';

  constructor(private oauthService: OAuthService) {
    this.configureSingleSignOn();
  }
  configureSingleSignOn() {
    this.oauthService.configure(authConfig);
    this.oauthService.tokenValidationHandler = new JwksValidationHandler();
    this.oauthService.loadDiscoveryDocumentAndTryLogin();
  }
  login() {
    this.oauthService.initImplicitFlow();
  }
  logout() {
    this.oauthService.logOut();
  }
  get token() {
    let claims: any = this.oauthService.getIdentityClaims();
    return claims ? claims : null;
  }
}
