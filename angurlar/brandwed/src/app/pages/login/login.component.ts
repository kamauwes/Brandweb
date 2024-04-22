import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ApiService } from '../../services/api.service';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
  ],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent implements OnInit {

  form!:FormGroup;

  constructor(private apiService:ApiService,private fb:FormBuilder){

  }

  ngOnInit(): void {
    this.form=this.fb.group({
      id:[''],
      userName: [''],
      password: [''],
      email: [''],
      })
      ;


  }

  Onlogin(){
    let formValue=this.form.value
    this.apiService.logUser(formValue).subscribe((res:any)=>{
      console.log(res);

      if(res.result){
        (Response);
      }
      else{
      (Response);
      }

    })

  }
  OnSignup(){
    let formValue=this.form.value
    this.apiService.createUser(formValue).subscribe((res:any)=>{
      console.log(res);

      if(res.result){
        alert ("user created");
      }
      else{
      (res.message)
      }

    })

  }
  // save(){
  //   let formValue=this.form.value
  //   this.apiService.createProducts(formValue).subscribe((res:any)=>{
  //     if(res.result){
  //     alert ("product created");

  //      this.getallProducts();
  //     }else{
  //     alert(res.message)
  //     }
  //   })
  // }

}
