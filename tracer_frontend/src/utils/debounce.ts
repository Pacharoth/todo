export const debounce = (callback:any,waitTime?:number)=>{
    let timer;
    return ()=>{
        timer = setTimeout(()=>{
            callback();
            clearTimeout(timer);
        },waitTime??200);
    }
}