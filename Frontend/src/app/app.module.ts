import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { RegistrationComponent } from './components/registration/registration.component';
import { LoginComponent } from './components/login/login.component';
import { AppRoutingModule } from './app-routing.module';
import { HomeComponent } from './components/home/home.component';
import { AuthGuard } from './auth/auth.guard';
import { TestCategoriesComponent } from './components/test-categories/test-categories.component';
import { TestCategoryDetailsComponent } from './components/test-category-details/test-category-details.component';
import { TestDetailsComponent } from './components/test-details/test-details.component';
import { QuestionComponent } from './components/question/question.component';
import { ExtendedStatComponent } from './components/extended-stat/extended-stat.component';
import { AdminComponent } from './components/admin/admin.component';
import { TestEditorComponent } from './components/test-editor/test-editor.component';

@NgModule({
  declarations: [
    AppComponent,
    RegistrationComponent,
    LoginComponent,
    HomeComponent,
    TestCategoriesComponent,
    TestCategoryDetailsComponent,
    TestDetailsComponent,
    QuestionComponent,
    ExtendedStatComponent,
    AdminComponent,
    TestEditorComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [AuthGuard],
  bootstrap: [AppComponent]
})
export class AppModule { }
