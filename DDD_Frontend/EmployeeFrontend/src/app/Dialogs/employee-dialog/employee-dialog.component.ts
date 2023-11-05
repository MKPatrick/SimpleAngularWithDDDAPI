import { Component, Inject } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogModule, MatDialogRef } from '@angular/material/dialog';
import { Employee } from 'src/app/Models/employee';

@Component({
  selector: 'app-employee-dialog',
  templateUrl: './employee-dialog.component.html',
  styleUrls: ['./employee-dialog.component.css']


})
export class EmployeeDialogComponent {

  public employeeForm!: FormGroup;
  constructor(  public dialogRef: MatDialogRef<EmployeeDialogComponent>, 
    @Inject(MAT_DIALOG_DATA) public data: Employee
    ){

      

  }

  onNoClick(): void {
    this.dialogRef.close(null);
  }

 
}
