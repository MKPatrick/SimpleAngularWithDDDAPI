import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { EmployeeService } from 'src/app/services/employeeservice.service';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';
import { EmployeeTableComponent } from './Components/employee-table/employee-table.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {MatTableModule} from '@angular/material/table';
import {MatButtonModule} from '@angular/material/button';
import {MatIconModule} from '@angular/material/icon';
import {MatDialogModule} from '@angular/material/dialog';
import { EmployeeDialogComponent } from './Dialogs/employee-dialog/employee-dialog.component';
import {MatFormFieldModule} from '@angular/material/form-field';
import { FormsModule } from '@angular/forms'; // Import FormsModule
import {MatSnackBarModule} from '@angular/material/snack-bar';
@NgModule({

  declarations: [
    AppComponent,
    EmployeeTableComponent,
         EmployeeDialogComponent
  ],
  imports: [FormsModule, 
    BrowserModule,HttpClientModule,MatDialogModule,MatFormFieldModule,MatSnackBarModule,
    AppRoutingModule,  MatTableModule,MatIconModule,MatButtonModule,
    BrowserAnimationsModule
  ],
  providers: [EmployeeService],
  bootstrap: [AppComponent]
})
export class AppModule { }
