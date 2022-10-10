import { Component, OnInit, ViewChild } from '@angular/core';
import { ConnectionService } from '../../services/Connection/connection.service';
import { BlockUI, NgBlockUI } from 'ng-block-ui';
import Swal from 'sweetalert2';
import { DebtorRegisterComponent } from './debtor-register/debtor-register.component';

@Component({
  selector: 'app-debtor',
  templateUrl: './debtor.component.html',
  styleUrls: ['./debtor.component.scss']
})
export class DebtorComponent implements OnInit {
  @BlockUI() blockUI:any;
  detail:any[]=[];
  @ViewChild(DebtorRegisterComponent) ViewRegister!:any;

  constructor(
    private _ConnectionService:ConnectionService
  ) { 
    this.FN_Search('');
  }

  ngOnInit(): void {
  }

  FN_Search(fact:string):void{
    this.blockUI.start('Cargando...');
    this._ConnectionService.FN_Get('Debtor',fact).then(
      resp => { 
        let response:any=resp;
        if(response['code']=='0'){
          this.detail = response['lstDebtor'];
        }else{
          this.detail = [];
          Swal.fire('Mantenimiento', response['message'], 'error');
        }
      },
      error => { Swal.fire('Mantenimiento', error.message, 'error'); }
    ).finally(()=>{
      this.blockUI.stop();
    });
  }

  FN_ResultProcess(event:any):void{
    if(event){
      this.FN_Search('');
    }
  }

  

  FN_Inactivate(Item:any):void{
    console.log(Item);
  }

  FN_Update(Item:any):void{
    this.ViewRegister.FN_Register(Item);
  }
}
