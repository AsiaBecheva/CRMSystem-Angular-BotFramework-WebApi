import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { UsersModule } from './components/users/users.module';
import { CrmRouteModule } from './components/routes.module';
import { HomeModule } from './components/home/home.module';
import { CustomerModule } from './components/customers/customer.module';
import { ProductModule } from './components/products/product.module';

@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent
    ],
    imports: [
        CommonModule,
        ProductModule,
        HomeModule,
        HttpModule,
        UsersModule,
        CustomerModule,
        CrmRouteModule,
        FormsModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: '**', redirectTo: 'home' }
        ])
    ]
})
export class AppModuleShared {
}
