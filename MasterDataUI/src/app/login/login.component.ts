import { Component, OnInit } from '@angular/core';
import { LoginService } from 'src/app/login.service';
import { Router } from '@angular/router';

import { ILogin } from 'src/Model/ILogin';
import { ILoginId } from 'src/Model/ILoginId';

import { ToasterPosition } from 'src/Model/ToasterPosition';
import Swal from 'sweetalert2';
import { EmployeesService } from '../employees.service';
import { CustomerService } from '../customer.service';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {


  constructor(private loginService: LoginService, private router: Router,private employeeService: EmployeesService,private customerService: CustomerService) {

  }
  ngOnInit(): void {

  }

  local2?:any;

  login(email: string, password: string) {
    
    
    
    if (email != '' && password != '') {
      Swal.fire({
        icon: 'success',
        title: 'Login sucess',
        showConfirmButton: false,
        timer: 1000
      })
      
      this.loginService.newLogin({ user: email, password: password } as ILogin).subscribe((log: ILoginId) => {
        var _userData = {
          'id': '',
          'tipo': '',
          'name': ''
        };
      console.log(log.idUser+'teste');
      _userData.id = log.idUser;
      _userData.tipo = log.tipo;
      
      if (log.tipo<=5) {
          this.employeeService.getEmployeeById(log.idUser).subscribe(resultemployee => {
            _userData.name = resultemployee.name;
            localStorage.setItem('userData', JSON.stringify(_userData));
          });
         this.router.navigateByUrl('/CreateReport');

      } else if (log.tipo == 100) {
        this.customerService.getCustumerById(log.idUser).subscribe(resultcustomer => {
          _userData.name = resultcustomer.company;
          localStorage.setItem('userData', JSON.stringify(_userData));
        });
        this.router.navigateByUrl('/searchWorkOrder');
        
      } else if (log.tipo == 1000) {
          this.local2 = "Administrator";
console.log('1000');
          _userData.name = "Administrator";
          localStorage.setItem('userData', JSON.stringify(_userData));

          this.router.navigateByUrl('/CreateCustomer');
           
        } 


       

       /* 
        switch (log.tipo) {
     
          case 0: {
            this.router.navigateByUrl('/RegisterEmployee');
            break;
          }
          case 1: {
            this.router.navigateByUrl('/RegisterEmployee');
            break;
          }
          case 2: {
            this.router.navigateByUrl('/RegisterCustomer');
            break;
          }
          case 3: {
            this.router.navigateByUrl('/RegisterEmployee');
            break;
          }
          case 4: {
            this.router.navigateByUrl('/RegisterCustomer');
            break;
          }
          case 5: {
            this.router.navigateByUrl('/RegisterCustomer');
            break;
          }
          case 100: {
            this.router.navigateByUrl('/RegisterCustomer');
            break;
          }
          case 1000: {
            this.router.navigateByUrl('/RegisterCustomer');
            break;
          }
          default: {
            this.router.navigateByUrl('/RegisterCustomer');
            break;
          }
        }


*/




      //  console.log(log.tipo);
   /*
        if (log.tipo == "1") {
          this.router.navigateByUrl('/RegisterEmployee');
        } else if (log.tipo == "Funcionario") {
          this.router.navigateByUrl('/menuFuncionario');

        }else if(log.tipo == "100") 
        this.router.navigateByUrl('/RegisterCustomer');
        */
      });

    } else {
      Swal.fire('Campos obrigatorios, (Email e password)');
    
    }


  }
  onSubmit(){
    
  }
  getEmployeeId(id:string) {
    this.employeeService.getEmployeeById(id).subscribe(resultemployee => {
        if(resultemployee==null){
           console.log("teste");
        };
    this.local2 = resultemployee.name;
  console.log(resultemployee.name+'teste');
   
  return this.local2= resultemployee.name;
    })
}

getCustomerId(id:string) {
  this.customerService.getCustumerById(id).subscribe(resultcustomer => {
      if(resultcustomer==null){
         console.log("teste");
      };
  this.local2 = resultcustomer.company;
  console.log(resultcustomer.company);
  return resultcustomer.company;
  })
}



}

