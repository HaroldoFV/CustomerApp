import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";
import { CustomerListComponent } from "./customer-list/customer-list.component";
import { CustomerFormComponent } from "./customer-form/customer-form.component";

// const routes: Routes = [
//   { path: "", pathMatch: "full", redirectTo: "customers" },
//   {
//     path: "customers",
//     component: HomeComponent
//   },
//   { path: "**", redirectTo: "" },
// ];

const routes: Routes = [
  { path: '', component: CustomerListComponent },
  { path: 'add', component: CustomerFormComponent },
  { path: 'edit/:id', component: CustomerFormComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule { }
