// This file can be replaced during build by using the `fileReplacements` array.
// `ng build --prod` replaces `environment.ts` with `environment.prod.ts`.
// The list of file replacements can be found in `angular.json`.

import { IEnvironment } from './environment.interface';

// tslint:disable: no-string-literal
export const environment: IEnvironment = {
  production: false,
  apiEndpoint: window['env']['apiEndpoint'],
};
