import {AlertStatus} from '@/enums/AlertEnum';
import {ref,computed} from 'vue';
import { defineStore } from 'pinia'
const  makeAlert=(duration?:number)=>{
    const messageRef =ref("");
    const statusRef:AlertStatus = ref(AlertStatus.NULLABLE);
    function setAlert(statusI:AlertStatus,message:string){
        messageRef.value=message;
        statusRef.value=statusI;
        if(status==AlertStatus.NULLABLE) return;
        setTimeout(()=>{
            messageRef.value="";
            statusRef.value=AlertStatus.NULLABLE;
        }, duration??2000)
   
    }
    const message = computed(()=>messageRef);
    const status = computed(()=>statusRef);
    return {
       message,
        status,
        setAlert,
    }
}
export const useAlert=defineStore('alert',makeAlert);
export const useAlertUpdate =defineStore("alertUpdate",makeAlert);