import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { EmployeeDialogComponent } from 'src/app/Dialogs/employee-dialog/employee-dialog.component';
import { Employee } from 'src/app/Models/employee';
import { EmployeeService } from 'src/app/services/employeeservice.service';


@Component({
  selector: 'app-employee-table',
  templateUrl: './employee-table.component.html',
  styleUrls: ['./employee-table.component.css']
})
export class EmployeeTableComponent implements OnInit{


  employees!:Employee[]
  displayedColumns: string[] = [ 'firstname', 'lastname', "title", "address", "department", "Tools"];
  constructor(private employeeService: EmployeeService, private dialog: MatDialog,  private _snackBar: MatSnackBar) {}

  ngOnInit(): void {
  
    this.employeeService.getEmployees().subscribe(data=>{
        this.employees=data.result;
        console.log(this.employees);
    });
  }

  editEmployee(employee: Employee): void {
    const copiedEmployee = Object.assign({}, employee);
    const dialogRef = this.dialog.open(EmployeeDialogComponent, {
      data: copiedEmployee,
    });

    dialogRef.afterClosed().subscribe(result => {
     
      if(result!=null)
      {
      
        this.employeeService.updateEmployee(employee).subscribe(data=>{
          this._snackBar.open('Employee updated!',"Close", {duration:3000});
          Object.assign(employee, result);
      });
    
      }
      
    });

  }


  deleteEmployee(employee: Employee): void {


  }


  addEmployee():void{
    
  }


}
