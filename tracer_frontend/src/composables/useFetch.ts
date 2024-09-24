

import { ref, watchEffect } from 'vue';
import type { APIType } from '../types/APIType';

export const useSubmit=()=>{
    async function submit(){
        
    }
}
export const useFetch=(api:APIType)=>{
    const data=ref();
    const error = ref(""); 
    const progress= ref(0);
    const loading = ref(false);
    // use for upload and get the progress
  function postAPI(
    parameter:Document | XMLHttpRequestBodyInit | null,
    urlParam?:string,
    type?:string,
    token?:boolean
){
    const req = new XMLHttpRequest();
    loading.value=true;
    req.open(api.method,api.url+`/${urlParam}`);
    req.addEventListener("progress",(e)=>{
        progress.value=e.loaded/e.total*100;
    })
    req.onload=(e)=>{
        data.value=req.response;
        loading.value=false;
    }
    req.upload.addEventListener("progress",(event: ProgressEvent<XMLHttpRequestEventTarget>)=>{
        progress.value=event.loaded/event.total*100;
    });
    req.upload.addEventListener("error",(e)=>{
        error.value=String(req.response);
    })
    req.upload.addEventListener("abort",()=>{
    })
    if(type){
        req.setRequestHeader("Content-type",type);
    }
    if(token){
    }
    req.send(parameter);
  }
    return {data,error,loading,progress}
}