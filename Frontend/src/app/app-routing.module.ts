import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';

import { RegistrationComponent } from './components/registration/registration.component';
import { LoginComponent } from './components/login/login.component';
import { TestCategoriesComponent } from './components/test-categories/test-categories.component';
import { HomeComponent } from './components/home/home.component';
import { AuthGuard } from './auth/auth.guard';
import { TestCategoryDetailsComponent } from './components/test-category-details/test-category-details.component';
import { TestDetailsComponent } from './components/test-details/test-details.component';
import { QuestionComponent } from './components/question/question.component';
import { ExtendedStatComponent } from './components/extended-stat/extended-stat.component';
import { AdminComponent } from './components/admin/admin.component';
import { TestEditorComponent } from './components/test-editor/test-editor.component';

const routes: Routes = [
  { path: 'sign-up', component: RegistrationComponent },
  { path: 'login', component: LoginComponent },
  { path: 'home', component: HomeComponent, canActivate: [AuthGuard] },
  { path: 'edit', component: TestEditorComponent, canActivate: [AuthGuard] },
  { path: 'admin', component: AdminComponent, canActivate: [AuthGuard] },
  { path: 'home/extended/:statId/:testId', component: ExtendedStatComponent, canActivate: [AuthGuard] },
  { path: 'testCategories', component: TestCategoriesComponent, canActivate: [AuthGuard] },
  { path: 'testCategoryDetails/:id', component: TestCategoryDetailsComponent, canActivate: [AuthGuard] },
  { path: 'testDetails/:id', component: TestDetailsComponent, canActivate: [AuthGuard] },
  { path: 'test/:id/question/:id', component: QuestionComponent, canActivate: [AuthGuard] },
  { path: '', redirectTo: 'testCategories', pathMatch: 'full' },
];

@NgModule({
  exports: [ RouterModule ],
  imports: [ RouterModule.forRoot(routes) ],
})
export class AppRoutingModule { }
