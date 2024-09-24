import type { APIType } from "@/types/APIType";
import { ErrorType } from "@/types/TypeError";
import { encryptionStorageToken } from "@/utils/encryption_storage/encryption_storage";
// import { encryptionStorageToken } from "@/utils/encryption_storage/encryption_storage";
import { Loading } from "element-plus/es/components/loading/src/service.mjs";
import { ref, watchEffect,computed } from "vue"

export const useFetchApi = (url: string) => {
    const data = ref();
    const loading = ref(false);
    const error = ref("");
    async function fetchAPI() {
        
        try {
            let response = await fetch(url);
            data.value = await response.json();
        } catch (err) {
            if (String(err).includes(ErrorType.fetchAPI.key)) {
                error.value = ErrorType.fetchAPI.message;
            } else {
                error.value = String(err);
            }
        } finally {
            loading.value = false;
        }
    }
    // fetch once
    watchEffect(async () => {
        loading.value=true
   await awaitTime();
        fetchAPI();
    })
    return { data, loading, error, fetchAPI }
}
async function awaitTime(){
    await setTimeout(
        () => {
         },
        200);
}
export const useActionFetchApi = (actionApi: APIType) => {
    const datas = ref();
    const loading = ref(false);
    const error = ref("");
    async function postAPI(data: any,urlParam?:string,json?:boolean) {
        loading.value = true;
        try {
            let option:RequestInit  ={
                method: actionApi.method,
                body: data,
            };
            if(actionApi.header){
                var information = encryptionStorageToken.getItem("token");
                option={...option,headers:information}
            }
            if(json){
                let header = {...option.headers, "Content-Type": "application/json",};
                option={...option,headers:{...header}}
            }
            var response = await fetch(actionApi.url+(urlParam?`/${urlParam}`:''),option);
            
            datas.value=await response.json();
           
        } catch (err) {
            error.value = String(err);
        } finally {
            loading.value = false;
        }

    }
    const responseData = computed(()=>data);
    return { data:datas, postAPI, loading, error ,responseData}
}