import { Component, OnInit, Output, EventEmitter, ViewChild, ElementRef  } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { BlockUI } from 'ng-block-ui';
import Swal from 'sweetalert2';
import { ConnectionService } from '../../../services/Connection/connection.service';

@Component({
  selector: 'app-debtor-register',
  templateUrl: './debtor-register.component.html',
  styleUrls: ['./debtor-register.component.scss']
})
export class DebtorRegisterComponent implements OnInit {
  FrmSave:FormGroup<any>;
  BlnSave:boolean=false;
  option:string='';

  @BlockUI() blockUI:any;
  get f() { return this.FrmSave.controls; }
  @Output() ResultProcess:EventEmitter<any> = new EventEmitter<any>();
  @ViewChild('BtnCloseDebtor') BtnCloseDebtor!:ElementRef;

  constructor(
    private _FormBuilder:FormBuilder,
    private _ConnectionService:ConnectionService
  ) { 
    this.FrmSave = this._FormBuilder.group({
      //debtorCode:[0],
      name:['',Validators.required],
      documentType:['',Validators.required],
      document:['',Validators.required],
      birthdayDate:[null],
      work:[''],
      salary:[0],
      userName:['admin']
    });
  }

  ngOnInit(): void {
      
  }

  FN_New():void{
    this.option = 'New';
  }

  FN_Process():void{
    this.BlnSave=true;
    if(this.FrmSave.invalid){
      return;
    }
    let request = this.FrmSave.value;

    if(this.option=='New'){
      this.FN_Save(request);
    }else{
      request.debtorCode = 0;
      this.FN_Update(request);
    }
  }

  FN_Save(request:any):void{
    // this.BlnSave=true;
    // if(this.FrmSave.invalid){
    //   return;
    // }
    //let request = this.FrmSave.value;
    this.blockUI.start();
    this._ConnectionService.FN_Post('Debtor',request).then(
      resp => {
        let response:any = resp;
        if(response['code']=='0'){
          this.ResultProcess.emit(true);
          this.BtnCloseDebtor.nativeElement.click();
          this.BlnSave = false;
        }else{
          Swal.fire('Mantenimiento', response['message'], 'error');
        }
      },
      error => { Swal.fire('Mantenimiento', error.message, 'error'); }
    ).finally(()=>{ this.blockUI.stop(); });
  }
  FN_Update(request:any):void{
    this.blockUI.start();
    this._ConnectionService.FN_Put('Debtor',request).then(
      resp => {
        let response:any = resp;
        if(response['code']=='0'){
          this.ResultProcess.emit(true);
          this.BtnCloseDebtor.nativeElement.click();
          this.BlnSave = false;
        }else{
          Swal.fire('Mantenimiento', response['message'], 'error');
        }
      },
      error => { Swal.fire('Mantenimiento', error.message, 'error'); }
    ).finally(()=>{ this.blockUI.stop(); });
  }

  FN_Register(Item:any):void{
    console.log(Item);
    if(this.FrmSave == null){ return; }
    
    this.FrmSave.get('documentType').disable();
    this.FrmSave.get('document').disable();
    this.FrmSave.get('name').setValue(Item['name']);
    this.FrmSave.get('birthdayDate').setValue(Item['birthdayDate']);
    this.FrmSave.get('work').setValue(Item['work']);
    this.FrmSave.get('salary').setValue(Item['salary']*1);
    this.FrmSave.get('userName').setValue('admin');
  }
}
