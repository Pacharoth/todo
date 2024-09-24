import type{ TaskType } from "../../types/TaskType";
// Order by priorityStatus DESC, dueTo DESC, updatedAt DESC
export function sortTasks(a:TaskType,b:TaskType){
    if(a.priorityStatus!==b.priorityStatus)return a.priorityStatus - b.priorityStatus;
    if(a.dueTo!==b.dueTo)return a.dueTo?.getTime()??0 - (b.dueTo?.getTime() ?? 0);
    return a.updatedAt?.getTime()??0 -(b.updatedAt?.getTime()??0);
} 