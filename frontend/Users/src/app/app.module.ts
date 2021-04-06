import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { LayoutComponentComponent } from './layout-component/layout-component.component';
import { UserComponentComponent } from './user-component/user-component.component';
import { APP_ROUTES } from 'src/app-routing.module';
import { ReactiveFormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule } from '@angular/common/http';
import { UserServiceService } from './services/user-service.service';
import { IConfig, NgxMaskModule } from 'ngx-mask';
import { NgSelectModule } from '@ng-select/ng-select';
import { ToastrModule } from 'ngx-toastr';
import { MyDatePickerModule } from 'mydatepicker';

export let options: Partial<IConfig> | (() => Partial<IConfig>) = null;

@NgModule({
  declarations: [
    AppComponent,
    LayoutComponentComponent,
    UserComponentComponent
  ],
  imports: [
    APP_ROUTES,
    BrowserModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    HttpClientModule,
    NgxMaskModule.forRoot(options),
    NgSelectModule,
    ToastrModule.forRoot(),
    MyDatePickerModule
  ],
  providers: [UserServiceService],
  bootstrap: [AppComponent]
})
export class AppModule { }
