import { AuthConfig } from 'angular-oauth2-oidc';

export const authConfig: AuthConfig = {
    // Url of the Identity Provider
    issuer: 'https://localhost:44387',

    // URL of the Client to redirect the user to after login
    redirectUri: 'http://localhost:4200/home',

    // The Client's id. The Client is registered with this id at the auth-server
    clientId: 'interactive1',

    //dummyClientSecret: 'SuperSecretPassword',

    // set the scope for the permissions the client should request
    // The first two are defined by OIDC. The 3th is a usecase-specific one
    scope: 'openid profile restAPI.read',

    responseType: 'id_token token',
    showDebugInformation: true,
}