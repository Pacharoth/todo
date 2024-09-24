export type APIType={
    method:"POST"|"GET"|"DELETE"|"PUT";
    url:string;
    header?:boolean,
    json?:boolean,
}