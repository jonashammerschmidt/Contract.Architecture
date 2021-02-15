import { IEnvironment } from './environment.interface';

// tslint:disable: no-string-literal
export const environment: IEnvironment = {
  production: true,
  apiEndpoint: window['env']['apiEndpoint']
};
