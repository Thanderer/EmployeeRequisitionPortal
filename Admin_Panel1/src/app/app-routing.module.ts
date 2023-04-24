import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RequsitionFormComponent } from './requsition-form/requsition-form.component';
import { RegisterdFormComponent } from './registerd-form/registerd-form.component';
import { RequistionRequestsComponent } from './requistion-requests/requistion-requests.component';
import { BudgetAllocatorComponent } from './budget-allocator/budget-allocator.component';
import { AcquisitionTeamComponent } from './acquisition-team/acquisition-team.component';
import { HomeComponent } from './home/home.component';
import { ViewComponent } from './view/view.component';



const routes: Routes = [
  {
    path: 'requistionform',
    component: RequsitionFormComponent
  },
  {
    path: 'details/:id',
    component: RegisterdFormComponent
  },
  {
    path: 'requests',
    component: RequistionRequestsComponent
  },
  {
    path: 'budget',
    component: BudgetAllocatorComponent
  },
  {
    path: 'acquistion',
    component: AcquisitionTeamComponent
  },
  {
    path: '',
    component: HomeComponent
  },
  {
    path:'home',
    component: HomeComponent
  },
  {
    path: 'view/:id',
    component: ViewComponent
  }

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})

export class AppRoutingModule { }
