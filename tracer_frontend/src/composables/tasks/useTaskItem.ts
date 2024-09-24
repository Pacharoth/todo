import { TaskStatus } from "@/enums/TaskEnum";
import { useTaskStore } from "@/stores/task";
import type { TaskType } from "@/types/TaskType";
import { ref,computed ,toRef} from "vue";
import {getDayDifferent} from '@/utils/tasks/date_helper'

export const useTaskItem = (task:TaskType) => {
    const hoverItem = ref(false);
    const taskStore=useTaskStore();
    const updateLoading = ref(false);
    const dayDiff=computed(()=>task?.dueTo ?getDayDifferent(task?.dueTo):undefined);
    function mouseOverItem(e: Event) {
        hoverItem.value = true;
    }
    function mouseLeaveItem(e: Event) {
        hoverItem.value = false;
    }
    async function removeItem() {
        await taskStore.removeItem(task.taskId!)
    }
    async function updateStatus(status:boolean){
        let newTask={
            ...task,
            taskStatus:status?TaskStatus.COMPLETE:TaskStatus.UNCOMPLETE
        }
        updateLoading.value=true;
        await taskStore.updateItem(newTask,true);
        updateLoading.value=false;
    }
    function routeTo(){
        taskStore.routeToUpdateTask(task.taskId!)
    }
    return {
        mouseLeaveItem,

        routeTo,
         mouseOverItem,
         removeItem, 
        hoverItem,
        loadingDelete:taskStore.deleteLoading,
        updateLoading:updateLoading,
        updateStatus,
        dayDiff,
    }
}