import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LayoutComponentComponent } from './app/layout-component/layout-component.component';
import { UserComponentComponent } from './app/user-component/user-component.component';



const routes: Routes = [
{
  path: '',
  component: LayoutComponentComponent,
  children: [
  {
    path: '',
    redirectTo: 'Users',
    pathMatch: 'full'
  },
    { path: 'Users', component: UserComponentComponent},
  ]
},

  {
    path: '**',
    redirectTo: '',
    pathMatch: 'full'
  }
];

export const APP_ROUTES = RouterModule.forRoot(routes, { useHash: true });

